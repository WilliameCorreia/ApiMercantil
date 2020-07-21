using apiMercantil.Models;
using apiMercantil.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiMercantil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;
        public CategoriasController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult getCategorias(){
            var categorias =_categoriaService.GetAllCategorias();
            return Ok(categorias);
        }

        [HttpGet("id", Name="getCategoria")]
        public ActionResult getById(int id){

            var categoria = _categoriaService.find(id);

            if(categoria == null){
                return BadRequest();
            }else{
                return new ObjectResult(categoria);
            }
           
        }

        [HttpPost]
        public ActionResult Create([FromBody] Categorias categoria){
            if(categoria == null){
                return BadRequest();
            }else{
                _categoriaService.AddCategoria(categoria);
                return CreatedAtRoute("getCategoria", new{id = categoria.Id}, categoria);
            }
        }
    }
}