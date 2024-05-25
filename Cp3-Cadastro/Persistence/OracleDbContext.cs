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
    }
}
