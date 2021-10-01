using MishaTelecoms.Application.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MishaTelecoms.Application.Interfaces.Repositories.Users
{
    public interface IUserRoleRepository : IUserRepository
    {
        Task AddToRoleAsync(ApplicationUserDto user, string roleName, CancellationToken cancellationToken);
        Task<IList<string>> GetRolesAsync(ApplicationUserDto user, CancellationToken cancellationToken);
        Task<IList<ApplicationUserDto>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken);
        Task<bool> IsInRoleAsync(ApplicationUserDto user, string roleName, CancellationToken cancellationToken);
        Task RemoveFromRoleAsync(ApplicationUserDto user, string roleName, CancellationToken cancellationToken);
    }
}