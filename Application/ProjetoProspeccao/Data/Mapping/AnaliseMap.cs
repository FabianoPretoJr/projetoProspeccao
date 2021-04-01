using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class AnaliseMap : IEntityTypeConfiguration<AnaliseModel>
    {
        public void Configure(EntityTypeBuilder<AnaliseModel> builder)
        {
            builder.ToTable("Analise");
            builder.HasKey(a => a.Id_Analise);
            builder.HasOne(a => a.StatusAnalise).WithMany(s => s.Analises).HasForeignKey(a => a.Id_Status);
            builder.HasOne(a => a.Cliente).WithMany(c => c.Analises).HasForeignKey(a => a.Id_Cliente).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(a => a.Usuario).WithMany(u => u.Analises).HasForeignKey(a => a.Id_Usuario);
            builder.Property(a => a.Data_Hora);
        }
    }
}
