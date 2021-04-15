using BLL.DTO.Cliente;
using BLL.Enums;
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

                cmd.CommandText = @"EXEC CadastroCliente @nome, @cpf, @rg, @dataNascimento, @email, @cep, @rua, @numero, @complemento, @bairro, @idCidade, @idUsuario";
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@rg", cliente.Rg);
                cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
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

                SqlDataReader dr =  cmd.ExecuteReader();
                dr.Read();
                int idCliente = Convert.ToInt32(dr["id_cliente"]);
                dr.Close();

                foreach(var telefone in cliente.NumeroTelefone)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "EXEC InserirTelefone @numeroTelefone, @idCliente";

                    cmd.Parameters.AddWithValue("@numeroTelefone", telefone);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    cmd.ExecuteNonQuery();
                }
               
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

                cmd.CommandText = "SELECT * FROM Telefone WHERE id_cliente = @idCliente";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var telefoneDTO = new TelefoneDTO();
                    telefoneDTO.IdTelefone = Convert.ToInt32(dr["id_telefone"]);
                    telefoneDTO.NumeroTelefone = dr["numero_telefone"].ToString();
                    cliente.NumeroTelefone.Add(telefoneDTO);
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

                foreach(var telefone in cliente.NumeroTelefone)
                {
                    cmd.Parameters.Clear();

                    cmd.CommandText = "EXEC AtualizarTelefone @idTelefone, @numeroTelefone, @idCliente";

                    cmd.Parameters.AddWithValue("@idTelefone", telefone.IdTelefone);
                    cmd.Parameters.AddWithValue("@numeroTelefone", telefone.NumeroTelefone);
                    cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);

                    cmd.ExecuteNonQuery();
                }               

                cmd.CommandText = "EXEC AtualizarEndereco @idEndereco, @cep, @rua, @numero, @complemento, @bairro, @idCliente, @idCidade";
                cmd.Parameters.AddWithValue("@idEndereco", cliente.IdEndereco);
                if (cliente.Cep == null)
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
                cmd.ExecuteNonQuery();

                con.Desconectar();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<ClienteListagemDTO> ListarClientes(int[] idsStatus, int idUsuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                // Query pra trazer somente clientes que e posso mexer como usuário
                // cmd.CommandText = @"SELECT * FROM Cliente c 
                //                     WHERE id_status IN (@idsStatus) AND 
                //                           NOT EXISTS(SELECT * FROM Analise a 
                //                                      WHERE c.id_cliente = a.id_cliente AND
                //                                            (id_usuario = @idUsuario AND (c.id_status <> 7 AND c.id_status <> 1)))";
                // cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                // Query que eu trago todos usuários, mas não vou permirir mexer em alguns caso eu seja o ultimo que mexeu nele
                cmd.CommandText = @"SELECT * FROM Cliente cli
	                                    INNER JOIN Endereco e ON (e.id_cliente = cli.id_cliente) 
	                                    INNER JOIN Cidade c ON (c.id_cidade = e.id_cidade)
                                        INNER JOIN Estado es ON (es.id_estado = c.id_estado)
                                        INNER JOIN Pais p ON (p.id_pais = es.id_pais)
	                                    INNER JOIN Analise a ON (a.id_cliente = cli.id_cliente)
                                    WHERE cli.id_status IN (@idsStatus) AND a.id_analise IN (SELECT MAX(a.id_analise) FROM Analise a GROUP BY(a.id_cliente))";

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
                    cliente.UsuarioPermitido = Convert.ToInt32(dr["id_usuario"]) != idUsuario ||
                                               Convert.ToInt32(dr["id_status"]) == (int)EStatus.Cadastrado ? true : false;
                    cliente.NomePais = dr["nome_pais"].ToString();

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

                cmd.CommandText = @"SELECT * FROM Endereco e
	                                    INNER JOIN Cliente cli ON (cli.id_cliente = e.id_cliente) 
	                                    INNER JOIN Cidade c ON (c.id_cidade = e.id_cidade)
                                        INNER JOIN Estado es ON (es.id_estado = c.id_estado)
                                        INNER JOIN Pais p ON (p.id_pais = es.id_pais)
                                    WHERE cli.id_status = 3 OR cli.id_status = 5 OR cli.id_status = 6;";

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
                    cliente.NomePais = dr["nome_pais"].ToString();

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

        public void AtualizarTelefones(ClienteCorrecaoDTO cliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"DELETE FROM Telefone WHERE id_cliente = @idCliente AND id_telefone NOT IN (@idsTelefones)";

                cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);

                var idsTelefones = new List<int>();
                foreach(var telefone in cliente.NumeroTelefone)
                {
                    idsTelefones.Add(telefone.IdTelefone);
                }
                cmd.AddArrayParameters("@idsTelefones", idsTelefones);

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
