using BLL.Models;
using System;
using System.Collections.Generic;

namespace BLL.DTO.Fluxo
{
    public class ListaFluxoDTO
    {
        public ListaFluxoDTO()
        {
            Filtros = new Filtros();
            ListaAnaliseModel = new List<AnaliseModel>();
        }

        public Filtros Filtros { get; set; }
        public List<AnaliseModel> ListaAnaliseModel { get; set; }
    }
}
