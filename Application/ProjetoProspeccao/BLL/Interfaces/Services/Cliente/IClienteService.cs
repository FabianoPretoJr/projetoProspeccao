﻿using BLL.DTO.Cliente;

namespace BLL.Interfaces.Services.Cliente
{
    public interface IClienteService
    {
        void CadastrarCliente(ClienteCadastroDTO clienteCadastroDTO);
    }
}
