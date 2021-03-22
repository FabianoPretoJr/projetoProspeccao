using BLL.DTO.Cliente;
using BLL.Interfaces.DAL;
using BLL.Interfaces.Services.Cliente;
using BLL.Validacoes;
using System.Linq;

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
            if(erros.Count() > 0)
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
    }
}
