using BLL.DTO.Cliente;
using BLL.Enums;
using BLL.Interfaces.DAL;
using BLL.Interfaces.Services.Cliente;
using BLL.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BLL.Service.Cliente
{
    public class ClienteService : IClienteService
    {
        private IClienteDAL _clienteDAL;

        public ClienteService(IClienteDAL clienteDAL)
        {
            _clienteDAL = clienteDAL;
        }

        public ClienteCadastroResultadoDTO CadastrarCliente(ClienteCadastroDTO cliente)
        {
            var erros = ValidacaoService.ValidarErros(cliente);
            ClienteCadastroResultadoDTO clienteCadastroResultado = new ClienteCadastroResultadoDTO();
            if (erros.Count() > 0)
            {
                clienteCadastroResultado.Erros.AddRange(erros);
                return clienteCadastroResultado;
            }
            else
            {
                _clienteDAL.CadastrarCliente(cliente);
                return null;
            }
        }

        public ClienteCorrecaoDTO ObterDadosCliente(int idCliente)
        {
            return _clienteDAL.ObterDadosCliente(idCliente);
        }

        public ClienteCorrecaoResultadoDTO CorrigirCliente(ClienteCorrecaoDTO cliente)
        {
            var erros = ValidacaoService.ValidarErros(cliente);
            ClienteCorrecaoResultadoDTO clienteCorrecaoResultado = new ClienteCorrecaoResultadoDTO();
            if (erros.Count() > 0)
            {
                clienteCorrecaoResultado.Erros.AddRange(erros);
                return clienteCorrecaoResultado;
            }
            else
            {
                _clienteDAL.CorrigirCliente(cliente);
                return null;
            }
        }

        public IEnumerable<ClienteListagemDTO> ListarClientes(IEnumerable<Claim> perfils, int idUsuario)
        {
            List<int> idsStatus = new List<int>(); 

            if (perfils.Any(p => p.Value == ((int)EPerfil.Administracao).ToString()))
            {
                idsStatus.Add((int)EStatus.Cadastrado);
                idsStatus.Add((int)EStatus.analise_gerencia);
                idsStatus.Add((int)EStatus.analise_controle_risco);
                idsStatus.Add((int)EStatus.correcao_cadastro);
            }
            if (perfils.Any(p => p.Value == ((int)EPerfil.Operacao).ToString()))
            {
                idsStatus.Add((int)EStatus.Cadastrado);
                idsStatus.Add((int)EStatus.correcao_cadastro);
            }
            if (perfils.Any(p => p.Value == ((int)EPerfil.Gerencia).ToString()))
                idsStatus.Add((int)EStatus.analise_gerencia);
            if (perfils.Any(p => p.Value == ((int)EPerfil.Controle_de_risco).ToString()))
                idsStatus.Add((int)EStatus.analise_controle_risco);

            return _clienteDAL.ListarClientes(idsStatus.Distinct().ToArray(), idUsuario);
        }

        public IEnumerable<ClienteListagemDTO> ListarClientesEncerrados()
        {
            var listaClientes = _clienteDAL.ListarClientesEncerrados();
            return listaClientes;
        }

        public void ExcluirCliente(ClienteExcluirDTO cliente)
        {
            _clienteDAL.ExcluirCliente(cliente);
        }
    }
}
