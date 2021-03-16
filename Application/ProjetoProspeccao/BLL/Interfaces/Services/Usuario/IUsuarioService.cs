using System.Collections.Generic;
using BLL.DTO.Usuario;

namespace BLL.Interfaces.Services.Usuario
{
    public interface IUsuarioService
    {
        bool Autenticar(ref UsuarioAutenticarDTO usuarioDTO);
        List<UsuarioVerificarResultadoDTO> Verificar(UsuarioAutenticarDTO usuario);
    }
}
