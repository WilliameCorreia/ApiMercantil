using System;
using System.Collections.Generic;

namespace apiMercantil.Models
{
    public partial class Enderecos
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
        public string Complemento { get; set; }
        public int? EstabelecimentoId { get; set; }

        public virtual Estabelecimentos Estabelecimento { get; set; }
    }
}
