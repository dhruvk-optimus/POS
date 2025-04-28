using AutoMapper;
using POS.Application.DTOs.Order;
using POS.Domain.Entities;

namespace POS.Application.Mappings
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderEntity, OrderDTO> ()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.CreatedAt));


            CreateMap<OrderEntity, OrderSummaryDTO>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<OrderEntity, OrderDetailsDTO>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.CreatedAt));
               
        }

    }
}
