using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Cliente
{
    public class ClienteCadastroDTO
    {
        [Required(ErrorMessage = "Campo nome de cliente é obrigatório")]
        [MaxLength(45, ErrorMessage = "Máximo 45 caracteres para campo nome de cliente")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo CPF de cliente é obrigatório")]
        [StringLength(11, ErrorMessage = "Deve conter 11 caracteres o campo CPF de cliente")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo RG de cliente é obrigatório")]
        [StringLength(9, ErrorMessage = "Deve conter 9 caracteres o campo RG de cliente")]
        [DisplayName("RG")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Campo data de nascimento de cliente é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato inválido de data de nascimento de cliente")]
        [DisplayName("Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo e-mail de cliente é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato inválido de e-mail de cliente")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo número de telefone de cliente é obrigatório")]
        [StringLength(9, ErrorMessage = "Deve conter 9 caracteres o campo número de telefone de cliente")]
        [DisplayName("Nº Telefone")]
        public string NumeroTelefone { get; set; }

        [Required(ErrorMessage = "Campo CEP de cliente é obrigatório")]
        [StringLength(8, ErrorMessage = "Deve conter 8 caracteres o campo CEP de cliente")]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo rua de cliente é obrigatório")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres para o campo rua de cliente")]
        [DisplayName("Rua")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo número residencial de cliente é obrigatório")]
        [MaxLength(6, ErrorMessage = "Máximo 6 caracteres para o campo numero residencial de cliente")]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo complemento residencial de cliente")]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo bairro de cliente é obrigatório")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres para o campo bairro de cliente")]
        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo ID cidade de cliente é obrigatório")]
        [Range(1, 10000, ErrorMessage = "Id cidade de cliente está inválido")]
        [DisplayName("Cidade")]
        public int IdCidade { get; set; }

        [Required(ErrorMessage = "Campo ID usuário é obrigatório")]
        [Range(1, 10000, ErrorMessage = "Id usuário está inválido")]
        public int IdUsuario { get; set; }
    }
}
