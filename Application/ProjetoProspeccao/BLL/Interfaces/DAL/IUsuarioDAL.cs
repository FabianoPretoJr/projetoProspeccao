using BLL.DTO.Usuario;
using System.Collections.Generic;

namespace BLL.Interfaces.DAL
{
    public interface IUsuarioDAL
    {
        bool Autenticar(ref UsuarioAutenticarDTO usuarioDTO);
        List<UsuarioVerificarResultadoDTO> Verificar(UsuarioAutenticarDTO usuarioDTO);
    }
}