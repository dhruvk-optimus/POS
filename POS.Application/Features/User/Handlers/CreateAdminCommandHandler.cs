using AutoMapper;
using MediatR;
using POS.Application.DTOs.User;
using POS.Application.Exceptions;
using POS.Application.Features.User.Commands;
using POS.Application.Interfaces.Repositories;
using POS.Application.Interfaces.Services;
using POS.Domain.Entities;
using POS.Domain.Enums;

public class CreateAdminHandler : IRequestHandler<CreateAdminCommand, UserResponseDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public CreateAdminHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<UserResponseDTO> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        UserEntity userEntity = _mapper.Map<UserEntity>(request.User);

        // verify user already exists
        UserEntity? existingUser = await _userRepository.GetByEmailAsync(userEntity.Email);

        if (existingUser != null)
        {
            throw new ApiException("User already exists", System.Net.HttpStatusCode.Conflict);
        }

        // hash password
        userEntity.Password = _passwordHasher.HashPassword(userEntity.Password);

        // set role to admin
        userEntity.Role = UserRole.Admin;

        // add user to database
        UserEntity newUser =  await _userRepository.AddAsync(userEntity);

        return _mapper.Map<UserResponseDTO>(newUser);
    }
}
