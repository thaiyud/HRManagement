using HRManagement.DTO;
using HRManagement.Models;
using HRManagement.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace HRManagement.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> CreateRoleAsync(RoleDTO roleDTO)
        {
            var existingRole = await _roleRepository.GetRoleByNameAsync(roleDTO.Name);
            if (existingRole != null)
            {
                throw new Exception("Role already exists.");
            }

            var role = new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = roleDTO.Name,
                NormalizedName = roleDTO.Name.ToUpper()
            };

            return await _roleRepository.CreateRoleAsync(role);
        }
    }
}
