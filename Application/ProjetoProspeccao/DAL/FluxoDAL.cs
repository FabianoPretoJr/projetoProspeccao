using System;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class FluxoDAL
    {
        Conexao con = new Conexao();

        public void EnviarAnaliseGerencia(Fluxo fluxo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"EXEC EnviarAnaliseGerencia @idCliente, @idUsuario";

                cmd.Parameters.AddWithValue("@idCliente", fluxo.IdCliente);
                cmd.Parameters.AddWithValue("@idUsuario", fluxo.IdUsuario);

                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch(Exception e )
            {
                Console.WriteLine(e.Message);
            }
        }

        public void EnviarAnaliseControleDeRisco(Fluxo fluxo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"EXEC EnviarAnaliseControleDeRisco @idCliente, @idUsuario";

                cmd.Parameters.AddWithValue("@idCliente", fluxo.IdCliente);
                cmd.Parameters.AddWithValue("@idUsuario", fluxo.IdUsuario);

                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AprovarFluxo(Fluxo fluxo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"EXEC AprovarFluxo @idCliente, @idUsuario";

                cmd.Parameters.AddWithValue("@idCliente", fluxo.IdCliente);
                cmd.Parameters.AddWithValue("@idUsuario", fluxo.IdUsuario);

                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReprovarFluxo(Fluxo fluxo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"EXEC ReprovarFluxo @idCliente, @idUsuario";

                cmd.Parameters.AddWithValue("@idCliente", fluxo.IdCliente);
                cmd.Parameters.AddWithValue("@idUsuario", fluxo.IdUsuario);

                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CorrecaoDeCadastro(Fluxo fluxo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"EXEC CorrecaoDeCadastro @idCliente, @idUsuario";

                cmd.Parameters.AddWithValue("@idCliente", fluxo.IdCliente);
                cmd.Parameters.AddWithValue("@idUsuario", fluxo.IdUsuario);

                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DevolverCadastro(Fluxo fluxo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"EXEC DevolverCadastro @idCliente, @idUsuario";

                cmd.Parameters.AddWithValue("@idCliente", fluxo.IdCliente);
                cmd.Parameters.AddWithValue("@idUsuario", fluxo.IdUsuario);

                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
