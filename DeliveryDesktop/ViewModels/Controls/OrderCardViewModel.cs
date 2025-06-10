using CommunityToolkit.Mvvm.ComponentModel;
using DeliveryDesktop.Models;
using DeliveryDesktop.Primitives;

namespace DeliveryDesktop.ViewModels.Controls
{
    public partial class OrderCardViewModel : ObservableObject
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Время создания заявки.
        /// </summary>
        [ObservableProperty]
        private DateTime _createdAt;

        /// <summary>
        /// Имя клиента.
        /// </summary>
        [ObservableProperty]
        private string? _clientName;

        /// <summary>
        /// Адрес, откуда требуется забрать груз.
        /// </summary>
        [ObservableProperty]
        private string? _pickupAddress;

        /// <summary>
        /// Время, когда нужно забрать груз.
        /// </summary>
        [ObservableProperty]
        private DateTime _pickupTime;

        /// <summary>
        /// Адрес, куда требуется доставить груз.
        /// </summary>
        [ObservableProperty]
        private string? _deliveryAddress;

        /// <summary>
        /// Курьер, который доставляет груз.
        /// </summary>
        [ObservableProperty]
        private CourierModel? _courier;

        /// <summary>
        /// Статус заявки.
        /// </summary>
        [ObservableProperty]
        private OrderStatusEnum _status;

        /// <summary>
        /// Ссылка на оригинальные данные заявки.
        /// </summary>
        [ObservableProperty]
        public OrderModel? _data;
    }
}
