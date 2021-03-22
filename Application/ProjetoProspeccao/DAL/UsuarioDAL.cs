using BLL.DTO.Usuario;
using BLL.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL : IUsuarioDAL
    {
        Conexao con = new Conexao();

        public bool Autenticar(ref UsuarioAutenticarDTO usuario)
        {
            bool retorno;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"SELECT * FROM Usuario WHERE login_usuario = @login AND senha = @senha AND ativo = 0";

                cmd.Parameters.AddWithValue("@login", usuario.Login);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    usuario.IdUsuario = Convert.ToInt32(dr["id_usuario"]);
                    usuario.Login = dr["login_usuario"].ToString();
                    usuario.Senha = dr["senha"].ToString();
                    dr.Close();

                    retorno = true;
                }
                else
                {
                    retorno = false;
                }

                con.Desconectar();
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }

        public List<PerfilDeUsuarioDTO> ListarPerfilsDeUsuario(UsuarioAutenticarDTO usuario)
        {
            List<PerfilDeUsuarioDTO> list = new List<PerfilDeUsuarioDTO>();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conectar();

                cmd.CommandText = @"SELECT p.* FROM acesso a inner JOIN Usuario u ON (u.id_usuario = a.id_usuario) inner JOIN Perfil  p ON (p.id_perfil = a.id_perfil) WHERE a.id_usuario = @idUsuario";

                cmd.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    PerfilDeUsuarioDTO perfilDeUsuarioDTO = new PerfilDeUsuarioDTO();
                    perfilDeUsuarioDTO.IdPerfil = Convert.ToInt32(dr["id_perfil"]);
                    perfilDeUsuarioDTO.NomePerfil = dr["nome_perfil"].ToString();
                    list.Add(perfilDeUsuarioDTO);
                }

                con.Desconectar();
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }
    }
}
