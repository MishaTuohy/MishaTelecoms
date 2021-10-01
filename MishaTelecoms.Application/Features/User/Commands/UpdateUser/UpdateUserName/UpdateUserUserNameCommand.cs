using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateUserName
{
    public class UpdateUserUserNameCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
