using BLL.Models;
using Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Data.Conexao
{
    public class DataContext : DbContext
    {
        public DbSet<AcessoModel> Acesso { get; set; }
        public DbSet<AnaliseModel> Analise { get; set; }
        public DbSet<CidadeModel> Cidade { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }
        public DbSet<EstadoModel> Estado { get; set; }
        public DbSet<PaisModel> Pais { get; set; }
        public DbSet<PerfilModel> Perfil { get; set; }
        public DbSet<StatusAnaliseModel> StatusAnalise { get; set; }
        public DbSet<TelefoneModel> Telefone { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcessoModel>().HasKey(sc => new { sc.Id_Usuario, sc.Id_Perfil });

            modelBuilder.Entity<AnaliseModel>(new AnaliseMap().Configure);
            modelBuilder.Entity<CidadeModel>(new CidadeMap().Configure);
            modelBuilder.Entity<ClienteModel>(new ClienteMap().Configure);
            modelBuilder.Entity<EnderecoModel>(new EnderecoMap().Configure);
            modelBuilder.Entity<EstadoModel>(new EstadoMap().Configure);
            modelBuilder.Entity<PaisModel>(new PaisMap().Configure);
            modelBuilder.Entity<PerfilModel>(new PerfilMap().Configure);
            modelBuilder.Entity<StatusAnaliseModel>(new StatusAnaliseMap().Configure);
            modelBuilder.Entity<TelefoneModel>(new TelefoneMap().Configure);
            modelBuilder.Entity<UsuarioModel>(new UsuarioMap().Configure);

            base.OnModelCreating(modelBuilder);
        }
    }
}
