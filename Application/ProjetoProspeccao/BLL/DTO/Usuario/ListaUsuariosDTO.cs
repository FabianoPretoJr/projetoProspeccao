using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.Usuario
{
    public class ListaUsuariosDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public bool Ativo { get; set; }
        public List<PerfilDeUsuarioDTO> Perfils { get; set; } = new List<PerfilDeUsuarioDTO>();
    }
}
