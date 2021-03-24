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

        public IEnumerable<ClienteListagemDTO> ListarClientes()
        {
            var listaClientes = _clienteDAL.ListarClientes();
            return listaClientes;
        }

        public IEnumerable<ClienteListagemDTO> ListarClientes(IEnumerable<Claim> perfils)
        {
            if (perfils.Any(p => p.Value == ((int)EPerfil.Operacao).ToString()))
                return _clienteDAL.ListarClientes(1, 7);
            else if (perfils.Any(p => p.Value == ((int)EPerfil.Gerencia).ToString()))
                return _clienteDAL.ListarClientes(2);
            else if (perfils.Any(p => p.Value == ((int)EPerfil.Controle_de_risco).ToString()))
                return _clienteDAL.ListarClientes(4);
            else
                return null; // ARRUMA ISSO DEPOIS
        }
    }
}
