using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePhoneNumberConfirmed
{
    public class UpdateUserPhoneNumberConfirmedCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
    }
}
