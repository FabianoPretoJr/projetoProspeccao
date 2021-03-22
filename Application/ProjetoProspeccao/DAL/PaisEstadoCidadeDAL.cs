using BLL.DTO.PaisEstadoCidade;
using BLL.Interfaces.DAL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class PaisEstadoCidadeDAL : IPaisEstadoCidadeDAL
    {
        Conexao con = new Conexao();

        public List<ListarPaisEstadoCidadeDTO> ListagemPaisEstadoCidade()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"SELECT * FROM PaisEstadoCidade";

                SqlDataReader dr = cmd.ExecuteReader();

                List<ListarPaisEstadoCidadeDTO> lista = new List<ListarPaisEstadoCidadeDTO>();

                while (dr.Read())
                {
                    ListarPaisEstadoCidadeDTO paisEstadoCidade = new ListarPaisEstadoCidadeDTO();

                    paisEstadoCidade.Pais = dr["Pais"].ToString();
                    paisEstadoCidade.Estado = dr["Estado"].ToString();
                    paisEstadoCidade.Cidade = dr["Cidade"].ToString();
                    paisEstadoCidade.IdCidade = Convert.ToInt32(dr["IdCidade"]);
                    lista.Add(paisEstadoCidade);
                }

                con.Desconectar();
                return lista;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<PaisModel> ListarPais()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"SELECT * FROM Pais";

                SqlDataReader dr = cmd.ExecuteReader();

                List<PaisModel> lista = new List<PaisModel>();

                while (dr.Read())
                {
                    int idPais = Convert.ToInt32(dr["id_pais"]);
                    string nomePais = dr["nome_pais"].ToString();
                    PaisModel pais = new PaisModel(idPais, nomePais);
                    lista.Add(pais);
                }

                con.Desconectar();
                return lista;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<EstadoModel> ListarEstado(int idPais)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"SELECT * FROM Estado WHERE id_pais = @idPais";

                cmd.Parameters.AddWithValue("@idPais", idPais);

                SqlDataReader dr = cmd.ExecuteReader();

                List<EstadoModel> lista = new List<EstadoModel>();

                while (dr.Read())
                {
                    int idEstado = Convert.ToInt32(dr["id_estado"]);
                    string nomeEstado = dr["nome_estado"].ToString();
                    EstadoModel estado = new EstadoModel(idEstado, nomeEstado, idPais);
                    lista.Add(estado);
                }

                con.Desconectar();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CidadeModel> ListarCidade(int idEstado)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"SELECT * FROM Cidade WHERE id_estado = @idEstado";

                cmd.Parameters.AddWithValue("@idEstado", idEstado);

                SqlDataReader dr = cmd.ExecuteReader();

                List<CidadeModel> lista = new List<CidadeModel>();

                while (dr.Read())
                {
                    int idCidade = Convert.ToInt32(dr["id_cidade"]);
                    string nomeCidade = dr["nome_cidade"].ToString();
                    CidadeModel cidade = new CidadeModel(idCidade, nomeCidade, idEstado);
                    lista.Add(cidade);
                }

                con.Desconectar();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
