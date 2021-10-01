using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;
using System.Collections.Generic;

namespace MishaTelecoms.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<Response<IReadOnlyList<ApplicationUserDto>>>
    {
    }
}
