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
    public class ProdutosDbController : ControllerBase
    {
        private readonly MercantilContext _context;

        public ProdutosDbController(MercantilContext context)
        {
            _context = context;
        }

        [HttpGet("{pagina}")]
        public IActionResult GetAllProdutos(int pagina)
        {
            const int itensPorPagina = 5;

            var produtos = _context.ProdutosDb.ToPagedList(pagina, itensPorPagina);

            return Ok(produtos);
        }

        [HttpGet("categoria/{categoria}/{pagina}")]
        public IActionResult GetAllCategorias(string categoria, int pagina)
        {
            const int itensPorPagina = 5;

            var produtos = (from produto in _context.ProdutosDb where produto.Categoria == categoria select produto).ToPagedList(pagina, itensPorPagina);

            return Ok(produtos);
        }

        [HttpGet("getcategorias")]
        public IActionResult Categorias()
        {
            var _categorias = from categoria in _context.ProdutosDb select categoria.Categoria;

            return Ok(_categorias.Distinct());
        }

        [HttpGet("codbar/{codbar}")]
        public IActionResult Index(string codbar)
        {

            var produto = (from c in _context.ProdutosDb where c.Codbar == codbar select c).FirstOrDefault<ProdutosDb>();

            return Ok(produto);
        }

    }
}