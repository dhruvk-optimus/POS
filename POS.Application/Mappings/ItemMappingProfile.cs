using AutoMapper;
using POS.Application.DTOs.Item;
using POS.Domain.Entities;

namespace POS.Application.Mappings
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            
            CreateMap<AddItemRequestDTO, ItemEntity>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => Guid.NewGuid())); 

            CreateMap<UpdateItemRequestDTO, ItemEntity>();

            CreateMap<ItemEntity, ItemResponseDTO>();
        }
    }
}
