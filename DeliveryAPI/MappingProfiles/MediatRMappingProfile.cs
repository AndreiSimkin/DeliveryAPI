using AutoMapper;
using DeliveryAPI.Commands.Couriers;
using DeliveryAPI.Commands.Orders;
using DeliveryAPI.Commands.OrderStatus;
using DeliveryAPI.Data.Models;
using DeliveryAPI.DTO.Common;
using DeliveryAPI.DTO.Requests.Couriers;
using DeliveryAPI.DTO.Requests.Orders;
using DeliveryAPI.DTO.Requests.OrderStatus;
using DeliveryAPI.Queries.Couriers;
using DeliveryAPI.Queries.Orders;

namespace DeliveryAPI.MappingProfiles
{
    public class MediatRMappingProfile : Profile
    {
        public MediatRMappingProfile()
        {
            // Create order

            CreateMap<CreateOrderRequestDTO, CreateOrderCommand>();
            CreateMap<CreateOrderCommand, OrderEntity>();

            // Update order

            CreateMap<UpdateOrderCommand, OrderEntity>()
                 .ForMember(u => u.Id, opt => opt.Ignore())
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateOrderRequestDTO, UpdateOrderCommand>();

            // Cancel order

            CreateMap<CancelOrderRequestDTO, CancelOrderCommand>();

            // Assign order

            CreateMap<AssignOrderRequestDTO, AssignOrderCommand>();

            // Complete order

            CreateMap<CompleteOrderRequestDTO, CompleteOrderCommand>();

            // Delete order

            CreateMap<DeleteOrderRequestDTO, DeleteOrderCommand>();

            // Register courier

            CreateMap<RegisterCourierRequestDTO, RegisterCourierCommand>();
            CreateMap<RegisterCourierCommand, CourierEntity>();

            // Update courier

            CreateMap<UpdateCourierCommand, CourierEntity>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateCourierRequestDTO, UpdateCourierCommand>();

            // Delete courier

            CreateMap<DeleteCourierRequestDTO, DeleteCourierCommand>();

            // Pagination

            CreateMap<PaginationRequestDTO, GetCouriersQuery>();
            CreateMap<PaginationRequestDTO, GetOrdersQuery>();
        }
    }
}
