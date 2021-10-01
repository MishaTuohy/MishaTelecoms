using MediatR;
using MishaTelecoms.Application.Wrappers;
using System;

namespace MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateAll
{
    public class UpdateUserAllCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
