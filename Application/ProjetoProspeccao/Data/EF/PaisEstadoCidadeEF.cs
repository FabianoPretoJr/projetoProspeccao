using BLL.DTO.PaisEstadoCidade;
using BLL.Interfaces.DAL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
    public class PaisEstadoCidadeEF : IPaisEstadoCidadeDAL
    {
        public List<ListarPaisEstadoCidadeDTO> ListagemPaisEstadoCidade()
        {
            throw new NotImplementedException();
        }

        public List<CidadeModel> ListarCidade(int idEstado)
        {
            throw new NotImplementedException();
        }

        public List<EstadoModel> ListarEstado(int idPais)
        {
            throw new NotImplementedException();
        }

        public List<PaisModel> ListarPais()
        {
            throw new NotImplementedException();
        }
    }
}
