using BLL.DTO.Cliente;
using System.Collections.Generic;

namespace BLL.Interfaces.DAL
{
    public interface IClienteDAL
    {
        void CadastrarCliente(ClienteCadastroDTO cliente);
        IEnumerable<ClienteListagemDTO> ListarClientes();
        IEnumerable<ClienteListagemDTO> ListarClientes(int idStatus);
        IEnumerable<ClienteListagemDTO> ListarClientes(int idStatus1, int idStatus2);
    }
}
