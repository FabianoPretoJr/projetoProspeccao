using BLL.DTO.Fluxo;
using BLL.Interfaces.DAL;
using BLL.Interfaces.Services.Fluxo;
using System;

namespace BLL.Service.Fluxo
{
    public class FluxoService : IFluxoService
    {
        private IFluxoDAL _fluxoDAL;

        public FluxoService(IFluxoDAL fluxoDAL)
        {
            _fluxoDAL = fluxoDAL;
        }

        public void AprovarFluxo(FluxoDTO fluxoDTO)
        {
            try
            {
                _fluxoDAL.AprovarFluxo(fluxoDTO);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CorrecaoDeCadastro(FluxoDTO fluxoDTO)
        {
            try
            {
                _fluxoDAL.CorrecaoDeCadastro(fluxoDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DevolverCadastro(FluxoDTO fluxoDTO)
        {
            try
            {
                _fluxoDAL.DevolverCadastro(fluxoDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void EnviarAnaliseControleDeRisco(FluxoDTO fluxoDTO)
        {
            try
            {
                _fluxoDAL.EnviarAnaliseControleDeRisco(fluxoDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void EnviarAnaliseGerencia(FluxoDTO fluxoDTO)
        {
            try
            {
                _fluxoDAL.EnviarAnaliseGerencia(fluxoDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void ReprovarFluxo(FluxoDTO fluxoDTO)
        {
            try
            {
                _fluxoDAL.ReprovarFluxo(fluxoDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
