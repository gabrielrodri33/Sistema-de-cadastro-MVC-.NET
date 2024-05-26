using Cp3_Cadastro.Models;

namespace Cp3_Cadastro.Repository
{
    public interface IEnderecoRepository
    {
        EnderecoModel ListarPorId(int id_endereco);
        List<EnderecoModel> BuscarTodos();
        EnderecoModel Adicionar(EnderecoModel endereco);
        EnderecoModel Atualizar(EnderecoModel endereco);
        bool Apagar(int id_endereco);
    }
}
