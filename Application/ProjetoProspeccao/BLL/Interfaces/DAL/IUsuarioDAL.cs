using BLL.DTO.Usuario;
using BLL.Interfaces.Repository;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.DAL
{
    public interface IUsuarioDAL : IRepository<UsuarioModel>
    {
        bool Autenticar(ref UsuarioAutenticarDTO usuarioDTO);
        List<PerfilDeUsuarioDTO> ListarPerfilsDeUsuario(UsuarioAutenticarDTO usuarioDTO);
        List<PerfilDeUsuarioDTO> ListarPerfils();
        List<ListaUsuariosDTO> Listar();
        ListaUsuariosDTO Listar(int id);
        void Deletar(int id);
    }
}