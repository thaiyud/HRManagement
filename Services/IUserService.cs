using HRManagement.Models;
using HRManagement.DTO;

namespace HRManagement.Services
{
    public interface IUserService
    {
        Task<User> SignUpAsync(SignUpDTO signUpDTO);
        Task<string> SignInAsync(SignInDTO signInDTO);
    }
}
