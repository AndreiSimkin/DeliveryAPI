using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDesktop.Models
{
    public abstract class BaseModel<TId>
    {
        public TId? Id { get; set; }
    }
}
