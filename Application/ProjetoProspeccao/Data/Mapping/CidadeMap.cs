using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CidadeMap : IEntityTypeConfiguration<CidadeModel>
    {
        public void Configure(EntityTypeBuilder<CidadeModel> builder)
        {
            builder.ToTable("Cidade");
            builder.HasKey(c => c.Id_Cidade);
            builder.Property(c => c.Nome_Cidade);
            builder.Property(c => c.Ativo);
            builder.HasOne(c => c.Estado).WithMany(e => e.Cidades);
        }
    }
}
