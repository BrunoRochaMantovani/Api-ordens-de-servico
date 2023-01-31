using API_ORDEM_SERVICO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_ORDEM_SERVICO.Data.Mappings
{
    public class FinalizacaoMap : IEntityTypeConfiguration<Finalizacao>
    {
        public void Configure(EntityTypeBuilder<Finalizacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

        }
    }
}
