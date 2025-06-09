using AutoMapper;
using DeliveryAPI.Commands.OrderStatus;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.DTO.Requests.OrderStatus;
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
        /// Отменить заявку.
        /// </summary>
        /// <param name="cancelOrderRequest">Id заявки, которую требуется отменить.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut("Cancel")]
        public async Task<IActionResult> CancelOrder(CancelOrderRequestDTO cancelOrderRequest)
        {
            CancelOrderCommand createOrderCommand = _mapper.Map<CancelOrderCommand>(cancelOrderRequest);
            IOperationResult operationResult = await _sender.Send(createOrderCommand);
            IActionResult actionResult = _mapper.Map<IActionResult>(operationResult);

            return actionResult;
        }


        /// <summary>
        /// Назначить курьера на заявку.
        /// </summary>
        /// <param name="assignOrderRequest">Id заявки и Id курьера, которого требуется назначить.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut("Assign")]
        public async Task<IActionResult> AssignOrder(AssignOrderRequestDTO assignOrderRequest)
        {
            AssignOrderCommand createOrderCommand = _mapper.Map<AssignOrderCommand>(assignOrderRequest);
            IOperationResult operationResult = await _sender.Send(createOrderCommand);
            IActionResult actionResult = _mapper.Map<IActionResult>(operationResult);

            return actionResult;
        }


        /// <summary>
        /// Завершить заявку.
        /// </summary>
        /// <param name="completeOrderRequest">Id заявки, которую требутся завершить.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut("Complete")]
        public async Task<IActionResult> CompleteOrder(CompleteOrderRequestDTO completeOrderRequest)
        {
            CompleteOrderCommand createOrderCommand = _mapper.Map<CompleteOrderCommand>(completeOrderRequest);
            IOperationResult operationResult = await _sender.Send(createOrderCommand);
            IActionResult actionResult = _mapper.Map<IActionResult>(operationResult);

            return actionResult;
        }
    }
}
