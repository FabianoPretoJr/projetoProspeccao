using BLL.DTO.Usuario;
using BLL.Interfaces.DAL;
using BLL.Interfaces.Services.Usuario;
using BLL.Models;
using BLL.Validacoes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Service.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioDAL _usuarioDAL;

        public UsuarioService(IUsuarioDAL usuarioDAL)
        {
            _usuarioDAL = usuarioDAL;
        }

        public UsuarioAutenticarResultadoDTO Autenticar(ref UsuarioAutenticarDTO usuarioDTO)
        {
            UsuarioAutenticarResultadoDTO usuarioAutenticarResultado = new UsuarioAutenticarResultadoDTO();
            var erros = ValidacaoService.ValidarErros(usuarioDTO);
            if (erros.Count() > 0)
            {
                usuarioAutenticarResultado.Erros.AddRange(erros);
                return usuarioAutenticarResultado;
            }
            else
            {
                usuarioAutenticarResultado.RetornoAutenticacaoUsuario = _usuarioDAL.Autenticar(ref usuarioDTO);
                return usuarioAutenticarResultado;
            }
        }

        public ListaPerfilsDeUsuarioResultadoDTO ListarPerfilsDeUsuario(UsuarioAutenticarDTO usuarioDTO)
        {
            ListaPerfilsDeUsuarioResultadoDTO listaPerfilsDeUsuarioResultado = new ListaPerfilsDeUsuarioResultadoDTO();
            var erros = ValidacaoService.ValidarErros(usuarioDTO);
            if (erros.Count() > 0)
            {
                listaPerfilsDeUsuarioResultado.Erros.AddRange(erros);
                return listaPerfilsDeUsuarioResultado;
            }
            else
            {
                listaPerfilsDeUsuarioResultado.PerfilsDeUsuario.AddRange(_usuarioDAL.ListarPerfilsDeUsuario(usuarioDTO));
                return listaPerfilsDeUsuarioResultado;
            }
        }

        public List<ListaUsuariosDTO> ListarUsuarios()
        {
            return _usuarioDAL.Listar();
        }

        public void Cadastrar(UsuarioModel usuario)
        {
            _usuarioDAL.Cadastrar(usuario);
        }

        public List<PerfilDeUsuarioDTO> ListarPerfils()
        {
            return _usuarioDAL.ListarPerfils();
        }
    }
}
