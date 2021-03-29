using BLL.DTO.Usuario;
using BLL.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
    public class UsuarioEF : IUsuarioDAL
    {
        public bool Autenticar(ref UsuarioAutenticarDTO usuarioDTO)
        {
            throw new NotImplementedException();
        }

        public List<PerfilDeUsuarioDTO> ListarPerfilsDeUsuario(UsuarioAutenticarDTO usuarioDTO)
        {
            throw new NotImplementedException();
        }
    }
}
