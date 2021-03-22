using BLL.DTO.Cliente;
using BLL.Interfaces.Serrvices.PaisEstadoCidade;
using BLL.Interfaces.Services.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _serviceCliente;
        private readonly IPaisEstadoCidadeService _servicePaisEstadoCidade;

        public ClientesController(
            IClienteService serviceCliente,
            IPaisEstadoCidadeService servicePaisEstadoCidade)
        {
            _serviceCliente = serviceCliente;
            _servicePaisEstadoCidade = servicePaisEstadoCidade;
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
    }
}
