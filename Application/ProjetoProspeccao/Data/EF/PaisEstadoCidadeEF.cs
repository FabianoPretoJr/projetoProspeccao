﻿using BLL.Interfaces.DAL;
using BLL.Models;
using Data.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.EF
{
    public class PaisEstadoCidadeEF : IPaisEstadoCidadeDAL
    {
        private readonly DataContext _database;

        public PaisEstadoCidadeEF(DataContext database)
        {
            _database = database;
        }

        public List<PaisModel> ListarPais()
        {
            try
            {
                var listaPaises = _database.Pais.ToList();

                List<PaisModel> lista = new List<PaisModel>();

                foreach(var pais in listaPaises)
                {
                    int idPais = pais.Id_Pais;
                    string nomePais = pais.Nome_Pais;
                    PaisModel paisModel = new PaisModel(idPais, nomePais);
                    lista.Add(paisModel);
                }

                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<EstadoModel> ListarEstado(int idPais)
        {
            try
            {
                var listaEstados = _database.Estado.Where(e => e.Id_Pais == idPais).ToList();

                List<EstadoModel> lista = new List<EstadoModel>();

                foreach(var estado in listaEstados)
                {
                    int idEstado = estado.Id_Estado;
                    string nomeEstado = estado.Nome_Estado;
                    EstadoModel estadoModel = new EstadoModel(idEstado, nomeEstado, idPais);
                    lista.Add(estadoModel);
                }

                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CidadeModel> ListarCidade(int idEstado)
        {
            try
            {
                var listaCidades = _database.Cidade.Where(c => c.Id_Estado == idEstado).ToList();

                List<CidadeModel> lista = new List<CidadeModel>();

                foreach(var cidade in listaCidades)
                {
                    int idCidade = cidade.Id_Cidade;
                    string nomeCidade = cidade.Nome_Cidade;
                    CidadeModel cidadeModel = new CidadeModel(idCidade, nomeCidade, idEstado);
                    lista.Add(cidadeModel);
                }

                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
