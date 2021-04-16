using BLL.Interfaces.Repository;
using Data.Conexao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _database;
        private DbSet<T> _dataSet;

        public BaseRepository(DataContext database)
        {
            _database = database;
            _dataSet = database.Set<T>();
        }

        public async void Cadastrar(T item)
        {
            try
            {
                _dataSet.Add(item);
                await _database.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void Atualizar(T item)
        {
            try
            {
                _dataSet.Update(item);
                await _database.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
