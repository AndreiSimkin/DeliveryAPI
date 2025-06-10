using AutoMapper;
using DeliveryDesktop.Models;
using DeliveryDesktop.ViewModels;
using DeliveryDesktop.ViewModels.Controls;

namespace DeliveryDesktop.MappingProfiles
{
    public class ModelsMappringProfile : Profile
    {
        public ModelsMappringProfile()
        {
            // View models <-> Model

            CreateMap<OrderModel, OrderCardViewModel>()
                .ForMember(o => o.Data, opt => opt.MapFrom(x => x));

            CreateMap<OrderModel, EditOrderViewModel>();

            CreateMap<CreateOrderViewModel, OrderModel>();
            CreateMap<EditOrderViewModel, OrderModel>();

            CreateMap<RegisterCourierViewModel, CourierModel>();
        }
    }
}
