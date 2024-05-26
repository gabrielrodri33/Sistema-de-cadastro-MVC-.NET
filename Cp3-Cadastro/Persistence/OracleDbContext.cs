using Cp3_Cadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace Cp3_Cadastro.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<PessoaModel> Pessoa { get; set; }

        public DbSet<EnderecoModel> Endereco { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaModel>()
                .HasMany(p => p.enderecos)
                .WithOne(e => e.pessoa)
                .HasForeignKey(e => e.id_pessoa)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
