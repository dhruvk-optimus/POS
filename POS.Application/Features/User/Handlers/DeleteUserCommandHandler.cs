using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POS.Application.Exceptions;
using POS.Application.Features.User.Commands;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;

namespace POS.Application.Features.User.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            UserEntity? user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ApiException("User not found", HttpStatusCode.NotFound);
            }
            await _userRepository.DeleteAsync(user.UserId);
        }
    }
    
}
