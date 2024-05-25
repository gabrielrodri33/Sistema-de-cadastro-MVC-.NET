using Cp3_Cadastro.Models;
using Cp3_Cadastro.Persistence;
using Cp3_Cadastro.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Cp3_Cadastro.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly OracleDbContext _bancoContext;

        public PessoaRepository(OracleDbContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public PessoaModel ListarPorId(int id_pessoa)
        {
            return _bancoContext.Pessoa.FirstOrDefault(x => x.id_pessoa == id_pessoa);
        }

        public List<PessoaModel> BuscarTodos()
        {
            return _bancoContext.Pessoa.ToList();
        }

        public PessoaModel Adicionar(PessoaModel pessoa)
        {
            _bancoContext.Pessoa.Add(pessoa);
            _bancoContext.SaveChanges();
            return pessoa;
        }

        public PessoaModel Atualizar(PessoaModel pessoa)
        {
            PessoaModel pessoaDb = ListarPorId(pessoa.id_pessoa);

            if (pessoaDb == null) throw new System.Exception("Houve um erro ao atualizar os dados da Pessoa");

            pessoaDb.nome_pessoa = pessoa.nome_pessoa;
            pessoaDb.email_pessoa = pessoa.email_pessoa;
            pessoaDb.senha_pessoa = pessoa.senha_pessoa;
            pessoaDb.cpf_pessoa = pessoa.cpf_pessoa;

            _bancoContext.Pessoa.Update(pessoaDb);
            _bancoContext.SaveChanges();
            return pessoaDb;
        }

        public bool Apagar(int id_pessoa)
        {
            PessoaModel pessoaDb = ListarPorId(id_pessoa);

            if (pessoaDb == null) throw new System.Exception("Houve um erro ao apagar os dados da Pessoa");

            _bancoContext.Pessoa.Remove(pessoaDb);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}