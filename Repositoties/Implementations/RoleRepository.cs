using HRManagement.Models;
using HRManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HRManagement.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HrmanagementContext _context;

        public RoleRepository(HrmanagementContext context)
        {
            _context = context;
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }
    }
}
