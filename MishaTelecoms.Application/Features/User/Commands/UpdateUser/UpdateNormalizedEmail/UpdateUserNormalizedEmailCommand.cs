using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateNormalizedEmail
{
    public class UpdateUserNormalizedEmailCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string NormalizedEmail { get; set; }
    }
}
