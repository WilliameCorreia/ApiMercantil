using System.Collections.Generic;
using System.Linq;
using apiMercantil.Models;
using X.PagedList;

namespace apiMercantil.Services
{
    public class ProdutoDBSevice
    {
         private readonly MercantilContext _context;
        public ProdutoDBSevice(MercantilContext context)
        {
            _context = context;
        }

        public IEnumerable<ProdutosDb> GetAllProdutosDb(string categoria, int pagina){

            const int itensPorPagina = 5;

            var produtos = (from produto in _context.ProdutosDb where produto.Categoria == categoria select produto).ToPagedList(pagina, itensPorPagina);

            return produtos;
        }

        public IQueryable<string> Categorias(){

            var _categorias = from categoria in _context.ProdutosDb select categoria.Categoria;

            return _categorias;

        }

        public bool GetCodBar(string codbar){

            var produto = (from c in _context.ProdutosDb where c.Codbar == codbar select c).FirstOrDefault<ProdutosDb>();

            if(produto == null){
                return true;
            }else{
                return false;
            }

        }
    }
}