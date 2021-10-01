using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;

namespace MishaTelecoms.Application.Features.User.Queries.GetUserByUserName
{
    public class GetUserByUserNameQuery : IRequest<Response<ApplicationUserDto>>
    {
        public string UserName { get; set; }
        public GetUserByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
