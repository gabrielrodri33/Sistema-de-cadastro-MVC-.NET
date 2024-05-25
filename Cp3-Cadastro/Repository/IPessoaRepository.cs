using Cp3_Cadastro.Models;

namespace Cp3_Cadastro.Repositories
{
    public interface IPessoaRepository
    {
        PessoaModel ListarPorId(int id_pessoa);
        List<PessoaModel> BuscarTodos();
        PessoaModel Adicionar(PessoaModel pessoa);
        PessoaModel Atualizar(PessoaModel pessoa);
        bool Apagar(int id_pessoa);
    }
}
