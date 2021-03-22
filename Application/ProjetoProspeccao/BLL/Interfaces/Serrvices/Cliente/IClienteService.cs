using BLL.DTO.Cliente;
using System.Collections.Generic;

namespace BLL.Interfaces.Services.Cliente
{
    public interface IClienteService
    {
        ClienteCadastroResultadoDTO CadastrarCliente(ClienteCadastroDTO clienteCadastroDTO);
        IEnumerable<ClienteListagemDTO> ListarClientes();
    }
}