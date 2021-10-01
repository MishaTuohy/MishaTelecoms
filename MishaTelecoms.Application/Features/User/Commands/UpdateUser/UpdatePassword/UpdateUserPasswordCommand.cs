using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePassword
{
    public class UpdateUserPasswordCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
    }
}
