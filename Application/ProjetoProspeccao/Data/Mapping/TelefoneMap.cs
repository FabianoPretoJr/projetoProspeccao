using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class TelefoneMap : IEntityTypeConfiguration<TelefoneModel>
    {
        public void Configure(EntityTypeBuilder<TelefoneModel> builder)
        {
            builder.ToTable("Telefone");
            builder.HasKey(t => t.Id_Telefone);
            builder.Property(t => t.Numero_Telefone);
            builder.HasOne(t => t.Cliente).WithMany(c => c.Telefones).HasForeignKey(t => t.Id_Cliente).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
