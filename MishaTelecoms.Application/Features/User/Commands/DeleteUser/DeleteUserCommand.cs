using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
