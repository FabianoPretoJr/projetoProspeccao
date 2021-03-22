using BLL.DTO.Fluxo;

namespace BLL.Interfaces.Services.Fluxo
{
    public interface IFluxoService
    {
        FluxoResultadoDTO EnviarAnaliseGerencia(FluxoDTO fluxoDTO);
        FluxoResultadoDTO EnviarAnaliseControleDeRisco(FluxoDTO fluxoDTO);
        FluxoResultadoDTO AprovarFluxo(FluxoDTO fluxoDTO);
        FluxoResultadoDTO ReprovarFluxo(FluxoDTO fluxoDTO);
        FluxoResultadoDTO CorrecaoDeCadastro(FluxoDTO fluxoDTO);
        FluxoResultadoDTO DevolverCadastro(FluxoDTO fluxoDTO);
    }
}
