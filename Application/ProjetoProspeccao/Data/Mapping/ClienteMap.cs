using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.Id_Cliente);
            builder.Property(c => c.Nome);
            builder.HasIndex(c => c.Cpf).IsUnique();
            builder.Property(c => c.Rg);
            builder.Property(c => c.Data_Nascimento);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.HasOne(c => c.StatusAnalise).WithMany(s => s.Clientes);
        }
    }
}
