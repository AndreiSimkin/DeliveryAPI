using DeliveryAPI.DTO.Common;
using DeliveryAPI.DTO.Requests.Orders;
using Refit;

namespace DeliveryDesktop.Services
{
    public interface IOrdersApiService
    {
        /// <summary>
        /// Создать новую заявку.
        /// </summary>
        /// <param name="orderInfo">Информация о заявке.</param>
        /// <returns>Id созданой заявки.</returns>
        [Post("/Orders")]
        Task<CreateEntityOperationResultDTO<Guid>> CreateOrder([Body] CreateOrderRequestDTO orderInfo);


        /// <summary>
        /// Получить список заявок.
        /// </summary>
        /// <param name="paginationInfo">Параметры пагинации и фильтрации.</param>
        /// <returns>Список заявок.</returns>
        [Get("/Orders")]
        Task<PagedResponseDTO<OrderDTO>> GetOrders([Query] PaginationRequestDTO paginationInfo);


        /// <summary>
        /// Обновить информацию о заявке.
        /// </summary>
        /// <param name="updateOrderRequest">Данные, которые требуется обновить.</param>
        /// <returns>Результат операции.</returns>
        [Put("/Orders")]
        Task<OperationResultDTO> UpdateOrder([Body] UpdateOrderRequestDTO updateOrderRequest);


        /// <summary>
        /// Удалить заявку.
        /// </summary>
        /// <param name="deleteOrderRequest">Id заявки, которую требуется удалить.</param>
        /// <returns>Результат операции.</returns>
        [Delete("/Orders")]
        Task<OperationResultDTO> DeleteOrder([Body] DeleteOrderRequestDTO deleteOrderRequest);
    }
}
