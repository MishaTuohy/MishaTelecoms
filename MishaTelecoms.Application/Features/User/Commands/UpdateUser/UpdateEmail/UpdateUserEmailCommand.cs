using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateEmail
{
    public class UpdateUserEmailCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string  Email {get;set;}
    }
}
