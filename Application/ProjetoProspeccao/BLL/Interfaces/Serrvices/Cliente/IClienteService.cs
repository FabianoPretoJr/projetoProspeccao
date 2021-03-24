using BLL.DTO.Cliente;
using System.Collections.Generic;
using System.Security.Claims;

namespace BLL.Interfaces.Services.Cliente
{
    public interface IClienteService
    {
        ClienteCadastroResultadoDTO CadastrarCliente(ClienteCadastroDTO clienteCadastroDTO);
        IEnumerable<ClienteListagemDTO> ListarClientes();
        IEnumerable<ClienteListagemDTO> ListarClientes(IEnumerable<Claim> perfils);
    }
}