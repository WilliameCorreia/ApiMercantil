using System.Collections.Generic;
using System.Linq;
using apiMercantil.Models;
using X.PagedList;

namespace apiMercantil.Services
{
    public class ProdutoService
    {
        private readonly MercantilContext _context;

        public ProdutoService(MercantilContext context)
        {
            _context = context;
        }

        public IEnumerable<Produtos> GetAllProdutos(int id , int pagina)
        {
            const int itensPorPagina = 5;

            //var produtos = _context.Produtos.ToList().ToPagedList(pagina, itensPorPagina);

            var produtos = _context.Produtos.Where(produto => produto.EstabelecimentoId == id).ToPagedList(pagina, itensPorPagina);

            return produtos;
        }

        public IEnumerable<Produtos> Contain( int estabelecimentoId, int categoriaId, string palavra , int pagina)
        {
            const int itensPorPagina = 5;

            //var produtos = from c in _context.Produtos where c.EstabelecimentoId == estabelecimentoId && c.CategoriaId == categoriaId select c;
            
            var produtos = _context.Produtos.Where(
                produto => produto.EstabelecimentoId == estabelecimentoId && produto.CategoriaId == categoriaId && produto.Produto.Contains(palavra)).ToPagedList(pagina, itensPorPagina);
           
            return produtos;
        }

        public IEnumerable<Produtos> GetAllProdutosCategorias(int categoriaId, int Estabelecimentoid, int pagina){

            const int itensPorPagina = 5;

            var produtos = _context.Produtos.Where(
                produto => produto.EstabelecimentoId == Estabelecimentoid && produto.CategoriaId == categoriaId).ToPagedList(pagina, itensPorPagina);

            return produtos;

        }

        public Produtos find(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(item => item.Id == id);

            return produto;
        }

         public Produtos findCodBar(string codBar)
        {
            var produto = _context.Produtos.FirstOrDefault(item => item.CodeBar == codBar);

            return produto;
        }

        public void AddProduto(Produtos produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var produto = _context.Produtos.First(produto => produto.Id == id);
            _context.Remove(produto);
            _context.SaveChanges();
        }

        public void update(int id, Produtos produto)
        {
            var _produto = find(id);
            _produto = produto;
            _context.Produtos.Update(_produto);
            _context.SaveChanges();
        }
    }
}