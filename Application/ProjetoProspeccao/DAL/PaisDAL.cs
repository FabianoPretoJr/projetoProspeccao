using System.Data;
using System.Data.SqlClient;
using BLL;

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
    }
}
