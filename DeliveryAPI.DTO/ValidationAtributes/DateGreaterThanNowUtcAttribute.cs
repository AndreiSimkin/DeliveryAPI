using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAPI.DTO.ValidationAtributes
{
    public class DateGreaterThanNowUtcAttribute : ValidationAttribute
    {
        public DateGreaterThanNowUtcAttribute()
        {
            ErrorMessage = "The date must be greater than the current UTC time.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return true; // Handle [Required] separately

            if (value is DateTime dateTime)
            {
                return dateTime > DateTime.UtcNow;
            }

            return false;
        }
    }
}
