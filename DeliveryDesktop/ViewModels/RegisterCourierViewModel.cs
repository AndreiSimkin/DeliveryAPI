using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliveryAPI.DTO.ValidationAtributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDesktop.ViewModels
{
    public partial class RegisterCourierViewModel : ObservableValidator
    {
        public event EventHandler? RequestClose;


        public bool IsDone { get; private set; }


        [ObservableProperty]
        [FullName]
        [Required(ErrorMessage = "ФИО обязательно")]
        private string? _fullName;


        [ObservableProperty]
        [Phone]
        [Length(11, 11)]
        [Required(ErrorMessage = "Номер телефона обязателен")]
        private string? _phoneNumber;



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
