using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliveryAPI.DTO.ValidationAtributes;
using System.ComponentModel.DataAnnotations;

namespace DeliveryDesktop.ViewModels
{
    public partial class EditOrderViewModel : ObservableValidator
    {
        public event EventHandler? RequestClose;


        public bool IsDone { get; private set; }


        [ObservableProperty]
        [Required(ErrorMessage = "Название обязательно")]
        private string? _clientName;


        [ObservableProperty]
        [Required(ErrorMessage = "Адрес получения обязателен")]
        private string? _pickupAddress;


        [ObservableProperty]
        [DateGreaterThanNowUtc]
        [Required(ErrorMessage = "Время получения обязателено")]
        private DateTime? _pickupTime;


        [ObservableProperty]
        [Required(ErrorMessage = "Адрес доставки обязателен")]
        private string? _deliveryAddress;


        [ObservableProperty]
        [Range(1, 1000)]
        [Required(ErrorMessage = "Вес груза обязателен")]
        private int? _weight;


        [ObservableProperty]
        [Range(1, 1000)]
        [Required(ErrorMessage = "Длина груза обязателена")]
        private int? _length;


        [ObservableProperty]
        [Range(1, 1000)]
        [Required(ErrorMessage = "Ширина груза обязателена")]
        private int? _width;


        [ObservableProperty]
        [Range(1, 1000)]
        [Required(ErrorMessage = "Высота груза обязателена")]
        private int? _height;


        [RelayCommand]
        private void Save()
        {
            ValidateAllProperties();
            if (HasErrors) return;

            IsDone = true;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
