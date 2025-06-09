using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
