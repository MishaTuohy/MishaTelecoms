using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateNormalizedUserName
{
    public class UpdateUserNormalizedUserNameCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string NormalizedUserName { get; set; }
    }
}
