using Microsoft.OpenApi.Attributes;
using System.ComponentModel;

namespace DeliveryAPI.Data.Primitives
{
    public enum OrderStatusEnum
    {
        /// <summary>
        /// Новая заявка.
        /// </summary>
        [Display("Новая")]
        New = 0,

        /// <summary>
        /// На заявку назначен курьер.
        /// </summary>
        [Display("Назначена")]
        Assigned = 1,

        /// <summary>
        /// Заявка выполнена.
        /// </summary>
        [Display("Завершена")]
        Completed = 2,

        /// <summary>
        /// Заявка отменена.
        /// </summary>
        [Display("Отменена")]
        Cancelled = 3
    }
}
