using Cp3_Cadastro.Models;
using Cp3_Cadastro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cp3_Cadastro.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoarepository;

        public PessoaController(IPessoaRepository pessoarepository)
        {
            _pessoarepository = pessoarepository;
        }

        public IActionResult Index()
        {
            List<PessoaModel> pessoas = _pessoarepository.BuscarTodos();
            return View(pessoas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id_pessoa)
        {
            PessoaModel pessoa = _pessoarepository.ListarPorId(id_pessoa);
            return View(pessoa);
        }

        public IActionResult ApagarConfirmacao(int id_pessoa)
        {
            PessoaModel pessoa = _pessoarepository.ListarPorId(id_pessoa);
            return View(pessoa);
        }

        public IActionResult Apagar(int id_pessoa)
        {
            _pessoarepository.Apagar(id_pessoa);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(PessoaModel pessoa)
        {
            _pessoarepository.Adicionar(pessoa);
            return RedirectToAction("Criar", "Endereco", new {id_pessoa = pessoa.id_pessoa});
        }

        [HttpPost]
        public IActionResult Alterar(PessoaModel pessoa)
        {
            _pessoarepository.Atualizar(pessoa);
            return RedirectToAction("Index");
        }
    }
}
