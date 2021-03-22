using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Usuario
{
    public class UsuarioAutenticarResultadoDTO
    {
        public UsuarioAutenticarResultadoDTO()
        {
            this.Erros = new List<ValidationResult>();
        }

        public bool RetornoAutenticacaoUsuario { get; set; }

        public List<ValidationResult> Erros { get; set; }
    }
}
