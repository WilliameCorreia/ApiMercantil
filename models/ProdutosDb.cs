using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiMercantil.Models
{
    public partial class ProdutosDb
    {
        [Key]
        public string Codbar { get; set; }
        public string Produto { get; set; }
        public string ProdutoUpper { get; set; }
        public string ProdutoAcento { get; set; }
        public string Peso { get; set; }
        public string Ncm { get; set; }
        public string CestCodigo { get; set; }
        public string Embalagem { get; set; }
        public string QuantidadeEmbalagem { get; set; }
        public string FotoPng { get; set; }
        public string FotoGif { get; set; }
        public string Marca { get; set; }
        public float? PrecoMedio { get; set; }
        public string ImgGtin { get; set; }
        public string Categoria { get; set; }
        public string FotoTabloidePng { get; set; }
        public string FotoTabloideGif { get; set; }
    }
}
