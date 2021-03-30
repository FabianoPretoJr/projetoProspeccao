using BLL.DTO.PaisEstadoCidade;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.DAL
{
    public interface IPaisEstadoCidadeDAL
    {
        List<PaisModel> ListarPais();
        List<EstadoModel> ListarEstado(int idPais);
        List<CidadeModel> ListarCidade(int idEstado);
    }
}
