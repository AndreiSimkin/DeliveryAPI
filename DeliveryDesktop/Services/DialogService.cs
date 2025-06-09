using AutoMapper;
using DeliveryAPI.DTO.Requests.Orders;
using DeliveryDesktop;
using DeliveryDesktop.Models;
using DeliveryDesktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDesktop.Services
{
    public class DialogService : IDialogService
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IMapper _mapper;


        public DialogService(IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }


        public OrderModel? ShowEditOrderDialog(OrderModel order)
        {
            var editOrderView = _serviceProvider.GetService<EditOrderView>();
            var editOrderViewModel = _serviceProvider.GetService<EditOrderViewModel>();

            if (editOrderView == null || editOrderViewModel == null || order == null)
                return null;

            _mapper.Map(order, editOrderViewModel);

            editOrderViewModel.RequestClose += (s, e) => editOrderView.Close();
            editOrderView.DataContext = editOrderViewModel;

            editOrderView.ShowDialog();

            if (editOrderViewModel.IsDone == false)
                return null;

            _mapper.Map(editOrderViewModel, order);

            return order;
        }


        public OrderModel? ShowCreateOrderDialog()
        {
            var createOrderView = _serviceProvider.GetService<CreateOrderView>();
            var createOrderViewModel = _serviceProvider.GetService<CreateOrderViewModel>();

            if (createOrderView == null || createOrderViewModel == null)
                return null;

            createOrderViewModel.RequestClose += (s, e) => createOrderView.Close();
            createOrderView.DataContext = createOrderViewModel;

            createOrderView.ShowDialog();

            if (createOrderViewModel.IsDone == false)
                return null;

            var orderModel = _mapper.Map<OrderModel>(createOrderViewModel);

            return orderModel;
        }

        public string? ShowCancelOrderDialog()
        {
            var cancelOrderView = _serviceProvider.GetService<CancelOrderView>();
            var cancelOrderViewModel = _serviceProvider.GetService<CancelOrderViewModel>();

            if (cancelOrderView == null || cancelOrderViewModel == null)
                return null;

            cancelOrderViewModel.RequestClose += (s, e) => cancelOrderView.Close();
            cancelOrderView.DataContext = cancelOrderViewModel;

            cancelOrderView.ShowDialog();

            if (cancelOrderViewModel.IsDone == false)
                return null;

            return cancelOrderViewModel.СancellationReason;
        }


        public CourierModel? ShowCourierRegistrationDialog()
        {
            var registerCourierView = _serviceProvider.GetService<RegisterCourierView>();
            var registerCourierViewModel = _serviceProvider.GetService<RegisterCourierViewModel>();

            if (registerCourierView == null || registerCourierViewModel == null)
                return null;

            registerCourierViewModel.RequestClose += (s, e) => registerCourierView.Close();
            registerCourierView.DataContext = registerCourierViewModel;

            registerCourierView.ShowDialog();

            if (registerCourierViewModel.IsDone == false)
                return null;

            var courierModel = _mapper.Map<CourierModel>(registerCourierViewModel);

            return courierModel;
        }
    }
}
