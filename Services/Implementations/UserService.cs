using HRManagement.DTO;
using HRManagement.Models;
using HRManagement.Repositories.Interfaces;
using HRManagement.Services.Interfaces;
using BCrypt.Net;
using System;
using System.Threading.Tasks;

namespace HRManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string> SignInAsync(SignInDTO signInDTO)
        {
            var user = await _userRepository.GetUserByUsernameAsync(signInDTO.Username);
            if (user == null || !VerifyPassword(user.PasswordHash, signInDTO.Password))
            {
                throw new Exception("Invalid username or password.");
            }
            return _tokenService.GenerateJwtToken(user);
        }

        public async Task<User> SignUpAsync(SignUpDTO signUpDTO)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(signUpDTO.Username);
            if (existingUser != null)
            {
                throw new Exception("Username is already taken.");
            }

            var newUser = new User
            {
Id = Guid.NewGuid().ToString(), // Generate GUID here
                UserName = signUpDTO.Username,
                NormalizedUserName = signUpDTO.Username.ToUpper(),
                PasswordHash = HashPassword(signUpDTO.Password),
                FirstName = signUpDTO.FirstName,
                LastName = signUpDTO.LastName,
                Email = signUpDTO.Email,
                NormalizedEmail = signUpDTO.Email?.ToUpper(),
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                SecurityStamp = Guid.NewGuid().ToString() 
            };

            return await _userRepository.AddUserAsync(newUser);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }
    }
}
