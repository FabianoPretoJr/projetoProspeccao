using BLL.Interfaces.Serrvices.PaisEstadoCidade;
using BLL.Interfaces.Services.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClienteService _serviceCliente;
        private readonly IPaisEstadoCidadeService _servicePaisEstadoCidade;

        public HomeController(
            ILogger<HomeController> logger, 
            IClienteService serviceCliente,
            IPaisEstadoCidadeService servicePaisEstadoCidade)
        {
            _logger = logger;
            _serviceCliente = serviceCliente;
            _servicePaisEstadoCidade = servicePaisEstadoCidade;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Clientes", "Home");
            else
                return View();
        }

        [Authorize]
        public IActionResult Clientes()
        {
            try
            {
                var perfils = User.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
                var listaCliente = _serviceCliente.ListarClientes(perfils);
                return View(listaCliente);
            }
            catch(Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [Authorize]
        public IActionResult ClientesEncerrados()
        {
            try
            {
                var listaCliente = _serviceCliente.ListarClientesEncerrados();
                return View(listaCliente);
            }
            catch(Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [Authorize(Roles = "2")]
        public IActionResult CadastroCliente()
        {
            try
            {
                ViewBag.listaPais = _servicePaisEstadoCidade.ListarPais();
                return View();
            }
            catch (Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [Authorize(Roles = "2")]
        public IActionResult CorrigirCadastro(int id)
        {
            try
            {
                var dadosCliente = _serviceCliente.ObterDadosCliente(id);
                ViewBag.listaPais = _servicePaisEstadoCidade.ListarPais();
                ViewBag.listaEstado = _servicePaisEstadoCidade.ListarEstado(dadosCliente.IdPais);
                ViewBag.listaCidade = _servicePaisEstadoCidade.ListarCidade(dadosCliente.IdEstado);
                return View(dadosCliente);
            }
            catch (Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        public IActionResult ExibirErros(ErrosView listaErros)
        {
            return View(listaErros);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[Authorize(Roles = "2")]
        //public IActionResult ClientesOperacao()
        //{
        //    var perfils = User.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
        //    var listaCliente = _serviceCliente.ListarClientes(perfils);
        //    return View(listaCliente);
        //}

        //[Authorize(Roles = "3")]
        //public IActionResult ClientesGerencia()
        //{
        //    var perfils = User.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
        //    var listaCliente = _serviceCliente.ListarClientes(perfils);
        //    return View(listaCliente);
        //}

        //[Authorize(Roles = "4")]
        //public IActionResult ClientesGerenciaControleRisco()
        //{
        //    var perfils = User.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
        //    var listaCliente = _serviceCliente.ListarClientes(perfils);
        //    return View(listaCliente);
        //}
    }
}
