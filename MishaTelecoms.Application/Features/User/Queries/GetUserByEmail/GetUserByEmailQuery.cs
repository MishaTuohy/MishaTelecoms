using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;

namespace MishaTelecoms.Application.Features.User.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<Response<ApplicationUserDto>>
    {
        public string Email { get; set; }
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
