using BLL.Interfaces.Serrvices.PaisEstadoCidade;
using BLL.Interfaces.Services.Cliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }

        public IActionResult Clientes()
        {
            var listaCliente = _serviceCliente.ListarClientes();
            return View(listaCliente);
        }

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
