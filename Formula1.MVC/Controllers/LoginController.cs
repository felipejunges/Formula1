using Formula1.Domain.Interfaces.Repositories;
using Formula1.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Formula1.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public LoginController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public IActionResult Index()
        {
            if (!_usuariosRepository.ValidarPossuiUsuario())
                return RedirectToAction(nameof(Cadastro));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var usuario = _usuariosRepository.ObterUsuarioLogin(model.Email!, model.Senha!);

                if (usuario == null)
                    ModelState.AddModelError("", "E-mail e/ou senha inválidos.");
                else
                {
                    // TODO: mover para um UsuarioService
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Name, usuario.Nome)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties()
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTime.Now.AddHours(1)
                    });

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(CadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = model.MapUsuario();

                await _usuariosRepository.IncluirUsuario(usuario);

                // TODO: poderia receber o redirecturl
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}