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
