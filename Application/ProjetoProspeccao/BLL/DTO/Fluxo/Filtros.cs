using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.Fluxo
{
    public class Filtros
    {
        public string ClienteNome { get; set; }
        public string ClienteCPF { get; set; }
        public int Status { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}