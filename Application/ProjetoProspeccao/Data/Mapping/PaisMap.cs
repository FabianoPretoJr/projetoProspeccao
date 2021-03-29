using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PaisMap : IEntityTypeConfiguration<PaisModel>
    {
        public void Configure(EntityTypeBuilder<PaisModel> builder)
        {
            builder.ToTable("Pais");
            builder.HasKey(p => p.Id_Pais);
            builder.HasIndex(p => p.Nome_Pais).IsUnique();
            builder.Property(p => p.Ativo);
        }
    }
}
