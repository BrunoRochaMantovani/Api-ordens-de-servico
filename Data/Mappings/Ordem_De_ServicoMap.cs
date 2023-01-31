using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_ORDEM_SERVICO.Models;

namespace API_ORDEM_SERVICO.Data.Mappings
{
    public class Ordem_De_ServicoMap : IEntityTypeConfiguration<Ordem_De_Servico>
    {
        public void Configure(EntityTypeBuilder<Ordem_De_Servico> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.DescProblema)
                .HasMaxLength(140)
                .IsRequired();

            builder.Property(x => x.Equipamento)
                 .HasMaxLength(100)
                 .IsRequired();

            builder.HasOne(x => x.Cliente)
                   .WithMany(x => x.Ordem_De_Servicos)
                   .HasForeignKey(x => x.ClienteId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Tecnico)
                   .WithMany(x => x.Ordem_De_Servico)
                   .HasForeignKey(x => x.TecnicoId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Servicos)
                .WithMany(x => x.Ordem_De_Servicos)
                .UsingEntity<Dictionary<string, object>>(
                    "OrdemServicos",
                    cod_ordem => cod_ordem
                        .HasOne<Servico>()
                        .WithMany()
                        .HasForeignKey("cod_ordem")
                        .HasConstraintName("FK_cod_ordem")
                        .OnDelete(DeleteBehavior.Cascade),

                    cod_servico => cod_servico
                        .HasOne<Ordem_De_Servico>()
                        .WithMany()
                        .HasForeignKey("cod_servico")
                        .HasConstraintName("FK_cod_servico")
                        .OnDelete(DeleteBehavior.Cascade)
                        );

        }
    }
}
