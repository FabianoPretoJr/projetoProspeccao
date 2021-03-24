using BLL.Interfaces.Serrvices.PaisEstadoCidade;
using BLL.Interfaces.Services.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
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

        //public IActionResult Dashboard()
        //{
        //    return View();
        //}

        [Authorize]
        public IActionResult Clientes()
        {
            var perfils = User.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
            var listaCliente = _serviceCliente.ListarClientes(perfils);
            return View(listaCliente);
        }

        [Authorize(Roles = "2")]
        public IActionResult CadastroCliente()
        {
            ViewBag.listaPais = _servicePaisEstadoCidade.ListarPais();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
