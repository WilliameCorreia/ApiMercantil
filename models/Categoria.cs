using System.Collections.Generic;

namespace apiMercantil.models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeBusca { get; set; }
        public string CategoriaPng { get; set; }
        public List<Produto> ProdutoId { get; set; }
    }
}