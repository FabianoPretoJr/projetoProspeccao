using BLL.DTO.Fluxo;
using BLL.Interfaces.DAL;
using BLL.Interfaces.Services.Fluxo;
using BLL.Validacoes;
using System;
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
            var erros = ValidacaoService.ValidarErros(fluxoDTO);
            if (erros.Count() > 0)
            {
                FluxoResultadoDTO fluxoResultado = new FluxoResultadoDTO();
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
            var erros = ValidacaoService.ValidarErros(fluxoDTO);
            if (erros.Count() > 0)
            {
                FluxoResultadoDTO fluxoResultado = new FluxoResultadoDTO();
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
            var erros = ValidacaoService.ValidarErros(fluxoDTO);
            if (erros.Count() > 0)
            {
                FluxoResultadoDTO fluxoResultado = new FluxoResultadoDTO();
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
            var erros = ValidacaoService.ValidarErros(fluxoDTO);
            if (erros.Count() > 0)
            {
                FluxoResultadoDTO fluxoResultado = new FluxoResultadoDTO();
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
            var erros = ValidacaoService.ValidarErros(fluxoDTO);
            if (erros.Count() > 0)
            {
                FluxoResultadoDTO fluxoResultado = new FluxoResultadoDTO();
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
