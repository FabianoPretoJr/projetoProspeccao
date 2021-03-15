using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class UsuarioDAL
    {
        Conexao con = new Conexao();

        public bool Autenticar(ref Usuario usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"SELECT * FROM Usuario WHERE login_usuario = @login AND senha = @senha AND ativo = 0";

                cmd.Parameters.AddWithValue("@login", usuario.Login);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);

                SqlDataReader dr = cmd.ExecuteReader();

                bool retorno;

                if(dr.HasRows)
                {
                    string login, senha;

                    dr.Read();
                    int id = Convert.ToInt32(dr["id_usuario"]);
                    login = dr["login_usuario"].ToString();
                    senha = dr["senha"].ToString();
                    usuario = new Usuario(id, login, senha);
                    dr.Close();

                    retorno = true;
                }
                else
                {
                    retorno = false;
                }

                con.Desconectar();
                return retorno;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Perfil> VerificarPerfil(Usuario usuario)
        {
            List<Perfil> list = new List<Perfil>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();

            cmd.CommandText = @"SELECT p.* FROM acesso a inner JOIN Usuario u ON (u.id_usuario = a.id_usuario) inner JOIN Perfil  p ON (p.id_perfil = a.id_perfil) WHERE a.id_usuario = @idUsuario";

            cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["id_perfil"]);
                string nome = dr["nome_perfil"].ToString();
                Perfil perfil = new Perfil(id, nome);
                list.Add(perfil);
            }

            con.Desconectar();
            return list;
        }
    }
}
