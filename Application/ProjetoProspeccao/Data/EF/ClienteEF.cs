using BLL.DTO.Cliente;
using BLL.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
    public class ClienteEF : IClienteDAL
    {
        public void CadastrarCliente(ClienteCadastroDTO cliente)
        {
            throw new NotImplementedException();
        }

        public void CorrigirCliente(ClienteCorrecaoDTO cliente)
        {
            throw new NotImplementedException();
        }

        public void ExcluirCliente(ClienteExcluirDTO cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteListagemDTO> ListarClientes(int[] idsStatus, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteListagemDTO> ListarClientesEncerrados()
        {
            throw new NotImplementedException();
        }

        public ClienteCorrecaoDTO ObterDadosCliente(int idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
