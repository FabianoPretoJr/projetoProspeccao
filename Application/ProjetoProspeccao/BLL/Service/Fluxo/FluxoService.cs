using BLL.DTO.Fluxo;
using BLL.Interfaces.DAL;
using BLL.Interfaces.Services.Fluxo;
using BLL.Models;
using BLL.Validacoes;
using System;
using System.Collections.Generic;
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

        public ListaFluxoDTO ListagemFluxo()
        {
            return _fluxoDAL.ListagemFluxo();
        }

        public ListaFluxoDTO ListagemFluxo(ListaFluxoDTO filtrosFluxo)
        {
            var listaFluxo = _fluxoDAL.ListagemFluxo();

            if (filtrosFluxo.Filtros.ClienteCPF != null)
            {
                listaFluxo.ListaAnaliseModel = listaFluxo.ListaAnaliseModel.Where(a => a.Cliente.Cpf == filtrosFluxo.Filtros.ClienteCPF).ToList();
            }
            if (filtrosFluxo.Filtros.ClienteNome != null)
            {
                listaFluxo.ListaAnaliseModel = listaFluxo.ListaAnaliseModel.Where(a => a.Cliente.Nome.Contains(filtrosFluxo.Filtros.ClienteNome)).ToList();
            }
            if (filtrosFluxo.Filtros.DataInicio != null)
            {
                listaFluxo.ListaAnaliseModel = listaFluxo.ListaAnaliseModel.Where(a => a.Data_Hora.Date >= filtrosFluxo.Filtros.DataInicio).ToList();
            }
            if (filtrosFluxo.Filtros.DataFim != null)
            {
                listaFluxo.ListaAnaliseModel = listaFluxo.ListaAnaliseModel.Where(a => a.Data_Hora.Date <= filtrosFluxo.Filtros.DataFim).ToList();
            }

            return listaFluxo;
        }
    }
}
