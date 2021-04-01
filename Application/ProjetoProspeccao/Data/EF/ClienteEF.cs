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
            try
            {
                var usuario = Valida.Usuario(_database, cliente.IdUsuario);
                int idStatus = (int)EStatus.Cadastrado;

                var telefone = new TelefoneModel(cliente.NumeroTelefone);
                var endereco = new EnderecoModel(cliente.Cep, cliente.Rua, cliente.Numero, cliente.Complemento, cliente.Bairro, cliente.IdCidade);
                var analise = new AnaliseModel(idStatus, usuario.Id_Usuario);
                var clienteModel = new ClienteModel(cliente.Nome, cliente.Cpf, cliente.Rg, cliente.DataNascimento, cliente.Email, idStatus, telefone, endereco, analise);

                _database.Add(clienteModel);
                _database.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CorrigirCliente(ClienteCorrecaoDTO cliente)
        {
            try
            {
                var usuario = Valida.Usuario(_database, cliente.IdUsuario);

                var telefone = new TelefoneModel(cliente.IdTelefone, cliente.NumeroTelefone, cliente.IdCliente);
                var endereco = new EnderecoModel(cliente.IdEndereco, cliente.Cep, cliente.Rua, cliente.Numero, cliente.Complemento, cliente.Bairro, cliente.IdCidade, cliente.IdCliente);
                var clienteModel = new ClienteModel(cliente.IdCliente, cliente.Nome, cliente.Cpf, cliente.Rg, cliente.DataNascimento, cliente.Email, (int)EStatus.correcao_cadastro, telefone, endereco);

                _database.Update(clienteModel);
                _database.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<ClienteListagemDTO> ListarClientes(int[] idsStatus, int idUsuario)
        {
            try
            {
                // Query pra trazer somente clientes que e posso mexer como usuário
                // var clientes = _database.Cliente.Select(c => c.Analises.OrderByDescending(a => a.Id_Analise).First()) // se der erro muda pra id_analise
                //                                 .Where(a => idsStatus.Contains(a.Id_Status) && (a.Id_Usuario != idUsuario || a.Id_Status == (int)EStatus.Cadastrado))
                //                                 .Select(a => a.Cliente)
                //                                 .ToList();

                // Query que eu trago todos usuários, mas não vou permirir mexer em alguns caso eu seja o ultimo que mexeu nele
                var clientes = _database.Cliente.Where(c => idsStatus.Contains(c.Id_Status))
                                                .IncludeFilter(c => c.Analises.OrderByDescending(a => a.Id_Analise).First());

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
                    cliente.UsuarioPermitido = cli.Analises.First().Id_Usuario != idUsuario || 
                                               cli.Analises.First().Id_Status == (int)EStatus.Cadastrado ? true : false;

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
            try
            {
                var clienteCompleto = Valida.Cliente(_database, idCliente);

                ClienteCorrecaoDTO cliente = new ClienteCorrecaoDTO();

                cliente.IdCliente = clienteCompleto.Id_Cliente;
                cliente.Nome = clienteCompleto.Nome;
                cliente.Cpf = clienteCompleto.Cpf;
                cliente.Rg = clienteCompleto.Rg;
                cliente.DataNascimento = clienteCompleto.Data_Nascimento;
                cliente.Email = clienteCompleto.Email;

                foreach(var telefone in clienteCompleto.Telefones)
                {
                    cliente.IdTelefone = telefone.Id_Telefone;
                    cliente.NumeroTelefone = telefone.Numero_Telefone;
                }

                foreach(var endereco in clienteCompleto.Enderecos)
                {
                    cliente.IdEndereco = endereco.Id_Endereco;
                    cliente.Cep = endereco.Cep;
                    cliente.Rua = endereco.Rua;
                    cliente.Numero = endereco.Numero;
                    cliente.Complemento = endereco.Complemento;
                    cliente.Bairro = endereco.Bairro;
                    cliente.IdCidade = endereco.Cidade.Id_Cidade;
                    cliente.IdEstado = endereco.Cidade.Estado.Id_Estado;
                    cliente.IdPais = endereco.Cidade.Estado.Pais.Id_Pais;
                }

                return cliente;
            }
            catch (Exception e)
            {
                throw e;
            }
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

        public void ExcluirCliente(ClienteExcluirDTO cliente)
        {
            try
            {
                var clienteCompleto = Valida.Cliente(_database, cliente.IdCliente);
                Valida.Usuario(_database, cliente.IdUsuario);

                if(clienteCompleto.Id_Status == (int)EStatus.Cadastrado)
                {
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
