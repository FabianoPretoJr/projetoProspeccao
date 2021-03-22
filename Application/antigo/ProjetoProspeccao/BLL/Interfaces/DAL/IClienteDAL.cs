using BLL.DTO.Cliente;

namespace BLL.Interfaces.DAL
{
    public interface IClienteDAL
    {
        void CadastrarCliente(ClienteCadastroDTO cliente);
    }
}