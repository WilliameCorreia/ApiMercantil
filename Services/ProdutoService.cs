using System.Collections.Generic;
using System.Linq;
using apiMercantil.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace apiMercantil.Services
{
    public class ProdutoService
    {
        private readonly MercantilContext _context;

        private readonly CategoriaService _categoriaService;

        private readonly ProdutoDBSevice _produtoDBService;

        public ProdutoService(MercantilContext context, CategoriaService categoriaService, ProdutoDBSevice produtoDBSevice)
        {
            _context = context;
            _categoriaService = categoriaService;
            _produtoDBService = produtoDBSevice;
        }

        public IEnumerable<Produtos> GetAllProdutos(int EstabelecimentoId, int pagina)
        {
            const int itensPorPagina = 50;

            //var produtos = _context.Produtos.ToList().ToPagedList(pagina, itensPorPagina);

            var produtos = _context.Produtos.Where(produto => produto.EstabelecimentoId == EstabelecimentoId).ToPagedList(pagina, itensPorPagina);

            return produtos;
        }

        public IEnumerable<Produtos> Contain(int estabelecimentoId, int categoriaId, string palavra, int pagina)
        {
            const int itensPorPagina = 50;

            //var produtos = from c in _context.Produtos where c.EstabelecimentoId == estabelecimentoId && c.CategoriaId == categoriaId select c;

            var produtos = _context.Produtos.Include(x => x.Estabelecimento).Include(y => y.Categoria).Where(
                produto => produto.EstabelecimentoId == estabelecimentoId && produto.CategoriaId == categoriaId && produto.Produto.Contains(palavra)).ToPagedList(pagina, itensPorPagina);

            return produtos;
        }

        public IEnumerable<Produtos> GetAllProdutosCategorias(int categoriaId, int Estabelecimentoid, int pagina)
        {

            const int itensPorPagina = 50;

            var produtos = _context.Produtos.Include(x => x.Estabelecimento).Include(y => y.Categoria).Where(
                produto => produto.EstabelecimentoId == Estabelecimentoid && produto.CategoriaId == categoriaId).ToPagedList(pagina, itensPorPagina);

            return produtos;

        }

        public Produtos find(int id)
        {
            var produto = _context.Produtos.Include(x => x.Estabelecimento).Include(y => y.Categoria).FirstOrDefault(item => item.Id == id);

            return produto;
        }

        public Produtos findCodBar(string codBar, int estabelecimentoId)
        {
            var produto = _context.Produtos.FirstOrDefault(item => item.EstabelecimentoId == estabelecimentoId && item.CodeBar == codBar);

            return produto;
        }

        public void AddProduto(Produtos produto)
        {
            Categorias categoria = _categoriaService.find(produto.CategoriaId.Value);

            ProdutosDb produtosDb = new ProdutosDb();

            if (_produtoDBService.GetCodBar(produto.CodeBar))
            {
                produtosDb.Codbar = produto.CodeBar;
                produtosDb.Produto = produto.Produto;
                produtosDb.FotoPng = produto.FotoPng;
                produtosDb.Categoria = categoria.NomeBusca;

                _context.ProdutosDb.Add(produtosDb);
            }

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
            var _produto = find(produto.Id);
            _produto.Produto = produto.Produto;
            _produto.CodeBar = produto.CodeBar;
            _produto.Preco = produto.Preco;
            _produto.Quantidade = produto.Quantidade;
            _produto.CategoriaId = produto.CategoriaId;
            _produto.EstabelecimentoId = produto.EstabelecimentoId;
            _context.Produtos.Update(_produto);
            _context.SaveChanges();
        }
    }
}