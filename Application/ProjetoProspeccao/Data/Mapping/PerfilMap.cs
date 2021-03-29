using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PerfilMap : IEntityTypeConfiguration<PerfilModel>
    {
        public void Configure(EntityTypeBuilder<PerfilModel> builder)
        {
            builder.ToTable("Perfil");
            builder.HasKey(p => p.Id_Perfil);
            builder.HasIndex(p => p.Nome_Perfil).IsUnique();
            builder.Property(p => p.Ativo);
        }
    }
}
