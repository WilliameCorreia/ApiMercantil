using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiMercantil.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using apiMercantil.Services;
namespace apiMercantil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly EstabelecimentoService _context;       


        public EstabelecimentoController(EstabelecimentoService context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {            
            var estabelecimentos = _context.GetAllEstabelecimentos();

            return Ok(estabelecimentos);
        }

        [HttpGet("{token}", Name = "getestabelecimento")]
        public ActionResult getById(string token)
        {
            var estabelecimento = _context.findToken(token);

            if (estabelecimento == null)
            {
                return BadRequest();
            }
            else
            {
                return new ObjectResult(estabelecimento);
            }
        }
        
        [HttpPost]
        public IActionResult Create ([FromBody] Estabelecimentos estabelecimento){
            if(estabelecimento == null){
                return BadRequest();
            }else{
                _context.AddEstabelecimento(estabelecimento);
                return CreatedAtRoute("getestabelecimento", new{id = estabelecimento.Id}, estabelecimento);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            if(id == 0){
              return BadRequest();
            }else{
                _context.delete(id);
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id,[FromBody] Estabelecimentos estabelecimento){
            if(estabelecimento.Id != id || estabelecimento == null){
                return BadRequest();
            }else{
                _context.update(id, estabelecimento);
                 return Ok();
            }
        }

    }
}