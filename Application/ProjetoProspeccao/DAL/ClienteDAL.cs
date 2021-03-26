using BLL.DTO.Cliente;
using BLL.Interfaces.DAL;
using DAL.Extensoes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class ClienteDAL : IClienteDAL
    {
        Conexao con = new Conexao();

        public void CadastrarCliente(ClienteCadastroDTO cliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"EXEC CadastroCliente @nome, @cpf, @rg, @dataNascimento, @email, @numeroTelefone, @cep, @rua, @numero, @complemento, @bairro, @idCidade, @idUsuario";
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@rg", cliente.Rg);
                cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@numeroTelefone", cliente.NumeroTelefone);
                if(cliente.Cep == null)
                    cmd.Parameters.AddWithValue("@cep", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@cep", cliente.Cep);
                cmd.Parameters.AddWithValue("@rua", cliente.Rua);
                cmd.Parameters.AddWithValue("@numero", cliente.Numero);
                if (cliente.Complemento == null)
                    cmd.Parameters.AddWithValue("@complemento", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@complemento", cliente.Complemento);
                cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@idCidade", cliente.IdCidade);
                cmd.Parameters.AddWithValue("@idUsuario", cliente.IdUsuario);

                cmd.ExecuteNonQuery();
                con.Desconectar();
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
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = "EXEC RetornarClienteCompleto @idCliente";

                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                SqlDataReader dr = cmd.ExecuteReader();

                ClienteCorrecaoDTO cliente = new ClienteCorrecaoDTO();

                if (dr.HasRows)
                {
                    dr.Read();

                    cliente.IdCliente = Convert.ToInt32(dr["id_cliente"]);
                    cliente.Nome = dr["nome"].ToString();
                    cliente.Cpf = dr["cpf"].ToString();
                    cliente.Rg = dr["rg"].ToString();
                    cliente.DataNascimento = Convert.ToDateTime(dr["data_nascimento"]);
                    cliente.Email = dr["email"].ToString();
                    cliente.IdTelefone = Convert.ToInt32(dr["id_telefone"]);
                    cliente.NumeroTelefone = dr["numero_telefone"].ToString();
                    cliente.IdEndereco = Convert.ToInt32(dr["id_endereco"]);
                    cliente.Cep = dr["cep"].ToString();
                    cliente.Rua = dr["rua"].ToString();
                    cliente.Numero = dr["numero"].ToString();
                    cliente.Complemento = dr["complemento"].ToString();
                    cliente.Bairro = dr["bairro"].ToString();
                    cliente.IdCidade = Convert.ToInt32(dr["id_cidade"]);
                    cliente.IdEstado = Convert.ToInt32(dr["id_estado"]);
                    cliente.IdPais = Convert.ToInt32(dr["id_pais"]);

                    dr.Close();
                }

                con.Desconectar();
                return cliente;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void CorrigirCliente(ClienteCorrecaoDTO cliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = "EXEC AtualizarCliente @idCliente, @nome, @cpf, @rg, @dataNascimento, @email";
                cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@rg", cliente.Rg);
                cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "EXEC AtualizarTelefone @idTelefone, @numeroTelefone, @idCliente";
                cmd.Parameters.AddWithValue("@idTelefone", cliente.IdTelefone);
                cmd.Parameters.AddWithValue("@numeroTelefone", cliente.NumeroTelefone);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "EXEC AtualizarEndereco @idEndereco, @cep, @rua, @numero, @complemento, @bairro, @idCliente, @idCidade";
                cmd.Parameters.AddWithValue("@idEndereco", cliente.IdEndereco);
                cmd.Parameters.AddWithValue("@cep", cliente.Cep);
                cmd.Parameters.AddWithValue("@rua", cliente.Rua);
                cmd.Parameters.AddWithValue("@numero", cliente.Numero);
                cmd.Parameters.AddWithValue("@complemento", cliente.Complemento);
                cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@idCidade", cliente.IdCidade);
                cmd.ExecuteNonQuery();

                con.Desconectar();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<ClienteListagemDTO> ListarClientes(int[] idsStatus)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();         

                cmd.CommandText = @"SELECT * FROM Cliente WHERE id_status IN (@idsStatus)";

                cmd.AddArrayParameters("@idsStatus", idsStatus);

                SqlDataReader dr = cmd.ExecuteReader();
          
                List<ClienteListagemDTO> listaCliente = new List<ClienteListagemDTO>();

                while (dr.Read())
                {
                    ClienteListagemDTO cliente = new ClienteListagemDTO();

                    cliente.Id = Convert.ToInt32(dr["id_cliente"]);
                    cliente.Nome = dr["nome"].ToString();
                    cliente.CPF = dr["cpf"].ToString();
                    cliente.RG = dr["rg"].ToString();
                    cliente.DataNascimento = Convert.ToDateTime(dr["data_nascimento"]);
                    cliente.Email = dr["email"].ToString();
                    cliente.IdStatus = Convert.ToInt32(dr["id_status"]);

                    listaCliente.Add(cliente);
                }

                con.Desconectar();
                return listaCliente;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<ClienteListagemDTO> ListarClientesEncerrados()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"SELECT * FROM Cliente WHERE id_status = 3 OR id_status = 5 OR id_status = 6";

                SqlDataReader dr = cmd.ExecuteReader();

                List<ClienteListagemDTO> listaCliente = new List<ClienteListagemDTO>();

                while (dr.Read())
                {
                    ClienteListagemDTO cliente = new ClienteListagemDTO();

                    cliente.Id = Convert.ToInt32(dr["id_cliente"]);
                    cliente.Nome = dr["nome"].ToString();
                    cliente.CPF = dr["cpf"].ToString();
                    cliente.RG = dr["rg"].ToString();
                    cliente.DataNascimento = Convert.ToDateTime(dr["data_nascimento"]);
                    cliente.Email = dr["email"].ToString();
                    cliente.IdStatus = Convert.ToInt32(dr["id_status"]);

                    listaCliente.Add(cliente);
                }

                con.Desconectar();
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
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = "EXEC ExcluirCliente @idCliente, @idUsuario";

                cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@idUsuario", cliente.IdUsuario);

                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
