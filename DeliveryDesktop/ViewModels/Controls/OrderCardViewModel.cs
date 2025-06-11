using CommunityToolkit.Mvvm.ComponentModel;
using DeliveryDesktop.Models;
using DeliveryDesktop.Primitives;
using System.ComponentModel.DataAnnotations;

namespace DeliveryDesktop.ViewModels.Controls
{
    public partial class OrderCardViewModel : ObservableObject
    {
        /// <summary>
        /// Индификатор заявки.
        /// </summary>
        public Guid Id;

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
        /// Вес груза.
        /// </summary>
        [ObservableProperty]
        private int _weight;

        /// <summary>
        /// Длина груза.
        /// </summary>
        [ObservableProperty]
        private int _length;

        /// <summary>
        /// Ширина груза.
        /// </summary>
        [ObservableProperty]
        private int _width;

        /// <summary>
        /// Высота груза.
        /// </summary>
        [ObservableProperty]
        private int _height;

        /// <summary>
        /// Ссылка на оригинальные данные заявки.
        /// </summary>
        [ObservableProperty]
        public OrderModel? _data;
    }
}
