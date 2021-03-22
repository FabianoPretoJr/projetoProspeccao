using BLL.DTO.Cliente;
using BLL.Interfaces.DAL;
using System;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
