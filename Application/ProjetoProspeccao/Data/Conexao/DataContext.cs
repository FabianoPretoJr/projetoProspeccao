using Microsoft.EntityFrameworkCore;

namespace Data.Conexao
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
