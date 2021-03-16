using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Fluxo
{
    public class FluxoDTO
    {
        [Required(ErrorMessage = "Campo ID cliente é obrigatório")]
        [Range(0, 10000, ErrorMessage = "Id cliente inválido")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Campo ID usuário é obrigatório")]
        [Range(0, 10000, ErrorMessage = "Id usuário inválido")]
        public int IdUsuario { get; set; }
    }
}
