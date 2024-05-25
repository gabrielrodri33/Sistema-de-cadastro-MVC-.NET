using Cp3_Cadastro.Models;
using Cp3_Cadastro.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cp3_Cadastro.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public IActionResult Index()
        {
            List<EnderecoModel> enderecos = _enderecoRepository.BuscarTodos();
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }
        
        public IActionResult Editar(int id_endereco)
        {
            EnderecoModel endereco = _enderecoRepository.ListarPorId(id_endereco);
            return View(endereco);
        }

        public IActionResult ApagarConfirmacao(int id_endereco)
        {
            EnderecoModel endereco = _enderecoRepository.ListarPorId(id_endereco);
            return View(endereco);
        }

        public IActionResult Apagar(int id_endereco)
        {
            _enderecoRepository.Apagar(id_endereco);
            return RedirectToAction("Index", "Pessoa");
        }

        [HttpPost]
        public IActionResult Criar(EnderecoModel endereco)
        {
            _enderecoRepository.Adicionar(endereco);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(EnderecoModel endereco)
        {
            _enderecoRepository.Atualizar(endereco);
            return RedirectToAction("Index");
        }
    }
}
