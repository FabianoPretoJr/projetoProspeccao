using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Cliente
{
    public class ClienteCadastroDTO
    {
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [MaxLength(45, ErrorMessage = "Máximo 45 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "Deve conter 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo RG é obrigatório")]
        [StringLength(9, ErrorMessage = "Deve conter 9 caracteres")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Campo data de nascimento é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato inválido de data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato inválido de e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo número de telefone é obrigatório")]
        [StringLength(9, ErrorMessage = "Deve conter 9 caracteres")]
        public string NumeroTelefone { get; set; }

        [Required(ErrorMessage = "Campo CEP é obrigatório")]
        [StringLength(8, ErrorMessage = "Deve conter 8 caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo rua é obrigatório")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo número é obrigatório")]
        [MaxLength(6, ErrorMessage = "Máximo 6 caracteres")]
        public string Numero { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo bairro é obrigatório")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo ID cidade é obrigatório")]
        [Range(1, 10000, ErrorMessage = "Id inválido")]
        public int IdCidade { get; set; }

        [Required(ErrorMessage = "Campo ID usuário é obrigatório")]
        [Range(1, 10000, ErrorMessage = "Id inválido")]
        public int IdUsuario { get; set; }
    }
}
