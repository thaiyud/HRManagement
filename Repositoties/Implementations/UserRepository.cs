using HRManagement.Models;
using HRManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HRManagement.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly HrmanagementContext _context;

        public UserRepository(HrmanagementContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
