using System.ComponentModel;

namespace DeliveryDesktop.Primitives
{
    public enum OrderStatusEnum
    {
        /// <summary>
        /// Новая заявка.
        /// </summary>
        [Description("Новая")]
        New = 0,

        /// <summary>
        /// На заявку назначен курьер.
        /// </summary>
        [Description("Назначена")]
        Assigned = 1,

        /// <summary>
        /// Заявка выполнена.
        /// </summary>
        [Description("Завершена")]
        Completed = 2,

        /// <summary>
        /// Заявка отменена.
        /// </summary>
        [Description("Отменена")]
        Cancelled = 3
    }
}
