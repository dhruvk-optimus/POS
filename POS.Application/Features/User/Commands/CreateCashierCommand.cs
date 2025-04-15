using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POS.Application.DTOs.User;

namespace POS.Application.Features.User.Commands
{
    public record CreateCashierCommand(CreateUserRequestDTO Cashier) : IRequest<UserResponseDTO>;
}
