using BLL.DTO.Usuario;
using BLL.Interfaces.Services.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _serviceUsuario;

        public UsuarioController(IUsuarioService serviceUsuario)
        {
            _serviceUsuario = serviceUsuario;
        }

        [HttpPost]
        public IActionResult Autenticar(UsuarioAutenticarDTO usuario)
        {
            if(ModelState.IsValid)
            {
                var respostaAutenticarUsuario = _serviceUsuario.Autenticar(ref usuario);
                if (respostaAutenticarUsuario.RetornoAutenticacaoUsuario)
                {
                    Login(usuario);
                    return RedirectToAction("Clientes", "Home");
                }
                else
                    return View("../Home/Index");
            }
            else
            {
                return View("../Home/Index");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async void Login(UsuarioAutenticarDTO usuario)
        {
            var respostaPerfilUsuario = _serviceUsuario.ListarPerfilsDeUsuario(usuario);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Login),
                new Claim("IdUsuario", usuario.IdUsuario.ToString())
            };
            foreach (var perfil in respostaPerfilUsuario.PerfilsDeUsuario)
            {
                var claim = new Claim(ClaimTypes.Role, perfil.IdPerfil.ToString());
                claims.Add(claim);
            }

            var identidadeDeUsuario = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);

            var propriedadesDeAutenticacao = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(2),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
        }
    }
}
