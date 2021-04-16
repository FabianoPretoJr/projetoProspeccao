using BLL.DTO.Usuario;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.Services.Usuario
{
    public interface IUsuarioService
    {
        UsuarioAutenticarResultadoDTO Autenticar(ref UsuarioAutenticarDTO usuarioDTO);
        ListaPerfilsDeUsuarioResultadoDTO ListarPerfilsDeUsuario(UsuarioAutenticarDTO usuario);
        List<PerfilDeUsuarioDTO> ListarPerfils();
        List<ListaUsuariosDTO> ListarUsuarios();
        void Cadastrar(UsuarioModel usuario);
    }
}
