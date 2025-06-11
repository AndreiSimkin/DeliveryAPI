using AutoMapper;
using DeliveryAPI.Commands.Couriers;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data.Models;
using DeliveryAPI.DTO.Common;
using DeliveryAPI.DTO.Requests.Couriers;
using DeliveryAPI.Queries.Couriers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CouriersController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;


        public CouriersController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }


        /// <summary>
        /// Зарегистрировать курьера.
        /// </summary>
        /// <param name="courierInfo">Информация о курьере.</param>
        /// <returns>Id зарегистрированного курьера.</returns>
        [HttpPost]
        public async Task<ActionResult<IOperationResult>> RegisterCourier(RegisterCourierRequestDTO courierInfo)
        {
            RegisterCourierCommand createCourierCommand = _mapper.Map<RegisterCourierCommand>(courierInfo);
            IOperationResult operationResult = await _sender.Send(createCourierCommand);
            ActionResult<IOperationResult> actionResult = _mapper.Map<ActionResult<IOperationResult>>(operationResult);

            return actionResult;
        }


        /// <summary>
        /// Получить список курьеров.
        /// </summary>
        /// <param name="query">Параметры пагинации и фильтрации.</param>
        /// <returns>Список курьеров.</returns>
        [HttpGet]
        public async Task<ActionResult<PagedResponseDTO<CourierDTO>>> GetCouriers([FromQuery] PaginationRequestDTO query)
        {
            GetCouriersQuery getCouriersQuery = _mapper.Map<GetCouriersQuery>(query);
            PagedResult<CourierEntity> pagedResult = await _sender.Send(getCouriersQuery);
            PagedResponseDTO<CourierDTO> couriersListResponse = _mapper.Map<PagedResponseDTO<CourierDTO>>(pagedResult);

            return Ok(couriersListResponse);
        }


        /// <summary>
        /// Обновить информацию о курьере.
        /// </summary>
        /// <param name="updateCourierRequest">Данные, которые требуется обновить.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut]
        public async Task<ActionResult<IOperationResult>> UpdateCourier(UpdateCourierRequestDTO updateCourierRequest)
        {
            UpdateCourierCommand createCourierCommand = _mapper.Map<UpdateCourierCommand>(updateCourierRequest);
            IOperationResult operationResult = await _sender.Send(createCourierCommand);
            ActionResult<IOperationResult> actionResult = _mapper.Map<ActionResult<IOperationResult>>(operationResult);

            return actionResult;
        }


        /// <summary>
        /// Удалить курьера из системы.
        /// </summary>
        /// <param name="deleteCourierRequest">Id курьера, которого требуется удалить.</param>
        /// <returns>Результат операции.</returns>
        [HttpDelete]
        public async Task<ActionResult<IOperationResult>> DeleteCourier(DeleteCourierRequestDTO deleteCourierRequest)
        {
            DeleteCourierCommand createCourierCommand = _mapper.Map<DeleteCourierCommand>(deleteCourierRequest);
            IOperationResult operationResult = await _sender.Send(createCourierCommand);
            ActionResult<IOperationResult> actionResult = _mapper.Map<ActionResult<IOperationResult>>(operationResult);

            return actionResult;
        }
    }
}
