using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliveryAPI.DTO.Common;
using DeliveryAPI.DTO.Requests.Couriers;
using DeliveryAPI.DTO.Requests.Orders;
using DeliveryAPI.DTO.Requests.OrderStatus;
using DeliveryDesktop.Extensions;
using DeliveryDesktop.Models;
using DeliveryDesktop.Primitives;
using DeliveryDesktop.Services;
using DeliveryDesktop.ViewModels.Controls;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Controls;

namespace DeliveryDesktop.ViewModels
{
    public partial class OrdersViewModel : ObservableObject
    {
        private const int PageSize = 20;

        private readonly IOrdersApiService _ordersApiService;
        private readonly ICouriersApiService _couriersApiService;
        private readonly IOrderStatusApiService _orderStatusApiService;
        private readonly IMapper _mapper;
        private readonly IDialogService _dialogService;

        private int _pageNumber = 1;

        private bool _isLastPage = false;
        private readonly Subject<string> _searchSubject = new();
        private string _ordersFiler = string.Empty;


        public OrdersViewModel(ICouriersApiService couriersApiService, IOrdersApiService ordersApiService,
           IOrderStatusApiService orderStatusApiService, IMapper mapper, IDialogService dialogService)
        {
            _couriersApiService = couriersApiService;
            _ordersApiService = ordersApiService;
            _orderStatusApiService = orderStatusApiService;
            _mapper = mapper;
            _dialogService = dialogService;

            LoadContent(_ordersFiler).Forget();
            LoadCouriers().Forget();
            SetupSearchObservable();
        }

        private void SetupSearchObservable()
        {
            _searchSubject
                .DistinctUntilChanged() // Игнорируем дублирующиеся значения
                .Throttle(TimeSpan.FromMilliseconds(500)) // Задержка 500мс
                .ObserveOn(SynchronizationContext.Current ?? new SynchronizationContext())
                .Subscribe(filter =>
                {
                    _ordersFiler = filter;
                    Orders.Clear();
                    _pageNumber = 1;
                    LoadContent(_ordersFiler).Forget();
                });

        }

        private bool CanAssign => SelectedCourier != null;


        [ObservableProperty]
        private ObservableCollection<OrderCardViewModel> _orders = [];


        [ObservableProperty]
        private ObservableCollection<CourierModel> _couriers = [];


        [ObservableProperty]
        private OrderCardViewModel? _selectedOrder = null;


        [ObservableProperty]
        private CourierModel? _selectedCourier = null;


        [ObservableProperty]
        private string _searchText = string.Empty;



        [RelayCommand]
        public async Task CreateOrder()
        {
            OrderModel? orderModel = _dialogService.ShowCreateOrderDialog();

            if (orderModel == null) return;

            var createOrderRequest = _mapper.Map<CreateOrderRequestDTO>(orderModel);

            var result = await _ordersApiService.CreateOrder(createOrderRequest);

            if (result.Success == false) return;

            orderModel.Id = result.Id;

            var cardViewModel = _mapper.Map<OrderCardViewModel>(orderModel);

            Orders.Insert(0, cardViewModel);
        }


        [RelayCommand]
        public async Task RegisterCourier()
        {
            CourierModel? courierModel = _dialogService.ShowCourierRegistrationDialog();

            if (courierModel == null) return;

            var registerCourierRequest = _mapper.Map<RegisterCourierRequestDTO>(courierModel);

            var result = await _couriersApiService.RegisterCourier(registerCourierRequest);

            if (result.Success == false) return;

            courierModel.Id = result.Id;

            Couriers.Insert(0, courierModel);

            SelectedCourier = courierModel;
        }


        [RelayCommand]
        public async Task EditOrder()
        {
            if (SelectedOrder?.Data == null)
                return;

            OrderModel? orderModel = _dialogService.ShowEditOrderDialog(SelectedOrder.Data);

            if (orderModel == null) return;

            var editOrderRequest = _mapper.Map<UpdateOrderRequestDTO>(orderModel);

            var result = await _ordersApiService.UpdateOrder(editOrderRequest);

            if (result.Success == false) return;

            _mapper.Map(orderModel, SelectedOrder);

        }


        [RelayCommand]
        public async Task CancelOrder()
        {
            if (SelectedOrder?.Data == null)
                return;

            string? canelationReason = _dialogService.ShowCancelOrderDialog();

            if (canelationReason == null) return;

            var cancelOrderRequest = new CancelOrderRequestDTO()
            {
                Id = SelectedOrder.Data.Id,
                CancellationReason = canelationReason
            };

            var result = await _orderStatusApiService.CancelOrder(cancelOrderRequest);

            if (result.Success == false) return;


            SelectedOrder.Status = OrderStatusEnum.Cancelled;
            SelectedOrder.Courier = null;

            SelectedOrder.Data.ClosedAt = DateTime.UtcNow;
            SelectedOrder.Data.CancellationReason = canelationReason;
            SelectedOrder.Data.Status = OrderStatusEnum.Cancelled;
            SelectedOrder.Data.Courier = null;

            OnPropertyChanged(nameof(SelectedOrder));
        }


        [RelayCommand(CanExecute = nameof(CanAssign))]
        public async Task AssignCourier()
        {
            if (SelectedOrder?.Data == null) return;

            if (SelectedCourier == null) return;

            var assignOrderRequest = new AssignOrderRequestDTO()
            {
                Id = SelectedOrder.Data.Id,
                CourierId = SelectedCourier.Id
            };

            var result = await _orderStatusApiService.AssignOrder(assignOrderRequest);

            if (result.Success == false) return;

            SelectedOrder.Status = OrderStatusEnum.Assigned;
            SelectedOrder.Courier = SelectedCourier;
            SelectedOrder.Data.Status = OrderStatusEnum.Assigned;
            SelectedOrder.Data.Courier = SelectedCourier;
        }


        [RelayCommand]
        public async Task CompleteOrder()
        {
            if (SelectedOrder?.Data == null) return;


            var completeOrderRequest = new CompleteOrderRequestDTO()
            {
                Id = SelectedOrder.Data.Id,
            };

            var result = await _orderStatusApiService.CompleteOrder(completeOrderRequest);

            if (result.Success == false) return;

            SelectedOrder.Status = OrderStatusEnum.Completed;
            SelectedOrder.Courier = null;

            SelectedOrder.Data.ClosedAt = DateTime.UtcNow;
            SelectedOrder.Data.Status = OrderStatusEnum.Completed;
            SelectedOrder.Data.Courier = null;

            OnPropertyChanged(nameof(SelectedOrder));
        }


        [RelayCommand]
        public async Task DeleteOrder()
        {
            if (SelectedOrder?.Data == null) return;


            var deleteOrderRequest = new DeleteOrderRequestDTO()
            {
                Id = SelectedOrder.Data.Id,
            };

            var result = await _ordersApiService.DeleteOrder(deleteOrderRequest);

            if (result.Success == false) return;

            Orders.Remove(SelectedOrder);

            SelectedOrder = null;
        }


        private async Task LoadCouriers()
        {
            var pagedResponse = await _couriersApiService.GetCouriers(new PaginationRequestDTO()
            {
                PageSize = PageSize,
                PageNumber = _pageNumber
            });

            _isLastPage = pagedResponse.PageCount <= _pageNumber;

            if (pagedResponse == null)
                return;

            foreach (var courier in pagedResponse.Items)
                Couriers.Add(_mapper.Map<CourierModel>(courier));
        }


        private async Task LoadContent(string filter)
        {
            var pagedResponse = await _ordersApiService.GetOrders(new PaginationRequestDTO()
            {
                PageSize = PageSize,
                PageNumber = _pageNumber,
                Filter = filter
            });

            _isLastPage = pagedResponse.PageCount <= _pageNumber;

            if (pagedResponse == null)
                return;

            foreach (var order in pagedResponse.Items)
                if (Orders.Any(o => o.Id == order.Id) == false)
                    Orders.Add(_mapper.Map<OrderCardViewModel>(order));
        }


        private async Task LoadMoreContent()
        {
            if (_isLastPage == false)
                _pageNumber++;

            await LoadContent(_ordersFiler);
        }


        [RelayCommand]
        private void ScrollChanged(object parameter)
        {
            if (parameter is not ScrollChangedEventArgs scrollEventArgs)
                return;

            var sv = scrollEventArgs.OriginalSource as ScrollViewer;
            if (sv != null && sv.VerticalOffset >= sv.ScrollableHeight)
            {
                // Подгружаем следующую страницу
                LoadMoreContent().Forget();
            }
        }


        [RelayCommand]
        private void SelectionChanged(object parameter)
        {
            if (parameter is not SelectionChangedEventArgs selectionChangedArgs)
                return;

            if (selectionChangedArgs.AddedItems.Count != 1)
                return;

            SelectedOrder = selectionChangedArgs.AddedItems[0] as OrderCardViewModel;
            SelectedCourier = null;
        }


        partial void OnSelectedCourierChanged(CourierModel? value) =>
            AssignCourierCommand.NotifyCanExecuteChanged();

        partial void OnSearchTextChanged(string value)
        {
            _searchSubject.OnNext(value);
        }
    }
}
