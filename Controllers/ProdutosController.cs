using apiMercantil.Models;
using apiMercantil.Services;
using Microsoft.AspNetCore.Mvc;


namespace apiMercantil.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtosService;

        public ProdutosController(ProdutoService produtosService)
        {
            _produtosService = produtosService;
        }

        [HttpGet("{id}/{pagina}")]
        public ActionResult Index(int id , int pagina)
        {
            var Lista_produtos = _produtosService.GetAllProdutos(id, pagina);

            return Ok(Lista_produtos);
        }

        [HttpGet("pesquisar/{palavra}/{pagina}")]
        public ActionResult PesquisarProduto(string  palavra, int pagina)
        {
            var Lista_produtos = _produtosService.Contain(palavra, pagina);

            return Ok(Lista_produtos);
        }

        [HttpGet("{categoria}/{id}/{pagina}")]
        public ActionResult GetAllCategorias(int categoria, int id, int pagina)
        {
           var Lista_produtos = _produtosService.GetAllProdutosCategorias(categoria, id, pagina);

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

        [HttpGet("codbar/{codbar}")]
        public IActionResult getCodBar(string codbar)
        {
           var produto = _produtosService.findCodBar(codbar);

           if(produto == null){
               return Ok(0);
           }else{
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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            if(id == 0){
              return BadRequest();
            }else{
                _produtosService.delete(id);
                return Ok();
            }
        }

        [HttpPut("{id}")]
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