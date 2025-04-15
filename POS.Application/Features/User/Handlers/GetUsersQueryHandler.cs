using AutoMapper;
using MediatR;
using POS.Application.DTOs.User;
using POS.Application.Features.User.Queries;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;

namespace POS.Application.Features.User.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserResponseDTO>>
    {
        private readonly IUserRepository _userRepository; // Added field for dependency injection
        private readonly IMapper _mapper; // Added field for AutoMapper

        public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponseDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            
            IEnumerable<UserEntity> users = await _userRepository.GetAllAsync(request.Role);

            
            IEnumerable<UserResponseDTO> userDtos = _mapper.Map<IEnumerable<UserResponseDTO>>(users);


            return userDtos; 
        }
    }
    
}
