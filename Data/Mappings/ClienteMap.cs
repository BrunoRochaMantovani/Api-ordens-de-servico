using API_ORDEM_SERVICO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_ORDEM_SERVICO.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(x => x.id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                    .HasMaxLength(30)
                    .IsRequired();

            builder.Property(x => x.Empresa)
                    .HasMaxLength(40)
                    .IsRequired();

            builder.Property(x => x.Telefone)
                    .HasMaxLength(11)
                    .IsRequired();
        }
    }
}
