using System.Collections.Generic;
using System.Linq;
using apiMercantil.Models;

namespace apiMercantil.Services
{
    public class CategoriaService
    {
        private readonly MercantilContext _context;
        public CategoriaService(MercantilContext context)
        {
            _context = context;
        }

        public IEnumerable<Categorias> GetAllCategorias(){
            var categorias = _context.Categorias.ToList();
            return categorias;
        }

        public Categorias find(int id){
            var categoria = _context.Categorias.FirstOrDefault(item => item.Id == id);

            return categoria;
        }

        public void AddCategoria(Categorias categoria){
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void delete(int id){
            var categoria = _context.Categorias.First(categoria => categoria.Id == id);
            _context.Remove(categoria);
            _context.SaveChanges();
        }

        public void update(int id, Categorias categoria){
            var _categoria = find(id);
            _categoria = categoria;
            _context.Categorias.Update(_categoria);
            _context.SaveChanges();
        }
    }
}