using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Cliente
{
    public class ClienteCadastroResultadoDTO
    {
        public ClienteCadastroResultadoDTO()
        {
            this.Erros = new List<ValidationResult>();
        }

        public List<ValidationResult> Erros { get; set; }
    }
}
