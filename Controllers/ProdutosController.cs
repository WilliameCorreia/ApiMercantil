using apiMercantil.Models;
using apiMercantil.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiMercantil.Controllers
{

    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtosService;

        public ProdutosController(ProdutoService produtosService)
        {
            _produtosService = produtosService;
        }

        [HttpGet]
        public ActionResult Index()
        {

            var Lista_produtos = _produtosService.GetAllProdutos();

            return Ok(Lista_produtos);
        }

        [HttpGet("{id}", Name = "getProduto")]
        public ActionResult getById(int id)
        {
            var produto = _produtosService.find(id);

            if (produto == null)
            {
                return BadRequest();
            }
            else
            {
                return new ObjectResult(produto);
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] Produtos produto)
        {
            if(produto == null){
                return BadRequest();
            }else{
                _produtosService.AddProduto(produto);
                return CreatedAtRoute("getProduto", new{id = produto.Id}, produto);
            }
        }

        [HttpDelete("{id")]
        public ActionResult Delete(int id){
            if(id == 0){
              return BadRequest();
            }else{
                _produtosService.delete(id);
                return Ok();
            }
        }

        [HttpPut("id")]
        public ActionResult Update(int id,[FromBody] Produtos produto){
            if(produto.Id != id || produto == null){
                return BadRequest();
            }else{
                _produtosService.update(id, produto);
                 return Ok();
            }
        }
    }
}