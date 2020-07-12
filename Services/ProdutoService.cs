using System.Collections.Generic;
using System.Linq;
using apiMercantil.Models;

namespace apiMercantil.Services
{
    public class ProdutoService
    {
        private readonly MercantilContext _context;

        public ProdutoService(MercantilContext context)
        {
            _context = context;
        }

        public IEnumerable<Produtos> GetAllProdutos()
        {

            var produtos = _context.Produtos.ToList();

            return produtos;
        }

        public Produtos find(int id)
        {

            var produto = _context.Produtos.FirstOrDefault(item => item.Id == id);

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