using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Usuario
{
    public class UsuarioAutenticarDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo login de usuário é obrigatório")]
        [MaxLength(45, ErrorMessage = "Máximo 45 caracteres para o campo login de usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo senha de usuário é obrigatório")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo senha de usuário")]
        public string Senha { get; set; }
    }
}
