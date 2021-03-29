using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u => u.Id_Usuario);
            builder.HasIndex(u => u.Login_Usuario).IsUnique();
            builder.Property(u => u.Senha);
            builder.Property(u => u.Ativo);
        }
    }
}
