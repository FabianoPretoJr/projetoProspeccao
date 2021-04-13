using BLL.Enums;
using System;

namespace BLL.DTO.Fluxo
{
    public class Filtros
    {
        public string ClienteNome { get; set; }
        public string ClienteCPF { get; set; }
        public EStatus Status { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}