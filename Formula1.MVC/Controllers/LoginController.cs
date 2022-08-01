using Formula1.Domain.Interfaces.Repositories;
using Formula1.Domain.Interfaces.Services;
using Formula1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Formula1.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IUsuariosRepository _usuariosRepository;

        public LoginController(ILoginService loginService, IUsuariosRepository usuariosRepository)
        {
            _loginService = loginService;
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
                    await _loginService.LogarUsuario(usuario);

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
            await _loginService.DeslogarUsuario();

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

                await _loginService.LogarUsuario(usuario);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}