using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<Response<ApplicationUserDto>>
    {
        public Guid Id { get; }
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
