using DeliveryAPI.DTO.Common;
using DeliveryAPI.DTO.Requests.OrderStatus;
using Refit;

namespace DeliveryDesktop.Services
{
    public interface IOrderStatusApiService
    {
        /// <summary>
        /// Отменить заявку.
        /// </summary>
        /// <param name="cancelOrderRequest">Id заявки, которую требуется отменить.</param>
        /// <returns>Результат операции.</returns>
        [Put("/OrderStatus/Cancel")]
        Task<OperationResultDTO> CancelOrder(CancelOrderRequestDTO cancelOrderRequest);


        /// <summary>
        /// Назначить курьера на заявку.
        /// </summary>
        /// <param name="assignOrderRequest">Id заявки и Id курьера, которого требуется назначить.</param>
        /// <returns>Результат операции.</returns>
        [Put("/OrderStatus/Assign")]
        Task<OperationResultDTO> AssignOrder(AssignOrderRequestDTO assignOrderRequest);


        /// <summary>
        /// Завершить заявку.
        /// </summary>
        /// <param name="completeOrderRequest">Id заявки, которую требутся завершить.</param>
        /// <returns>Результат операции.</returns>
        [Put("/OrderStatus/Complete")]
        Task<OperationResultDTO> CompleteOrder(CompleteOrderRequestDTO completeOrderRequest);
    }
}
