using BLL.DTO.Usuario;
using BLL.Interfaces.DAL;
using BLL.Models;
using Data.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

                var usuario = _database.Usuario.FirstOrDefault(u => u.Login_Usuario == usuarioModel.Login_Usuario && u.Senha == usuarioModel.Senha && u.Ativo == false);
                
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
            List<PerfilDeUsuarioDTO> list = new List<PerfilDeUsuarioDTO>();
            try
            {
                var usuarioModel = new UsuarioModel(usuarioDTO.IdUsuario, usuarioDTO.Login, usuarioDTO.Senha);

                var perfils = _database.Acesso.Where(a => a.Id_Usuario == usuarioModel.Id_Usuario).Include(a => a.Perfil).ToList();          

                foreach(var perfil in perfils)
                {
                    PerfilDeUsuarioDTO perfilDeUsuarioDTO = new PerfilDeUsuarioDTO();
                    perfilDeUsuarioDTO.IdPerfil = perfil.Perfil.Id_Perfil;
                    perfilDeUsuarioDTO.NomePerfil = perfil.Perfil.Nome_Perfil;
                    list.Add(perfilDeUsuarioDTO);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }
    }
}
