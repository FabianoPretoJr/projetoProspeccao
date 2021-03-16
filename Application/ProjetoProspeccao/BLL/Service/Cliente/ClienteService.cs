using BLL.DTO.Cliente;
using BLL.Interfaces.DAL;
using BLL.Interfaces.Services.Cliente;
using System;

namespace BLL.Service.Cliente
{
    public class ClienteService : IClienteService
    {
        private IClienteDAL _clienteDAL;

        public ClienteService(IClienteDAL clienteDAL)
        {
            _clienteDAL = clienteDAL;
        }

        public void CadastrarCliente(ClienteCadastroDTO cliente)
        {
            try
            {
                _clienteDAL.CadastrarCliente(cliente);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
