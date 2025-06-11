using AutoMapper;
using DeliveryAPI.Common.Interfaces;
using DeliveryAPI.Common.Models;
using DeliveryAPI.Data.Models;
using DeliveryAPI.DTO.Common;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryAPI.MappingProfiles
{
    public class DTOMappringProfile : Profile
    {
        public DTOMappringProfile()
        {
            // Common

            CreateMap<OrderEntity, OrderDTO>()
                .ForMember(x => x.CancellationReason,
                opt => opt.MapFrom(x => x.OrderDetails != null 
                ? x.OrderDetails.CancellationReason
                : null));

            CreateMap<OrderDTO, OrderEntity>();
            CreateMap<OrderEntity, OrderShortDTO>();

            CreateMap<CourierEntity, CourierDTO>();
            CreateMap<CourierDTO, CourierEntity>();
            CreateMap<CourierEntity, CourierShortDTO>();

            CreateMap<BaseFailedOperationResult, OperationResultDTO>();
            CreateMap<SuccessOperationResult, OperationResultDTO>();

            CreateMap<OrderStatusInfo, OrderStatusInfoDTO>();

            CreateMap<CreateEntityOperationResult<Guid>, CreateEntityOperationResultDTO<Guid>>();


            CreateMap<IOperationResult, ActionResult<IOperationResult>>()
                .ConstructUsing((operationResult, context) => operationResult switch
                {
                    NotFoundOperationResult => new NotFoundObjectResult(context.Mapper.Map<OperationResultDTO>(operationResult)),
                    InvalidRequestOperationResult => new BadRequestObjectResult(context.Mapper.Map<OperationResultDTO>(operationResult)),
                    CreateEntityOperationResult<Guid> => new OkObjectResult(context.Mapper.Map<CreateEntityOperationResultDTO<Guid>>(operationResult)),
                    _ => new OkObjectResult(context.Mapper.Map<OperationResultDTO>(operationResult))
                });


            // Paged results

            CreateMap<PagedResult<OrderEntity>, PagedResponseDTO<OrderDTO>>();
            CreateMap<PagedResult<CourierEntity>, PagedResponseDTO<CourierDTO>>();

        }
    }
}
