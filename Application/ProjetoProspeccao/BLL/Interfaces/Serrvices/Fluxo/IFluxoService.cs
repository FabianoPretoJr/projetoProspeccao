using BLL.DTO.Fluxo;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.Services.Fluxo
{
    public interface IFluxoService
    {
        FluxoResultadoDTO EnviarAnaliseGerencia(FluxoDTO fluxoDTO);
        FluxoResultadoDTO AprovarFluxo(FluxoDTO fluxoDTO);
        FluxoResultadoDTO ReprovarFluxo(FluxoDTO fluxoDTO);
        FluxoResultadoDTO CorrecaoDeCadastro(FluxoDTO fluxoDTO);
        FluxoResultadoDTO DevolverCadastro(FluxoDTO fluxoDTO);
        ListaFluxoDTO ListagemFluxo();
        ListaFluxoDTO ListagemFluxo(ListaFluxoDTO filtrosFluxo);
    }
}