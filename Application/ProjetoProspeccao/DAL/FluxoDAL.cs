using BLL.DTO.Fluxo;
using BLL.Interfaces.DAL;
using BLL.Models;
using System;
using System.Collections.Generic;
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
                throw e;
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
                throw e;
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
                throw e;
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
                throw e;
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
                throw e;
            }
        }

        public ListaFluxoDTO ListagemFluxo()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"SELECT c.id_cliente, c.nome, c.cpf, c.rg, c.data_nascimento, c.email, st.id_status, st.nome_status, u.id_usuario, u.login_usuario, a.id_analise, a.data_hora
                                    FROM Analise a 
	                                    INNER JOIN Usuario u ON (u.id_usuario = a.id_usuario)
	                                    INNER JOIN Cliente C ON (c.id_cliente = a.id_cliente)
	                                    INNER JOIN StatusAnalise st ON (st.id_status = a.id_status)";

                SqlDataReader dr = cmd.ExecuteReader();

                var listaFluxo = new ListaFluxoDTO();
                while (dr.Read())
                {
                    int id_Cliente = Convert.ToInt32(dr["id_cliente"]);
                    string nome = dr["nome"].ToString();
                    string cpf = dr["cpf"].ToString();
                    string rg = dr["rg"].ToString();
                    DateTime data_Nascimento = Convert.ToDateTime(dr["data_nascimento"]);
                    string email = dr["email"].ToString();
                    var cliente = new ClienteModel(id_Cliente, nome, cpf, rg, data_Nascimento, email);

                    int id_Status = Convert.ToInt32(dr["id_status"]);
                    string nome_Status = dr["nome_status"].ToString();
                    var status = new StatusAnaliseModel(id_Status, nome_Status);

                    int id_Usuario = Convert.ToInt32(dr["id_usuario"]);
                    string login_Usuario = dr["login_usuario"].ToString();
                    var usuario = new UsuarioModel(id_Usuario, login_Usuario, null);

                    int id_analise = Convert.ToInt32(dr["id_analise"]);
                    DateTime data_Hora = Convert.ToDateTime(dr["data_hora"]);

                    var analise = new AnaliseModel(id_analise, cliente, usuario, status, data_Hora);
                    listaFluxo.ListaAnaliseModel.Add(analise);
                }

                con.Desconectar();
                return listaFluxo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
