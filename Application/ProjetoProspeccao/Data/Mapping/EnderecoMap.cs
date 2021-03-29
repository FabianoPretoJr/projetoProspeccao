using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(e => e.Id_Endereco);
            builder.Property(e => e.Cep);
            builder.Property(e => e.Rua);
            builder.Property(e => e.Numero);
            builder.Property(e => e.Complemento);
            builder.Property(e => e.Bairro);
            builder.HasOne(e => e.Cliente).WithMany(c => c.Enderecos);
            builder.HasOne(e => e.Cidade).WithMany(c => c.Enderecos);
        }
    }
}
