namespace DeliveryAPI.Common.Models
{
    public sealed class NotFoundOperationResult : BaseFailedOperationResult
    {
        #region Prepared results

        // Orders

        public static NotFoundOperationResult OrderNotFoundResult { get; } =
            new NotFoundOperationResult()
            {
                Message = "Заявка не найдена!"
            };

        public static NotFoundOperationResult CourierNotFoundResult { get; } =
            new NotFoundOperationResult()
            {
                Message = "Курьер не найден!"
            };

        #endregion
    }
}
