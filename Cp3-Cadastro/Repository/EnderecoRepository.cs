using Cp3_Cadastro.Models;
using Cp3_Cadastro.Persistence;
using System.ComponentModel.DataAnnotations;

namespace Cp3_Cadastro.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly OracleDbContext _bancoContext;

        public EnderecoRepository (OracleDbContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public EnderecoModel ListarPorId(int id_endereco)
        {
            return _bancoContext.Endereco.FirstOrDefault(x => x.id_endereco == id_endereco);
        }
        public List<EnderecoModel> BuscarTodos()
        {
            return _bancoContext.Endereco.ToList();
        }

        public EnderecoModel Adicionar(EnderecoModel endereco)
        {
            _bancoContext.Endereco.Add(endereco);
            _bancoContext.SaveChanges();
            return endereco;
        }

        public EnderecoModel Atualizar(EnderecoModel endereco)
        {
            EnderecoModel enderecoDb = ListarPorId(endereco.id_endereco);

            if (enderecoDb == null) throw new Exception("Erro ao atualizar o Endereço!");

            enderecoDb.rua_endereco = endereco.rua_endereco;
            enderecoDb.complemento_endereco = endereco.complemento_endereco;
            enderecoDb.bairro_endereco = endereco.bairro_endereco;
            enderecoDb.cidade_endereco = endereco.cidade_endereco;
            enderecoDb.estado_endereco = endereco.estado_endereco;
            enderecoDb.cep_endereco = endereco.cep_endereco;
            

            _bancoContext.Endereco.Update(enderecoDb);
            _bancoContext.SaveChanges();
            return enderecoDb;
        }
        public bool Apagar(int id_endereco)
        {
            EnderecoModel enderecoDb = ListarPorId(id_endereco);

            if (enderecoDb == null) throw new System.Exception("Erro ao apagar o Endereço!");

            _bancoContext.Endereco.Remove(enderecoDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}