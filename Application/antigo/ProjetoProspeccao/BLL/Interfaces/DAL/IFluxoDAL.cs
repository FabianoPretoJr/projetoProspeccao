using BLL.DTO.Fluxo;

namespace BLL.Interfaces.DAL
{
    public interface IFluxoDAL
    {
        void AprovarFluxo(FluxoDTO fluxoDTO);
        void CorrecaoDeCadastro(FluxoDTO fluxoDTO);
        void DevolverCadastro(FluxoDTO fluxoDTO);
        void EnviarAnaliseControleDeRisco(FluxoDTO fluxoDTO);
        void EnviarAnaliseGerencia(FluxoDTO fluxoDTO);
        void ReprovarFluxo(FluxoDTO fluxoDTO);
    }
}