using BLL.DTO.Cliente;
using BLL.Interfaces.DAL;
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
                cmd.Parameters.AddWithValue("@cep", cliente.Cep);
                cmd.Parameters.AddWithValue("@rua", cliente.Rua);
                cmd.Parameters.AddWithValue("@numero", cliente.Numero);
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

        public IEnumerable<ClienteListagemDTO> ListarClientes()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"SELECT * FROM Cliente";

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
    }
}
