using System.Net;
using AutoMapper;
using MediatR;
using POS.Application.DTOs.Authentication;
using POS.Application.Exceptions;
using POS.Application.Features.Authentication.Commands;
using POS.Application.Interfaces.Repositories;
using POS.Application.Interfaces.Services;
using POS.Domain.Entities;

namespace POS.Application.Features.Authentication.Handlers
{
    public class RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<RegisterUserCommand, AuthResponseDTO>
    {
        public async Task<AuthResponseDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            UserEntity userEntity = mapper.Map<UserEntity>(request.User);

            UserEntity? existingUser = await userRepository.GetByEmailAsync(userEntity.Email);

            if(existingUser is not null)
            {
                throw new ApiException("User with the email already exists.", HttpStatusCode.Conflict);
            }

            userEntity.Password = passwordHasher.HashPassword(userEntity.Password);
            userEntity.Role = Domain.Enums.UserRole.Customer;

            UserEntity createdUser = await userRepository.AddAsync(userEntity);

            string jwtToken = jwtTokenGenerator.GenerateToken(createdUser);

            AuthResponseDTO result = mapper.Map<AuthResponseDTO>(createdUser);
            result.Token = jwtToken;

            return result;
        }
    }
}
