using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Usuario
{
    public class ListaPerfilsDeUsuarioResultadoDTO
    {
        public ListaPerfilsDeUsuarioResultadoDTO()
        {
            this.PerfilsDeUsuario = new List<PerfilDeUsuarioDTO>();
            this.Erros = new List<ValidationResult>();
        }

        public List<PerfilDeUsuarioDTO> PerfilsDeUsuario { get; set; }

        public List<ValidationResult> Erros { get; set; }
    }
}
