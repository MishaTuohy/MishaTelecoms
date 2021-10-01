using MishaTelecoms.Application.Dtos;
using System;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories.Users
{
    public interface IUserRepository : IRepository<ApplicationUserDto>
    {
        Task<ApplicationUserDto> GetByUserNameAsync(string UserName);
        Task<ApplicationUserDto> GetByEmailAsync(string Email);
        Task<ApplicationUserDto> GetByPhoneNumberAsync(string PhoneNumber);
        Task<bool> UpdateUserNameAsync(Guid Id, string UserName);
        Task<bool> UpdateNormalizedUserNameAsync(Guid Id, string NormalizedUserName);
        Task<bool> UpdateEmailAsync(Guid Id, string Email);
        Task<bool> UpdateNormalizedEmailAsync(Guid Id, string NormalizedEmail);
        Task<bool> UpdateEmailConfirmedAsync(Guid Id, bool EmailConfirmed);
        Task<bool> UpdatePhoneNumberAsync(Guid Id, string PhoneNumber);
        Task<bool> UpdatePhoneNumberConfirmedAsync(Guid Id, bool PhoneNumberConfirmed);
        Task<bool> UpdatePasswordHashAsync(Guid Id, string PasswordHash);
        Task<bool> UpdateTwoFactorEnabledAsync(Guid Id, bool TwoFactorEnabled);
    }
}
