using Formula1.Data.Entities;
using Formula1.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Formula1.MVC.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpContext _context;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor.HttpContext!;
        }

        public async Task LogarUsuario(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await _context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties()
            {
                IsPersistent = false,
                ExpiresUtc = DateTime.Now.AddHours(1)
            });
        }

        public async Task DeslogarUsuario()
        {
            await _context.SignOutAsync();
        }
    }
}