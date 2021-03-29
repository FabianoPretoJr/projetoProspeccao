using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Conexao
{
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=BRPC003855;Initial Catalog=DBProspeccao;Integrated Security=true";
            var optionbuilder = new DbContextOptionsBuilder<DataContext>();
            optionbuilder.UseSqlServer(connectionString);
            return new DataContext(optionbuilder.Options);
        }
    }
}
