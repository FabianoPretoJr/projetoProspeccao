using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class EstadoMap : IEntityTypeConfiguration<EstadoModel>
    {
        public void Configure(EntityTypeBuilder<EstadoModel> builder)
        {
            builder.ToTable("Estado");
            builder.HasKey(e => e.Id_Estado);
            builder.HasIndex(e => e.Nome_Estado).IsUnique();
            builder.HasOne(e => e.Pais).WithMany(p => p.Estados);
            builder.Property(e => e.Ativo);
        }
    }
}
