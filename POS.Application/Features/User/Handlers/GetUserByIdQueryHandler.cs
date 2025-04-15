using System.Net;
using AutoMapper;
using MediatR;
using POS.Application.DTOs.User;
using POS.Application.Exceptions;
using POS.Application.Features.User.Queries;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;

namespace POS.Application.Features.User.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<

        GetUserByIdQuery,
        UserResponseDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserResponseDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            UserEntity? user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ApiException("User not found", HttpStatusCode.NotFound);
            }
            return _mapper.Map<UserResponseDTO>(user);
        }
    }

}
