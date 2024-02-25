using Black_Swan_Application.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan_Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegisterationRequest request);
        Task<string> GetUserDetails(string name);
        Task<List<IdentityRole>> GetAllRoles();
    }
}
