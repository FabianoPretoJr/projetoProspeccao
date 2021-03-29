using BLL.DTO.Usuario;
using BLL.Interfaces.DAL;
using BLL.Models;
using Data.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.EF
{
    public class UsuarioEF : IUsuarioDAL
    {
        private readonly DataContext _database;

        public UsuarioEF(DataContext database)
        {
            _database = database;
        }

        public bool Autenticar(ref UsuarioAutenticarDTO usuarioDTO)
        {
            bool retorno;
            try
            {
                var usuarioModel = new UsuarioModel(usuarioDTO.Login, usuarioDTO.Senha);

                var usuario = _database.Usuario.First(u => u.Login_Usuario == usuarioModel.Login_Usuario && u.Senha == usuarioModel.Senha && u.Ativo == false);
                
                if (usuario != null)
                {
                    usuarioDTO.IdUsuario = usuario.Id_Usuario;
                    usuarioDTO.Login = usuario.Login_Usuario;
                    usuarioDTO.Senha = usuario.Senha;

                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }

        public List<PerfilDeUsuarioDTO> ListarPerfilsDeUsuario(UsuarioAutenticarDTO usuarioDTO)
        {
            throw new NotImplementedException();
        }
    }
}
