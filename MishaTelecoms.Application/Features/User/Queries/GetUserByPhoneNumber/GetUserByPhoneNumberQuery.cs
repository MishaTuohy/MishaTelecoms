using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;

namespace MishaTelecoms.Application.Features.User.Queries.GetUserByPhoneNumber
{
    public class GetUserByPhoneNumberQuery : IRequest<Response<ApplicationUserDto>>
    {
        public string PhoneNumber { get; set; }
        public GetUserByPhoneNumberQuery(string phoneNumber )
        {
            PhoneNumber = phoneNumber;
        }
    }
}
