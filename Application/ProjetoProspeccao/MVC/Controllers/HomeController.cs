using BLL.DTO.Fluxo;
using BLL.Enums;
using BLL.Interfaces.Serrvices.PaisEstadoCidade;
using BLL.Interfaces.Services.Cliente;
using BLL.Interfaces.Services.Fluxo;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Utils.GerarArquivos;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClienteService _serviceCliente;
        private readonly IPaisEstadoCidadeService _servicePaisEstadoCidade;
        private readonly IFluxoService _serviceFluxo;

        public HomeController(
            ILogger<HomeController> logger, 
            IClienteService serviceCliente,
            IPaisEstadoCidadeService servicePaisEstadoCidade,
            IFluxoService serviceFluxo)
        {
            _logger = logger;
            _serviceCliente = serviceCliente;
            _servicePaisEstadoCidade = servicePaisEstadoCidade;
            _serviceFluxo = serviceFluxo;
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
                var perfils = User.Claims.Where(c => c.Type == "IdPerfil").ToList();
                var idUsuario = Convert.ToInt32(User.Claims.First(c => c.Type == "IdUsuario").Value);
                var listaCliente = _serviceCliente.ListarClientes(perfils, idUsuario);
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
        public IActionResult Fluxo()
        {
            try
            {
                var listaFluxo = _serviceFluxo.ListagemFluxo();
                return View(listaFluxo);
            }
            catch(Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [Authorize]
        public IActionResult FiltrarFluxo(ListaFluxoDTO filtrosFluxo)
        {
            try
            {
                var listaFluxo = _serviceFluxo.ListagemFluxo(filtrosFluxo);
                return View("../Home/Fluxo", listaFluxo);
            }
            catch (Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult ExportarExcel(ListaFluxoDTO filtrosFluxo)
        {
            try
            {
                var listaFluxo = _serviceFluxo.ListagemFluxo(filtrosFluxo);
                var stream = Excel.GerarArquivo(listaFluxo);
                string fileName = $"FluxoClientes_{DateTime.Now}.xlsx";
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            catch (Exception e)
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

        [Authorize(Policy = "CadastroCorrecaoCliente")]
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

        [Authorize(Policy = "CadastroCorrecaoCliente")]
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
    }
}
