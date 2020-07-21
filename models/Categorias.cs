using System;
using System.Collections.Generic;

namespace apiMercantil.Models
{
    public class Categorias
    {
        public Categorias()
        {
            Produtos = new HashSet<Produtos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeBusca { get; set; }
        public string CategoriaPng { get; set; }

        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
