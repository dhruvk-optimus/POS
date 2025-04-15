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
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponseDTO>


    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }


        public async Task<AuthResponseDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // 0. get the user
            UserEntity? existingUser = await _userRepository.GetByEmailAsync(request.User.Email);

            if (existingUser is null)
            {
                throw new ApiException("User does not exist.", HttpStatusCode.NotFound);
            }

            // 1. verify password

            bool verifyPassword = _passwordHasher.VerifyPassword(existingUser.Password, request.User.Password);

            if(!verifyPassword)
            {
                throw new ApiException("Invalid Credentials", HttpStatusCode.Unauthorized);
            }



            // 2. generate jwt

            string jwtToken = _jwtTokenGenerator.GenerateToken(existingUser);

            AuthResponseDTO result = _mapper.Map<AuthResponseDTO>(existingUser);
            result.Token = jwtToken;
            return result;
            
        }

         

    }
}
