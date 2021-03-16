using BLL.DTO.Usuario;
using BLL.Interfaces.DAL;
using BLL.Interfaces.Services.Usuario;
using System;
using System.Collections.Generic;

namespace BLL.Service.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioDAL _usuarioDAL;

        public UsuarioService(IUsuarioDAL usuarioDAL)
        {
            _usuarioDAL = usuarioDAL;
        }

        public bool Autenticar(ref UsuarioAutenticarDTO usuarioDTO)
        {
            try
            {
                return _usuarioDAL.Autenticar(ref usuarioDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception();
            }
        }

        public List<UsuarioVerificarResultadoDTO> Verificar(UsuarioAutenticarDTO usuarioDTO)
        {
            try
            {
                return _usuarioDAL.Verificar(usuarioDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception();
            }
        }
    }
}
