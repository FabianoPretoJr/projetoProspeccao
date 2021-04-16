using BLL.DTO.Usuario;
using BLL.Interfaces.DAL;
using BLL.Models;
using Data.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data.Repository;
using System.Threading.Tasks;

namespace Data.EF
{
    public class UsuarioEF : BaseRepository<UsuarioModel>, IUsuarioDAL
    {
        private readonly DataContext _database;

        public UsuarioEF(DataContext database) : base(database)
        {
            _database = database;
        }

        public bool Autenticar(ref UsuarioAutenticarDTO usuarioDTO)
        {
            bool retorno;
            try
            {
                var usuarioModel = new UsuarioModel(usuarioDTO.Login, usuarioDTO.Senha);

                var usuario = _database.Usuario.FirstOrDefault(u => u.Login_Usuario.Equals(usuarioModel.Login_Usuario) && u.Senha.Equals(usuarioModel.Senha) && u.Ativo == false);
                
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
                var usuarioModel = new UsuarioModel(usuarioDTO.IdUsuario, usuarioDTO.Login, null);

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

        public List<ListaUsuariosDTO> Listar()
        {
            try
            {
                var listaUsuarios = _database.Usuario.Include(u => u.Acesso).ThenInclude(a => a.Perfil).ToList();

                var listaUsuarioDTO = new List<ListaUsuariosDTO>();
                foreach (var usuario in listaUsuarios)
                {
                    var usuarioDTO = new ListaUsuariosDTO();
                    usuarioDTO.Id = usuario.Id_Usuario;
                    usuarioDTO.Login = usuario.Login_Usuario;
                    usuarioDTO.Ativo = usuario.Ativo;
                    foreach (var acesso in usuario.Acesso)
                    {
                        var perfil = new PerfilDeUsuarioDTO();
                        perfil.IdPerfil = acesso.Perfil.Id_Perfil;
                        perfil.NomePerfil = acesso.Perfil.Nome_Perfil;
                        usuarioDTO.Perfils.Add(perfil);
                    }
                    listaUsuarioDTO.Add(usuarioDTO);
                }

                return listaUsuarioDTO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ListaUsuariosDTO Listar(int id)
        {
            try
            {
                var usuariosModel = _database.Usuario.Where(u => u.Id_Usuario.Equals(id))
                                                           .Include(u => u.Acesso)
                                                           .ThenInclude(a => a.Perfil)
                                                           .First();

                var usuarioDTO = new ListaUsuariosDTO();
                usuarioDTO.Id = usuariosModel.Id_Usuario;
                usuarioDTO.Login = usuariosModel.Login_Usuario;
                usuarioDTO.Ativo = usuariosModel.Ativo;
                foreach(var acesso in usuariosModel.Acesso)
                {
                    var perfil = new PerfilDeUsuarioDTO();
                    perfil.IdPerfil = acesso.Perfil.Id_Perfil;
                    perfil.NomePerfil = acesso.Perfil.Nome_Perfil;
                    usuarioDTO.Perfils.Add(perfil);
                }
                return usuarioDTO;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void Deletar(int id)
        {
            try
            {
                var usuario = _database.Usuario.FirstOrDefault(u => u.Id_Usuario.Equals(id));
                usuario.Desativar(usuario);
                _database.Update(usuario);
                _database.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<PerfilDeUsuarioDTO> ListarPerfils()
        {
            try
            {
                var listaPerfils = _database.Perfil.ToList();

                return null;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
