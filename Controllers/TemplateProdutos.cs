using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiMercantil.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace apiMercantil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateProdutosController : ControllerBase
    {
        private readonly MercantilContext _context;

        public TemplateProdutosController(MercantilContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProdutos(int pagina = 1)
        {
            const int itensPorPagina = 5;

            var produtos = _context.ProdutosDb.ToPagedList(pagina, itensPorPagina);

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Index(string id)
        {

            var produto = (from c in _context.ProdutosDb where c.Codbar == id select c).FirstOrDefault<ProdutosDb>();

            // _context.ProdutosDb.Find()


            return Ok(produto);
        }

    }
}