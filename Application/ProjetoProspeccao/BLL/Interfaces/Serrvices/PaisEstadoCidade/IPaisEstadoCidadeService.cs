using BLL.DTO.PaisEstadoCidade;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.Serrvices.PaisEstadoCidade
{
    public interface IPaisEstadoCidadeService
    {
        List<ListarPaisEstadoCidadeDTO> Listar();
        List<PaisModel> ListarPais();
        List<EstadoModel> ListarEstado(int idPais);
        List<CidadeModel> ListarCidade(int idEstado);
    }
}
