using AutoMapper;
using DeliveryAPI.Commands.OrderStatus;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.Common.Models;
using DeliveryAPI.DTO.Common;
using DeliveryAPI.DTO.Requests.OrderStatus;
using DeliveryAPI.Queries.OrderStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderStatusController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;


        public OrderStatusController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }


        /// <summary>
        /// Получить список статусов.
        /// </summary>
        /// <returns>Список статусов.</returns>
        [HttpGet("List")]
        public async Task<ActionResult<OrderStatusInfoDTO[]>> GetOrderStatusList()
        {
            GetOrderStatusListQuery getOrderStatusListQuery = new GetOrderStatusListQuery();

            OrderStatusInfo[] orderStatusInfoList = await _sender.Send(getOrderStatusListQuery);

            OrderStatusInfoDTO[] orderStatusInfoListDTO = _mapper.Map<OrderStatusInfoDTO[]>(orderStatusInfoList);

            return Ok(orderStatusInfoListDTO);
        }


        /// <summary>
        /// Отменить заявку.
        /// </summary>
        /// <param name="cancelOrderRequest">Id заявки, которую требуется отменить.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut("Cancel")]
        public async Task<ActionResult<IOperationResult>> CancelOrder(CancelOrderRequestDTO cancelOrderRequest)
        {
            CancelOrderCommand createOrderCommand = _mapper.Map<CancelOrderCommand>(cancelOrderRequest);
            IOperationResult operationResult = await _sender.Send(createOrderCommand);
            ActionResult<IOperationResult> actionResult = _mapper.Map<ActionResult<IOperationResult>>(operationResult);

            return actionResult;
        }


        /// <summary>
        /// Назначить курьера на заявку.
        /// </summary>
        /// <param name="assignOrderRequest">Id заявки и Id курьера, которого требуется назначить.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut("Assign")]
        public async Task<ActionResult<IOperationResult>> AssignOrder(AssignOrderRequestDTO assignOrderRequest)
        {
            AssignOrderCommand createOrderCommand = _mapper.Map<AssignOrderCommand>(assignOrderRequest);
            IOperationResult operationResult = await _sender.Send(createOrderCommand);
            ActionResult<IOperationResult> actionResult = _mapper.Map<ActionResult<IOperationResult>>(operationResult);

            return actionResult;
        }


        /// <summary>
        /// Завершить заявку.
        /// </summary>
        /// <param name="completeOrderRequest">Id заявки, которую требутся завершить.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut("Complete")]
        public async Task<ActionResult<IOperationResult>> CompleteOrder(CompleteOrderRequestDTO completeOrderRequest)
        {
            CompleteOrderCommand createOrderCommand = _mapper.Map<CompleteOrderCommand>(completeOrderRequest);
            IOperationResult operationResult = await _sender.Send(createOrderCommand);
            ActionResult<IOperationResult> actionResult = _mapper.Map<ActionResult<IOperationResult>>(operationResult);

            return actionResult;
        }
    }
}
