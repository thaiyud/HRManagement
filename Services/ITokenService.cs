using HRManagement.Models;

namespace HRManagement.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }
}

