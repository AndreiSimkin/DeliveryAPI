using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.Data.Models
{
    public class BaseEntity<TId>
    {
        [Key]
        public TId? Id { get; set; }
    }
}
