using BLL.DTO.Fluxo;
using BLL.Interfaces.DAL;
using System;
using System.Data.SqlClient;

namespace DAL
{
    public class FluxoDAL : IFluxoDAL
    {
        Conexao con = new Conexao();

        public void AprovarFluxo(FluxoDTO fluxo)
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void CorrecaoDeCadastro(FluxoDTO fluxo)
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void DevolverCadastro(FluxoDTO fluxo)
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void EnviarAnaliseControleDeRisco(FluxoDTO fluxo)
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void EnviarAnaliseGerencia(FluxoDTO fluxo)
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
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ReprovarFluxo(FluxoDTO fluxo)
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
