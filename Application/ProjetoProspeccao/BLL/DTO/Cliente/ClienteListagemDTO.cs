using System;

namespace BLL.DTO.Cliente
{
    public class ClienteListagemDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public int IdStatus { get; set; }
        public bool UsuarioPermitido { get; set; }
    }
}
