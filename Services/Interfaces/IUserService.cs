using HRManagement.DTO;
using HRManagement.Models;
using System.Threading.Tasks;

namespace HRManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> SignInAsync(SignInDTO signInDTO);
        Task<User> SignUpAsync(SignUpDTO signUpDTO);
    }
}
    