using System;
using System.Collections.Generic;

namespace apiMercantil.Models
{
    public partial class Telefones
    {
        public int Id { get; set; }
        public int Ddd { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public int? EstabelecimentoId { get; set; }

        public virtual Estabelecimentos Estabelecimento { get; set; }
    }
}
