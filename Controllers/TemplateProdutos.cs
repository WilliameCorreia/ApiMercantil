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

        [HttpGet("{pagina}")]
        public IActionResult GetAllProdutos(int pagina = 1)
        {
            const int itensPorPagina = 5;

            var produtos = _context.ProdutosDb.ToPagedList(pagina, itensPorPagina);

            return Ok(produtos);
        }

        [HttpGet("categoria/{categoria}/{pagina}")]
        public IActionResult GetAllCategorias(string categoria, int pagina = 1)
        {
            const int itensPorPagina = 5;

            var produtos = (from produto in _context.ProdutosDb where produto.Categoria == categoria select produto).ToPagedList(pagina, itensPorPagina);

            return Ok(produtos);
        }

        /* [HttpGet("getcategorias/{categoria}")]
        public IActionResult Categorias(string categoria)
        {
            var produtos = (from produto in _context.ProdutosDb where produto.Categoria == categoria select produto);

            return Ok(produtos);
        } */

        [HttpGet("codbar/{codbar}")]
        public IActionResult Index(string codbar)
        {

            var produto = (from c in _context.ProdutosDb where c.Codbar == codbar select c).FirstOrDefault<ProdutosDb>();

            return Ok(produto);
        }

    }
}