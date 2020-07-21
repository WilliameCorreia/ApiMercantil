using System;
using System.Collections.Generic;

namespace apiMercantil.Models
{
    public partial class Produtos
    {
        public int Id { get; set; }
        public string Produto { get; set; } 
        public string CodeBar { get; set; }
        public string Marca { get; set; }
        public string Unidade { get; set; }
        public string FotoPng { get; set; }
        public int Quantidade { get; set; }
        public string Preco { get; set; }
        public bool Oferta {get; set;}
        public int? CategoriaId { get; set; }
        public int? EstabelecimentoId {get; set;}
        public virtual Estabelecimentos Estabelecimento {get; set;}
        public virtual Categorias Categoria { get; set; }
    }
}
