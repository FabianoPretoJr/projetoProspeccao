using System.ComponentModel.DataAnnotations;
namespace BLL.DTO.Usuario
{
    public class UsuarioAutenticarDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo login é obrigatório")]
        [MaxLength(45, ErrorMessage = "Máximo 45 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string Senha { get; set; }
    }
}
