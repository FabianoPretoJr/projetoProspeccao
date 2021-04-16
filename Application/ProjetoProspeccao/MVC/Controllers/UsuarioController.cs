using BLL.DTO.Usuario;
using BLL.Interfaces.Services.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVC.Models;
using System.Linq;
using MVC.Utils;
using BLL.Models;

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
            try
            {
                if (ModelState.IsValid)
                {
                    var respostaAutenticarUsuario = _serviceUsuario.Autenticar(ref usuario);

                    if(respostaAutenticarUsuario.Erros.Count() > 0)
                    {
                        ErrosView listaErros = new ErrosView();
                        listaErros.Erros.AddRange(Erros.ListarErros(respostaAutenticarUsuario.Erros));
                        return View("../Home/ExibirErros", listaErros);
                    }
                    else
                    {
                        if (respostaAutenticarUsuario.RetornoAutenticacaoUsuario)
                        {
                            var respostaPerfilUsuario = _serviceUsuario.ListarPerfilsDeUsuario(usuario);

                            if (respostaPerfilUsuario.Erros.Count() > 0)
                            {
                                ErrosView listaErros = new ErrosView();
                                listaErros.Erros.AddRange(Erros.ListarErros(respostaPerfilUsuario.Erros));
                                return View("../Home/ExibirErros", listaErros);
                            }
                            else
                            {
                                Login(usuario, respostaPerfilUsuario);
                                return RedirectToAction("Clientes", "Home");
                            }
                        }
                        else
                        {
                            ViewBag.AcessoNegado = "Acesso negado";
                            return View("../Home/Index");
                        }
                    }
                }
                else
                {
                    return View("../Home/Index");
                }
            }
            catch(Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async void Login(UsuarioAutenticarDTO usuario, ListaPerfilsDeUsuarioResultadoDTO respostaPerfilUsuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Login),
                new Claim("IdUsuario", usuario.IdUsuario.ToString())
            };
            foreach (var perfil in respostaPerfilUsuario.PerfilsDeUsuario)
            {
                var claim = new Claim("IdPerfil", perfil.IdPerfil.ToString());
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

        public IActionResult Cadastrar(UsuarioModel usuario)
        {
            try
            {
                _serviceUsuario.Cadastrar(usuario);
                return View("../Home/Usuarios");
            }
            catch (Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }
    }
}
