using AutoMapper;
using DeliveryAPI.Commands.Orders;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data.Models;
using DeliveryAPI.DTO.Common;
using DeliveryAPI.DTO.Requests.Orders;
using DeliveryAPI.Queries.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;


        public OrdersController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        /// <summary>
        /// Создать новую заявку.
        /// </summary>
        /// <param name="orderInfo">Информация о заявке.</param>
        /// <returns>Id созданой заявки.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestDTO orderInfo)
        {
            CreateOrderCommand createOrderCommand = _mapper.Map<CreateOrderCommand>(orderInfo);
            IOperationResult operationResult = await _sender.Send(createOrderCommand);
            IActionResult actionResult = _mapper.Map<IActionResult>(operationResult);

            return actionResult;
        }


        /// <summary>
        /// Получить список заявок.
        /// </summary>
        /// <param name="paginationInfo">Параметры пагинации и фильтрации.</param>
        /// <returns>Список заявок.</returns>
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] PaginationRequestDTO paginationInfo)
        {
            GetOrdersQuery getOrdersQuery = _mapper.Map<GetOrdersQuery>(paginationInfo);
            PagedResult<OrderEntity> pagedResult = await _sender.Send(getOrdersQuery);
            PagedResponseDTO<OrderDTO> ordersListResponse = _mapper.Map<PagedResponseDTO<OrderDTO>>(pagedResult);

            return Ok(ordersListResponse);
        }


        /// <summary>
        /// Обновить информацию о заявке.
        /// </summary>
        /// <param name="updateOrderRequest">Данные, которые требуется обновить.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequestDTO updateOrderRequest)
        {
            UpdateOrderCommand createOrderCommand = _mapper.Map<UpdateOrderCommand>(updateOrderRequest);
            IOperationResult operationResult = await _sender.Send(createOrderCommand);
            IActionResult actionResult = _mapper.Map<IActionResult>(operationResult);

            return actionResult;
        }


        /// <summary>
        /// Удалить заявку.
        /// </summary>
        /// <param name="deleteOrderRequest">Id заявки, которую требуется удалить.</param>
        /// <returns>Результат операции.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(DeleteOrderRequestDTO deleteOrderRequest)
        {
            DeleteOrderCommand deleteOrderCommand = _mapper.Map<DeleteOrderCommand>(deleteOrderRequest);
            IOperationResult operationResult = await _sender.Send(deleteOrderCommand);
            IActionResult actionResult = _mapper.Map<IActionResult>(operationResult);

            return actionResult;
        }
    }
}
