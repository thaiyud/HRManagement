using HRManagement.DTO;
using HRManagement.Models;
using System.Threading.Tasks;

namespace HRManagement.Services
{
    public interface IRoleService
    {
        Task<Role> CreateRoleAsync(RoleDTO roleDTO);
    }
}
