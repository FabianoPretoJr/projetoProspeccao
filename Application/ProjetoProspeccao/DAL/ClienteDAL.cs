using System;
using BLL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ClienteDAL
    {
        Conexao con = new Conexao();

        public void CadastrarUsuario(Cliente cliente, Telefone telefone, Endereco endereco, Usuario usuario)
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
                cmd.Parameters.AddWithValue("@numeroTelefone", telefone.NumeroTelefone);
                cmd.Parameters.AddWithValue("@cep", endereco.Cep);
                cmd.Parameters.AddWithValue("@rua", endereco.Rua);
                cmd.Parameters.AddWithValue("@numero", endereco.Numero);
                cmd.Parameters.AddWithValue("@complemento", endereco.Complemento);
                cmd.Parameters.AddWithValue("@bairro", endereco.Bairro);
                cmd.Parameters.AddWithValue("@idCidade", endereco.IdCidade);
                cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);

                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
