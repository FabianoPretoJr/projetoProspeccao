using BLL.DTO.Cliente;
using BLL.Enums;
using BLL.Interfaces.DAL;
using BLL.Models;
using Data.Conexao;
using Data.Validacoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.EntityFramework.Plus;

namespace Data.EF
{
    public class ClienteEF : IClienteDAL
    {
        private readonly DataContext _database;

        public ClienteEF(DataContext database)
        {
            _database = database;
        }

        public void CadastrarCliente(ClienteCadastroDTO cliente)
        {
            throw new NotImplementedException();
        }

        public void CorrigirCliente(ClienteCorrecaoDTO cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteListagemDTO> ListarClientes(int[] idsStatus, int idUsuario)
        {
            try
            {
                var clientes = _database.Cliente.Select(c => c.Analises.OrderByDescending(a => a.Data_Hora).First())
                                                .Where(a => idsStatus.Contains(a.Id_Status) && (a.Id_Usuario != idUsuario || a.Id_Status == (int)EStatus.Cadastrado))
                                                .Select(a => a.Cliente)
                                                .ToList();

                List<ClienteListagemDTO> listaCliente = new List<ClienteListagemDTO>();

                foreach(var cli in clientes)
                {
                    ClienteListagemDTO cliente = new ClienteListagemDTO();

                    cliente.Id = cli.Id_Cliente;
                    cliente.Nome = cli.Nome;
                    cliente.CPF = cli.Cpf;
                    cliente.RG = cli.Rg;
                    cliente.DataNascimento = cli.Data_Nascimento;
                    cliente.Email = cli.Email;
                    cliente.IdStatus = cli.Id_Status;

                    listaCliente.Add(cliente);
                }

                return listaCliente;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ClienteCorrecaoDTO ObterDadosCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteListagemDTO> ListarClientesEncerrados()
        {
            try
            {
                var clientesEncerrados = _database.Cliente.Where(c => c.Id_Status == (int)EStatus.aprovado_gerencia ||
                                                                 c.Id_Status == (int)EStatus.aprovado_controle_risco ||
                                                                 c.Id_Status == (int)EStatus.reprovado).ToList();

                List<ClienteListagemDTO> listaCliente = new List<ClienteListagemDTO>();

                foreach(var clienteEncerrado in clientesEncerrados)
                {
                    ClienteListagemDTO cliente = new ClienteListagemDTO();

                    cliente.Id = clienteEncerrado.Id_Cliente;
                    cliente.Nome = clienteEncerrado.Nome;
                    cliente.CPF = clienteEncerrado.Cpf;
                    cliente.RG = clienteEncerrado.Rg;
                    cliente.DataNascimento = clienteEncerrado.Data_Nascimento;
                    cliente.Email = clienteEncerrado.Email;
                    cliente.IdStatus = clienteEncerrado.Id_Status;

                    listaCliente.Add(cliente);
                }

                return listaCliente;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ExcluirCliente(ClienteExcluirDTO cliente) // precisa testar
        {
            try
            {
                var clienteCompleto = Valida.Cliente(_database, cliente.IdCliente);
                Valida.Usuario(_database, cliente.IdUsuario);

                if(clienteCompleto.Id_Status == (int)EStatus.Cadastrado)
                {
                    var analises = clienteCompleto.Analises.ToList();
                    _database.Analise.RemoveRange(analises);
                    _database.SaveChanges();

                    var telefones = clienteCompleto.Telefones.ToList();
                    _database.Telefone.RemoveRange(telefones);
                    _database.SaveChanges();

                    var enderecos = clienteCompleto.Enderecos.ToList();
                    _database.Endereco.RemoveRange(enderecos);
                    _database.SaveChanges();

                    _database.Remove(clienteCompleto);
                    _database.SaveChanges();
                }
                else
                    throw new ArgumentException(message: "Este cliente não está em fase de cadastro");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
