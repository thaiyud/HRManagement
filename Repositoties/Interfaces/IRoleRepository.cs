using HRManagement.Models;
using System.Threading.Tasks;

namespace HRManagement.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByNameAsync(string roleName);
        Task<Role> CreateRoleAsync(Role role);
    }
}
