using BLL.DTO.Cliente;
using System.Collections.Generic;
using System.Security.Claims;

namespace BLL.Interfaces.Services.Cliente
{
    public interface IClienteService
    {
        ClienteCadastroResultadoDTO CadastrarCliente(ClienteCadastroDTO clienteCadastroDTO);
        ClienteCorrecaoDTO ObterDadosCliente(int idCliente);
        ClienteCorrecaoResultadoDTO CorrigirCliente(ClienteCorrecaoDTO cliente);
        IEnumerable<ClienteListagemDTO> ListarClientesEncerrados();
        IEnumerable<ClienteListagemDTO> ListarClientes(IEnumerable<Claim> perfils, int idUsuario);
        void ExcluirCliente(ClienteExcluirDTO cliente);
    }
}