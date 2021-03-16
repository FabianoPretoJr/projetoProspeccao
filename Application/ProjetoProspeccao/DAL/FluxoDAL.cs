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
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
            }
        }
    }
}
