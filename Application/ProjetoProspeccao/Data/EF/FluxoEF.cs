using BLL.DTO.Fluxo;
using BLL.Interfaces.DAL;
using BLL.Models;
using Data.Conexao;
using System;
using System.Linq;
using BLL.Enums;
using Data.Validacoes;

namespace Data.EF
{
    public class FluxoEF : IFluxoDAL
    {
        private readonly DataContext _database;

        public FluxoEF(DataContext database)
        {
            _database = database;
        }

        public void AprovarFluxo(FluxoDTO fluxoDTO)
        {
            try
            {
                var cliente = Valida.Cliente(_database, fluxoDTO.IdCliente);
                var usuario = Valida.Usuario(_database, fluxoDTO.IdUsuario);

                if(cliente.Id_Status == (int)EStatus.analise_gerencia || cliente.Id_Status == (int)EStatus.analise_controle_risco)
                {
                    int idStatus;
                    if (cliente.Enderecos.Any(e => e.Cidade.Estado.Pais.Nome_Pais == "Brasil") || cliente.Id_Status == (int)EStatus.analise_gerencia)
                        idStatus = (int)EStatus.aprovado_gerencia;
                    else
                        idStatus = (int)EStatus.aprovado_controle_risco;

                    var aprovado = new AnaliseModel(idStatus, fluxoDTO.IdCliente, fluxoDTO.IdUsuario);
                    _database.Analise.Add(aprovado);

                    cliente.Id_Status = idStatus;
                    _database.Cliente.Update(cliente);

                    if (cliente.Enderecos.Any(e => e.Cidade.Estado.Pais.Nome_Pais != "Brasil") && idStatus == (int)EStatus.aprovado_gerencia)
                    {
                        idStatus = (int)EStatus.analise_controle_risco;

                        var analise = new AnaliseModel(idStatus, fluxoDTO.IdCliente, fluxoDTO.IdUsuario);
                        _database.Analise.Add(analise);

                        cliente.Id_Status = idStatus;
                        _database.Cliente.Update(cliente);             
                    }
                    _database.SaveChanges();
                }
                else
                    throw new ArgumentException(message: "Este cliente não está em fase de análise");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CorrecaoDeCadastro(FluxoDTO fluxoDTO)
        {
            try
            {
                var cliente = Valida.Cliente(_database, fluxoDTO.IdCliente);
                var usuario = Valida.Usuario(_database, fluxoDTO.IdUsuario);

                if (cliente.Id_Status == (int)EStatus.analise_gerencia || cliente.Id_Status == (int)EStatus.analise_controle_risco)
                {
                    int idStatus = (int)EStatus.correcao_cadastro;

                    var correcao = new AnaliseModel(idStatus, fluxoDTO.IdCliente, fluxoDTO.IdUsuario);
                    _database.Analise.Add(correcao);

                    cliente.Id_Status = idStatus;
                    _database.Cliente.Update(cliente);

                    _database.SaveChanges();
                }
                else
                    throw new ArgumentException(message: "Este cliente não está em fase de análise");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DevolverCadastro(FluxoDTO fluxoDTO)
        {
            try
            {
                var cliente = Valida.Cliente(_database, fluxoDTO.IdCliente);
                var usuario = Valida.Usuario(_database, fluxoDTO.IdUsuario);

                if (cliente.Id_Status != (int)EStatus.correcao_cadastro)
                    throw new ArgumentException(message: "Este cliente não está em correção de cadastro");

                NewMethod(fluxoDTO, cliente, (int)EStatus.analise_gerencia);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void NewMethod(FluxoDTO fluxoDTO, ClienteModel cliente, int idStatus) // passar só int
        {
            var devolver = new AnaliseModel(idStatus, fluxoDTO.IdCliente, fluxoDTO.IdUsuario);
            _database.Analise.Add(devolver);

            cliente.Id_Status = idStatus;
            _database.Cliente.Update(cliente);

            _database.SaveChanges();
        }

        public void EnviarAnaliseGerencia(FluxoDTO fluxoDTO)
        {
            try
            {
                var cliente = Valida.Cliente(_database, fluxoDTO.IdCliente);
                var usuario = Valida.Usuario(_database, fluxoDTO.IdUsuario);

                if (cliente.Id_Status == (int)EStatus.Cadastrado)
                {
                    int idStatus = (int)EStatus.analise_gerencia;

                    var devolver = new AnaliseModel(idStatus, fluxoDTO.IdCliente, fluxoDTO.IdUsuario);
                    _database.Analise.Add(devolver);

                    cliente.Id_Status = idStatus;
                    _database.Cliente.Update(cliente);

                    _database.SaveChanges();
                }
                else
                    throw new ArgumentException(message: "Este cliente não está em fase de cadastro");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ReprovarFluxo(FluxoDTO fluxoDTO)
        {
            try
            {
                var cliente = Valida.Cliente(_database, fluxoDTO.IdCliente);
                var usuario = Valida.Usuario(_database, fluxoDTO.IdUsuario);

                if (cliente.Id_Status == (int)EStatus.analise_gerencia || cliente.Id_Status == (int)EStatus.analise_controle_risco)
                {
                    int idStatus = (int)EStatus.reprovado;

                    var devolver = new AnaliseModel(idStatus, fluxoDTO.IdCliente, fluxoDTO.IdUsuario);
                    _database.Analise.Add(devolver);

                    cliente.Id_Status = idStatus;
                    _database.Cliente.Update(cliente);

                    _database.SaveChanges();
                }
                else
                    throw new ArgumentException(message: "Este cliente não está em fase de análise");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
