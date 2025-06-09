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
    public partial class CancelOrderViewModel : ObservableValidator
    {
        public event EventHandler? RequestClose;


        public bool IsDone { get; private set; }


        [ObservableProperty]
        [Required(ErrorMessage = "Причина отмены обязательан")]
        private string? _сancellationReason;


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
