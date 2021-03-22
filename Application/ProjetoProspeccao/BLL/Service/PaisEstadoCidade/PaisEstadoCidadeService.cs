using BLL.DTO.PaisEstadoCidade;
using BLL.Interfaces.DAL;
using BLL.Interfaces.Serrvices.PaisEstadoCidade;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Service.PaisEstadoCidade
{
    public class PaisEstadoCidadeService : IPaisEstadoCidadeService
    {
        private IPaisEstadoCidadeDAL _paisEstadoCidadeDAL;

        public PaisEstadoCidadeService(IPaisEstadoCidadeDAL paisEstadoCidadeDAL)
        {
            _paisEstadoCidadeDAL = paisEstadoCidadeDAL;
        }

        public List<ListarPaisEstadoCidadeDTO> ListagemPaisEstadoCidade()
        {
            var listaPaisEstadoCidade = _paisEstadoCidadeDAL.ListagemPaisEstadoCidade();
            return listaPaisEstadoCidade;
        }

        public List<PaisModel> ListarPais()
        {
            return _paisEstadoCidadeDAL.ListarPais();
        }

        public List<EstadoModel> ListarEstado(int idPais)
        {
            return _paisEstadoCidadeDAL.ListarEstado(idPais);
        }

        public List<CidadeModel> ListarCidade(int idEstado)
        {
            return _paisEstadoCidadeDAL.ListarCidade(idEstado);
        }
    }
}
