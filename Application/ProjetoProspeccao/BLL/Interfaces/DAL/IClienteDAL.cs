using BLL.DTO.Cliente;
using System.Collections.Generic;

namespace BLL.Interfaces.DAL
{
    public interface IClienteDAL
    {
        void CadastrarCliente(ClienteCadastroDTO cliente);
        ClienteCorrecaoDTO ObterDadosCliente(int idCliente);
        void CorrigirCliente(ClienteCorrecaoDTO cliente);
        void AtualizarTelefones(ClienteCorrecaoDTO cliente);
        IEnumerable<ClienteListagemDTO> ListarClientesEncerrados();
        IEnumerable<ClienteListagemDTO> ListarClientes(int[] idsStatus, int idUsuario);
        void ExcluirCliente(ClienteExcluirDTO cliente);
    }
}
