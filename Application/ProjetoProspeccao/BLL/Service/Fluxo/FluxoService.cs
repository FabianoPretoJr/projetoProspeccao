using BLL.DTO.Fluxo;
using BLL.Interfaces.DAL;
using BLL.Interfaces.Services.Fluxo;
using BLL.Validacoes;
using System.Linq;

namespace BLL.Service.Fluxo
{
    public class FluxoService : IFluxoService
    {
        private IFluxoDAL _fluxoDAL;

        public FluxoService(IFluxoDAL fluxoDAL)
        {
            _fluxoDAL = fluxoDAL;
        }

        public FluxoResultadoDTO AprovarFluxo(FluxoDTO fluxoDTO)
        {
            FluxoResultadoDTO fluxoResultado = new FluxoResultadoDTO();
            var erros = ValidacaoService.ValidarErros(fluxoDTO);
            if (erros.Count() > 0)
            {
                fluxoResultado.Erros.AddRange(erros);
                return fluxoResultado;
            }
            else
            {
                _fluxoDAL.AprovarFluxo(fluxoDTO);
                return null;
            }
        }

        public FluxoResultadoDTO CorrecaoDeCadastro(FluxoDTO fluxoDTO)
        {
            FluxoResultadoDTO fluxoResultado = new FluxoResultadoDTO();
            var erros = ValidacaoService.ValidarErros(fluxoDTO);
            if (erros.Count() > 0)
            {
                fluxoResultado.Erros.AddRange(erros);
                return fluxoResultado;
            }
            else
            {
                _fluxoDAL.CorrecaoDeCadastro(fluxoDTO);
                return null;
            }
        }

        public FluxoResultadoDTO DevolverCadastro(FluxoDTO fluxoDTO)
        {
            FluxoResultadoDTO fluxoResultado = new FluxoResultadoDTO();
            var erros = ValidacaoService.ValidarErros(fluxoDTO);
            if (erros.Count() > 0)
            {
                fluxoResultado.Erros.AddRange(erros);
                return fluxoResultado;
            }
            else
            {
                _fluxoDAL.DevolverCadastro(fluxoDTO);
                return null;
            }
        }

        public FluxoResultadoDTO EnviarAnaliseGerencia(FluxoDTO fluxoDTO)
        {
            FluxoResultadoDTO fluxoResultado = new FluxoResultadoDTO();
            var erros = ValidacaoService.ValidarErros(fluxoDTO);
            if (erros.Count() > 0)
            {
                fluxoResultado.Erros.AddRange(erros);
                return fluxoResultado;
            }
            else
            {
                _fluxoDAL.EnviarAnaliseGerencia(fluxoDTO);
                return null;
            }
        }

        public FluxoResultadoDTO ReprovarFluxo(FluxoDTO fluxoDTO)
        {
            FluxoResultadoDTO fluxoResultado = new FluxoResultadoDTO();
            var erros = ValidacaoService.ValidarErros(fluxoDTO);
            if (erros.Count() > 0)
            {
                fluxoResultado.Erros.AddRange(erros);
                return fluxoResultado;
            }
            else
            {
                _fluxoDAL.ReprovarFluxo(fluxoDTO);
                return null;
            }
        }
    }
}
