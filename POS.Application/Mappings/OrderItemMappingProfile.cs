using AutoMapper;
using POS.Application.DTOs.OrderItem;
using POS.Domain.Entities;

namespace POS.Application.Mappings
{
    public class OrderItemMappingProfile : Profile
    {
        public OrderItemMappingProfile() {

            CreateMap<OrderItemEntity, OrderItemDTO>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name));


        }

    }
}
