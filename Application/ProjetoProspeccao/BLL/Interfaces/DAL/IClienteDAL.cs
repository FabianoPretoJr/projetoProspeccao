using BLL.DTO.Cliente;
using System.Collections.Generic;

namespace BLL.Interfaces.DAL
{
    public interface IClienteDAL
    {
        void CadastrarCliente(ClienteCadastroDTO cliente);
        IEnumerable<ClienteListagemDTO> ListarClientes();
    }
}
