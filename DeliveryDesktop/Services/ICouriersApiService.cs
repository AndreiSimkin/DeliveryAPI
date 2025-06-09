using DeliveryAPI.DTO.Common;
using DeliveryAPI.DTO.Requests.Couriers;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDesktop.Services
{
    public interface ICouriersApiService
    {
        /// <summary>
        /// Зарегестрировать курьера.
        /// </summary>
        /// <param name="courierInfo">Информация о курьере.</param>
        /// <returns>Id зарегистрированного курьера.</returns>
        [Post("/Couriers")]
        Task<CreateEntityOperationResultDTO<Guid>> RegisterCourier([Body] RegisterCourierRequestDTO courierInfo);


        /// <summary>
        /// Получить список курьеров.
        /// </summary>
        /// <param name="query">Параметры пагинации и фильтрации.</param>
        /// <returns>Список курьеров.</returns>
        [Get("/Couriers")]
        Task<PagedResponseDTO<CourierDTO>> GetCouriers([Query] PaginationRequestDTO query);


        /// <summary>
        /// Обновить информацию о курьере.
        /// </summary>
        /// <param name="updateCourierRequest">Данные, которые требуется обновить.</param>
        /// <returns>Результат операции.</returns>
        [Put("/Couriers")]
        Task<OperationResultDTO> UpdateCourier([Body] UpdateCourierRequestDTO updateCourierRequest);


        /// <summary>
        /// Удалить курьера из системы.
        /// </summary>
        /// <param name="deleteCourierRequest">Id курьера, которого требуется удалить.</param>
        /// <returns>Результат операции.</returns>
        [Delete("/Couriers")]
        Task<OperationResultDTO> DeleteCourier([Body] DeleteCourierRequestDTO deleteCourierRequest);
    }
}
