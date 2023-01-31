using API_ORDEM_SERVICO.Data.Mappings;
using API_ORDEM_SERVICO.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ORDEM_SERVICO.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Finalizacao> Finalizacoes { get; set; }
        public DbSet<Ordem_De_Servico> Ordems_De_servico { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7NS6MBC\\SQLEXPRESS;Initial Catalog=ordem_servico;Integrated Security=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new FinalizacaoMap());
            modelBuilder.ApplyConfiguration(new Ordem_De_ServicoMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());
            modelBuilder.ApplyConfiguration(new TecnicoMap());
        }

    }
}
