using HRManagement.Models;
using System.Threading.Tasks;

namespace HRManagement.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> AddUserAsync(User user);
    }
}
