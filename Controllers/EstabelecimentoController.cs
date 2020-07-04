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
    public class EstabelecimentoController : ControllerBase
    {
        private readonly MercantilContext _context;

        public EstabelecimentoController(MercantilContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int pagina = 2){
            const int itensPorPagina = 5;
            
            var produtos = _context.ProdutosDb.ToPagedList(pagina, itensPorPagina);

            return Ok(produtos);
        }

    }
}