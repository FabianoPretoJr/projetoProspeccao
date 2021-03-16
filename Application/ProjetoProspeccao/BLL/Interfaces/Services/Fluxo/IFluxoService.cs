using BLL.DTO.Fluxo;

namespace BLL.Interfaces.Services.Fluxo
{
    public interface IFluxoService
    {
        void EnviarAnaliseGerencia(FluxoDTO fluxoDTO);
        void EnviarAnaliseControleDeRisco(FluxoDTO fluxoDTO);
        void AprovarFluxo(FluxoDTO fluxoDTO);
        void ReprovarFluxo(FluxoDTO fluxoDTO);
        void CorrecaoDeCadastro(FluxoDTO fluxoDTO);
        void DevolverCadastro(FluxoDTO fluxoDTO);
    }
}
