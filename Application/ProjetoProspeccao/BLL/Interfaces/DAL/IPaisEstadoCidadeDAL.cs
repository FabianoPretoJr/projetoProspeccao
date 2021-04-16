using BLL.DTO.PaisEstadoCidade;
using BLL.Interfaces.Repository;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.DAL
{
    public interface IPaisEstadoCidadeDAL : IRepository<ListarPaisEstadoCidadeDTO>
    {
        List<ListarPaisEstadoCidadeDTO> Listar();
        List<PaisModel> ListarPais();
        List<EstadoModel> ListarEstado(int idPais);
        List<CidadeModel> ListarCidade(int idEstado);
    }
}
