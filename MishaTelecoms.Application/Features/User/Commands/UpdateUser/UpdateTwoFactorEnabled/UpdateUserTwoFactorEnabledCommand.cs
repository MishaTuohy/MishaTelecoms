using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateTwoFactorEnabled
{
    public class UpdateUserTwoFactorEnabledCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
