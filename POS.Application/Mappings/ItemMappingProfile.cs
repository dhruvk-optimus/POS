using AutoMapper;
using POS.Application.DTOs.Item;
using POS.Domain.Entities;

namespace POS.Application.Mappings
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            // AddItemRequestDTO -> ItemEntity
            CreateMap<AddItemRequestDTO, ItemEntity>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => Guid.NewGuid())); // Setting the ItemId to be new GUID

            // UpdateItemRequestDTO -> ItemEntity
            CreateMap<UpdateItemRequestDTO, ItemEntity>();

            // ItemEntity -> ItemResponseDTO
            CreateMap<ItemEntity, ItemResponseDTO>();
        }
    }
}
