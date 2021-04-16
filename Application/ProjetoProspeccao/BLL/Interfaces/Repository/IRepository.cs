using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        void Cadastrar(T item);
        void Atualizar(T item);
    }
}
