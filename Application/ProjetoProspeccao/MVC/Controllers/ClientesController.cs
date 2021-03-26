using BLL.DTO.Cliente;
using BLL.DTO.Fluxo;
using BLL.Interfaces.Serrvices.PaisEstadoCidade;
using BLL.Interfaces.Services.Cliente;
using BLL.Interfaces.Services.Fluxo;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Utils;
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
            try
            {
                if (ModelState.IsValid)
                {
                    var respostaCadastro = _serviceCliente.CadastrarCliente(clienteCadastro);
                    if (respostaCadastro != null)
                    {
                        ErrosView listaErros = new ErrosView();
                        listaErros.Erros.AddRange(Erros.ListarErros(respostaCadastro.Erros));
                        return View("../Home/ExibirErros", listaErros);
                    }

                    return RedirectToAction("Clientes", "Home");
                }
                else
                {
                    ViewBag.listaPais = _servicePaisEstadoCidade.ListarPais();
                    return View("../Home/CadastroCliente");
                }
            }
            catch(Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [HttpPost]
        public IActionResult AtualizarDadosClientes(ClienteCorrecaoDTO clienteCorrecao)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var respostaAtualizar = _serviceCliente.CorrigirCliente(clienteCorrecao);

                    if (respostaAtualizar != null)
                    {
                        ErrosView listaErros = new ErrosView();
                        listaErros.Erros.AddRange(Erros.ListarErros(respostaAtualizar.Erros));
                        return View("../Home/ExibirErros", listaErros);
                    }
                    else
                    {

                        FluxoDTO fluxo = MontarFluxoDTO(clienteCorrecao.IdCliente);
                        _serviceFluxo.DevolverCadastro(fluxo);
                 
                        return RedirectToAction("Clientes", "Home");
                    }
                }
                else
                {
                    ViewBag.listaPais = _servicePaisEstadoCidade.ListarPais();
                    ViewBag.listaEstado = _servicePaisEstadoCidade.ListarEstado(clienteCorrecao.IdPais);
                    ViewBag.listaCidade = _servicePaisEstadoCidade.ListarCidade(clienteCorrecao.IdEstado);
                    return View("../Home/CorrigirCadastro");
                }
            }
            catch(Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [HttpGet]
        public IActionResult ObterEstado(int id)
        {
            try
            {
                var listaEstado = _servicePaisEstadoCidade.ListarEstado(id);
                return Json(listaEstado);
            }
            catch(Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [HttpGet]
        public IActionResult ObterCidade(int id)
        {
            try
            {
                var listaCidade = _servicePaisEstadoCidade.ListarCidade(id);
                return Json(listaCidade);
            }
            catch(Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [HttpGet]
        public IActionResult EnviarAnaliseGerencia(int id)
        {
            try
            {
                FluxoDTO fluxo = MontarFluxoDTO(id);

                var respostaFluxo = _serviceFluxo.EnviarAnaliseGerencia(fluxo);

                if (respostaFluxo != null)
                {
                    ErrosView listaErros = new ErrosView();
                    listaErros.Erros.AddRange(Erros.ListarErros(respostaFluxo.Erros));
                    return View("../Home/ExibirErros", listaErros);
                }

                return RedirectToAction("Clientes", "Home");
            }
            catch(Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [HttpGet]
        public IActionResult AprovarFluxo(int id)
        {
            try
            {
                FluxoDTO fluxo = MontarFluxoDTO(id);

                var respostaFluxo = _serviceFluxo.AprovarFluxo(fluxo);

                if (respostaFluxo != null)
                {
                    ErrosView listaErros = new ErrosView();
                    listaErros.Erros.AddRange(Erros.ListarErros(respostaFluxo.Erros));
                    return View("../Home/ExibirErros", listaErros);
                }

                return RedirectToAction("Clientes", "Home");
            }
            catch (Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [HttpGet]
        public IActionResult CorrecaoDeCadastro(int id)
        {
            try
            {
                FluxoDTO fluxo = MontarFluxoDTO(id);

                var respostaFluxo = _serviceFluxo.CorrecaoDeCadastro(fluxo);

                if (respostaFluxo != null)
                {
                    ErrosView listaErros = new ErrosView();
                    listaErros.Erros.AddRange(Erros.ListarErros(respostaFluxo.Erros));
                    return View("../Home/ExibirErros", listaErros);
                }

                return RedirectToAction("Clientes", "Home");
            }
            catch (Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [HttpGet]
        public IActionResult ReprovarFluxo(int id)
        {
            try
            {
                FluxoDTO fluxo = MontarFluxoDTO(id);

                var respostaFluxo = _serviceFluxo.ReprovarFluxo(fluxo);

                if (respostaFluxo != null)
                {
                    ErrosView listaErros = new ErrosView();
                    listaErros.Erros.AddRange(Erros.ListarErros(respostaFluxo.Erros));
                    return View("../Home/ExibirErros", listaErros);
                }

                return RedirectToAction("Clientes", "Home");
            }
            catch (Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        [HttpGet]
        public IActionResult ExcluirCliente(int id)
        {
            try
            {
                ClienteExcluirDTO cliente = new ClienteExcluirDTO();
                cliente.IdCliente = id;
                cliente.IdUsuario = Convert.ToInt32(User.Claims.First(c => c.Type == "IdUsuario").Value);
                _serviceCliente.ExcluirCliente(cliente);

                return RedirectToAction("Clientes", "Home");
            }
            catch(Exception e)
            {
                ErrosView listaErros = new ErrosView();
                listaErros.Erros.Add(e.Message);
                return View("../Home/ExibirErros", listaErros);
            }
        }

        private FluxoDTO MontarFluxoDTO(int id)
        {
            FluxoDTO fluxo = new FluxoDTO();
            fluxo.IdCliente = id;
            var idUsuario = User.Claims.First(c => c.Type == "IdUsuario").Value;
            fluxo.IdUsuario = Convert.ToInt32(idUsuario);
            return fluxo;
        }
    }
}
