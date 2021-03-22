using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Fluxo
{
    public class FluxoResultadoDTO
    {
        public FluxoResultadoDTO()
        {
            this.Erros = new List<ValidationResult>();
        }

        public List<ValidationResult> Erros { get; set; }
    }
}
