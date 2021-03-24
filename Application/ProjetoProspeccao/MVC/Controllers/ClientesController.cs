using BLL.DTO.Cliente;
using BLL.DTO.Fluxo;
using BLL.Interfaces.Serrvices.PaisEstadoCidade;
using BLL.Interfaces.Services.Cliente;
using BLL.Interfaces.Services.Fluxo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _serviceCliente;
        private readonly IPaisEstadoCidadeService _servicePaisEstadoCidade;
        private readonly IFluxoService _serviceFluxo;

        public ClientesController(
            IClienteService serviceCliente,
            IPaisEstadoCidadeService servicePaisEstadoCidade,
            IFluxoService serviceFluxo)
        {
            _serviceCliente = serviceCliente;
            _servicePaisEstadoCidade = servicePaisEstadoCidade;
            _serviceFluxo = serviceFluxo;
        }

        [HttpPost]
        public IActionResult CadastrarCliente(ClienteCadastroDTO clienteCadastro)
        {
            if (ModelState.IsValid)
            {
                _serviceCliente.CadastrarCliente(clienteCadastro);
                return RedirectToAction("Clientes", "Home");
            }
            else
            {
                return View("../Home/CadastroCliente");
            }
        }

        [HttpGet]
        public IActionResult ObterEstado(int id)
        {
            var listaEstado = _servicePaisEstadoCidade.ListarEstado(id);
            return Json(listaEstado);
        }

        [HttpGet]
        public IActionResult ObterCidade(int id)
        {
            var listaCidade = _servicePaisEstadoCidade.ListarCidade(id);
            return Json(listaCidade);
        }

        [HttpGet]
        public IActionResult EnviarAnaliseGerencia(int id)
        {
            FluxoDTO fluxo = MontarFluxoDTO(id);

            _serviceFluxo.EnviarAnaliseGerencia(fluxo);
            return RedirectToAction("Clientes", "Home");
        }

        [HttpGet]
        public IActionResult AprovarFluxo(int id)
        {
            FluxoDTO fluxo = MontarFluxoDTO(id);

            _serviceFluxo.AprovarFluxo(fluxo);
            return RedirectToAction("Clientes", "Home");
        }

        [HttpGet]
        public IActionResult CorrecaoDeCadastro(int id)
        {
            FluxoDTO fluxo = MontarFluxoDTO(id);

            _serviceFluxo.CorrecaoDeCadastro(fluxo);
            return RedirectToAction("Clientes", "Home");
        }

        [HttpGet]
        public IActionResult ReprovarFluxo(int id)
        {
            FluxoDTO fluxo = MontarFluxoDTO(id);

            _serviceFluxo.ReprovarFluxo(fluxo);
            return RedirectToAction("Clientes", "Home");
        }

        private FluxoDTO MontarFluxoDTO(int id)
        {
            FluxoDTO fluxo = new FluxoDTO();
            fluxo.IdCliente = id;
            var idUsuario = User.Claims.First(c => c.Type == "IdUsuario").Value;
            fluxo.IdUsuario = Convert.ToInt32(idUsuario);
            return fluxo;
        }

        // Implementar devolver ao fluxo, cadastro corrigido, após ter feito um update
    }
}
