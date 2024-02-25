using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace Black_Swan.MVC.Contracts
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(RegisterVM register);
        Task Logout();
        string GetCurrentUserName();
        Task<string> GetCurrentUserId();
        Task <List<IdentityRole>> GetRoles();
       
    }
}
