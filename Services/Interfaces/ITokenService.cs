using HRManagement.Models;

namespace HRManagement.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }
}

