using Cp3_Cadastro.Models;
using Cp3_Cadastro.Persistence;
using Cp3_Cadastro.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cp3_Cadastro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly OracleDbContext _oracleDbContext;

        //public HomeController (OracleDbContext oracleDbContext)
        //{
        //    _oracleDbContext = oracleDbContext;
        //}

        public HomeController(ILogger<HomeController> logger, OracleDbContext oracleDbContext)
        {
            _logger = logger;
            _oracleDbContext = oracleDbContext;
        }

        public IActionResult Index()
        {
            var totalPessoas = _oracleDbContext.Pessoa.Count();
            var totalEnderecos = _oracleDbContext.Endereco.Count();

            var viewModel = new HomeViewModel
            {
                TotalPessoas = totalPessoas,
                TotalEnderecos = totalEnderecos,
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
