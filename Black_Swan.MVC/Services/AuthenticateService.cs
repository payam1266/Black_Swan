using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Black_Swan.MVC.Models;
using System;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace Black_Swan.MVC.Services
{
    public class AuthenticateService : BaseHttpService, IAuthenticateService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        public AuthenticateService(IClient client,IlocalStorageService localStorageService,IHttpContextAccessor httpContextAccessor)
            :base(client, localStorageService)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();


        }
        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest authenticateRequest = new()
                {
                    Email = email,
                    Password = password
                };
                var authenticateResponse = await _client.LoginAsync(authenticateRequest);
                if (authenticateResponse.Token != string.Empty)
                {
                    var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(authenticateResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, user);

                    _localStorage.SetStorageValue("token", authenticateResponse.Token);

                    return true;
                }

                return false;


            }
            catch
            {

                return false;
            }
           
        }

        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string>() { "token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(RegisterVM register)
        {
            RegisterationRequest registrationRequest = new()
            {
                Email =register.Email,
                Password =register.Password ,
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName = register.UserName,
            };
            var response = await _client.RegisterAsync(registrationRequest);
            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }

            return false;
        }
        public string GetCurrentUserName()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim?.Value ?? string.Empty;
        }
        private IList<Claim> ParseClaims(JwtSecurityToken token)
        {
            var claims = token.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, token.Subject));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, token.Subject));
            return claims;
        }

        public async Task< string> GetCurrentUserId()
        {
            var userName = GetCurrentUserName();
            return await _client.GetUserIdAsync(userName);
        }

        public async Task<List<IdentityRole>> GetRoles()
        {
           var roles=await _client.GetRolesAsync();
            return (List<IdentityRole>)roles;
        }
    }
}
