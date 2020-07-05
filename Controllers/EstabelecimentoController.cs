using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiMercantil.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using apiMercantil.Services;
namespace apiMercantil.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly MercantilContext _context;


        public EstabelecimentoController(MercantilContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var estabelecimentos = _context.Estabelecimentos.ToList();


            return Ok(estabelecimentos);
        }
        public string teste(string cnpj)
        {
            var retorno = _context.Estabelecimentos.Where(s => s.Cnpj == cnpj).Select(s => s.Cnpj).Count();
            if (retorno > 0)
            {
                return "false";
            }
            else
            {
                return "true";
            }

        }
        [HttpPost]
        public void Index(Estabelecimentos estabelecimento)
        {
            var existe = _context.Estabelecimentos.Where(s => s.Cnpj == estabelecimento.Cnpj).Select(s => s.Cnpj).Count();
            if (existe <= 0)
            {
                _context.Add(estabelecimento);
                _context.SaveChanges();
            }



        }

    }
}