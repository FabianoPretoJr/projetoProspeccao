using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class StatusAnaliseMap : IEntityTypeConfiguration<StatusAnaliseModel>
    {
        public void Configure(EntityTypeBuilder<StatusAnaliseModel> builder)
        {
            builder.ToTable("StatusAnalise");
            builder.HasKey(s => s.Id_Status);
            builder.HasIndex(s => s.Nome_Status).IsUnique();
            builder.Property(s => s.Ativo);
        }
    }
}
