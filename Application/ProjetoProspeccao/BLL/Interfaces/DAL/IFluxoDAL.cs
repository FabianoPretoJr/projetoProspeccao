using BLL.DTO.Fluxo;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.DAL
{
    public interface IFluxoDAL
    {
        void AprovarFluxo(FluxoDTO fluxoDTO);
        void CorrecaoDeCadastro(FluxoDTO fluxoDTO);
        void DevolverCadastro(FluxoDTO fluxoDTO);
        void EnviarAnaliseGerencia(FluxoDTO fluxoDTO);
        void ReprovarFluxo(FluxoDTO fluxoDTO);
        ListaFluxoDTO ListagemFluxo();
    }
}