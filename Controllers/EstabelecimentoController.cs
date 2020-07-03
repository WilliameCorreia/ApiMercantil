using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiMercantil.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<ProdutosDb> Index(){
            // var lista = _context.ProdutosDb.ToList();
            return _context.ProdutosDb.ToList();
            
        }
    }
}