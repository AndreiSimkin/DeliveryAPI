using AutoMapper;
using DeliveryAPI.DTO.Common;
using DeliveryAPI.DTO.Requests.Couriers;
using DeliveryAPI.DTO.Requests.Orders;
using DeliveryDesktop.Models;
using DeliveryDesktop.ViewModels;
using DeliveryDesktop.ViewModels.Controls;

namespace DeliveryDesktop.MappingProfiles
{
    public class DTOMappringProfile : Profile
    {
        public DTOMappringProfile()
        {
            // Common

            CreateMap<OrderModel, OrderDTO>();
            CreateMap<OrderDTO, OrderModel>();

            CreateMap<OrderDTO, OrderCardViewModel>()
                .ForMember(o => o.Data, opt => opt.MapFrom(x => x));

            CreateMap<OrderModel, OrderShortDTO>();
            CreateMap<OrderShortDTO, OrderModel>();

            CreateMap<CourierModel, CourierDTO>();
            CreateMap<CourierDTO, CourierModel>();

            CreateMap<CourierShortDTO, CourierModel>();
            CreateMap<CourierModel, CourierShortDTO>();


            // Create order

            CreateMap<OrderModel, CreateOrderRequestDTO>();


            // Register courier

            CreateMap<CourierModel, RegisterCourierRequestDTO>();

            // Update
            CreateMap<OrderModel, UpdateOrderRequestDTO>();

        }
    }
}
