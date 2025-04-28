using AutoMapper;
using POS.Application.DTOs.Authentication;
using POS.Application.DTOs.User;
using POS.Domain.Entities;

namespace POS.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() { 
            CreateMap<RegisterUserRequestDTO, UserEntity>();
            CreateMap<UserEntity, AuthResponseDTO>();
            CreateMap<CreateUserRequestDTO, UserEntity>();
            CreateMap<UserEntity, UserResponseDTO>();

        }



}
}
