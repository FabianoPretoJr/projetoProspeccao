using BLL.DTO.Cliente;

namespace BLL.Interfaces.Services.Cliente
{
    public interface IClienteService
    {
        ClienteCadastroResultadoDTO CadastrarCliente(ClienteCadastroDTO clienteCadastroDTO);
    }
}
