using BLL.DTO.Usuario;

namespace BLL.Interfaces.Services.Usuario
{
    public interface IUsuarioService
    {
        UsuarioAutenticarResultadoDTO Autenticar(ref UsuarioAutenticarDTO usuarioDTO);
        ListaPerfilsDeUsuarioResultadoDTO ListarPerfilsDeUsuario(UsuarioAutenticarDTO usuario);
    }
}
