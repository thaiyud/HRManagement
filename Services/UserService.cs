using HRManagement.DTO;
using HRManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using BCrypt.Net;

namespace HRManagement.Services
{
    public class UserService : IUserService
    {
        private readonly HrmanagementContext _context;
        private readonly ITokenService _tokenService;

        public UserService(HrmanagementContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<User> SignUpAsync(SignUpDTO signUpDTO)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == signUpDTO.Username);
            if (existingUser != null)
            {
                throw new Exception("Username is already taken.");
            }

            var newUser = new User
            {
                Username = signUpDTO.Username,
                // Hash the password before storing it in the database (use a password hashing library)
                PasswordHash = HashPassword(signUpDTO.Password),
                FirstName = signUpDTO.FirstName,
                LastName = signUpDTO.LastName,
                Email = signUpDTO.Email,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<string> SignInAsync(SignInDTO signInDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == signInDTO.Username);
            if (user == null || !VerifyPassword(user.PasswordHash, signInDTO.Password))
            {
                throw new Exception("Invalid username or password.");
            }
            return _tokenService.GenerateJwtToken(user);

            
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
