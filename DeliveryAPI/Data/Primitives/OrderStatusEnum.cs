namespace DeliveryAPI.Data.Primitives
{
    public enum OrderStatusEnum
    {
        /// <summary>
        /// Новая заявка.
        /// </summary>
        New = 0,

        /// <summary>
        /// На заявку назначен курьер.
        /// </summary>
        Assigned = 1,

        /// <summary>
        /// Заявка выполнена.
        /// </summary>
        Completed = 2,

        /// <summary>
        /// Заявка отменена.
        /// </summary>
        Cancelled = 3
    }
}
