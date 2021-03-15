using System.Data;
using System.Data.SqlClient;
using BLL;
using System;

namespace DAL
{
    public class PaisDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(Pais pais)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();

            cmd.CommandText = @"EXEC InserirNovoPais @nomePais";

            cmd.Parameters.Add("@nomePais", SqlDbType.VarChar).Value = pais.NomePais;

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Listar()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();

            cmd.CommandText = @"SELECT * FROM Pais";

            SqlDataReader aReader = cmd.ExecuteReader();

            while (aReader.Read())
            {
                Console.WriteLine("\n\nId: " + (int)aReader[0]);
                Console.WriteLine("Páis: " + (string)aReader[1]);
                Console.WriteLine("Ativo: " + (bool)aReader[2]);
            }

            con.Desconectar();
        }

        public void Atualizar(Pais pais)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();

            cmd.CommandText = @"EXEC AtualizarPais @idPais, @nomePais";

            cmd.Parameters.AddWithValue("@idPais", pais.Id);
            cmd.Parameters.AddWithValue("@nomePais", pais.NomePais);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Deletar(Pais pais)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();

            cmd.CommandText = @"EXEC DeletarPais @idPais";

            cmd.Parameters.AddWithValue("@idPais", pais.Id);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
    }
}
