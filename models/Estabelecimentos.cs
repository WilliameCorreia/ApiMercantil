using System;
using System.Collections.Generic;

namespace apiMercantil.Models
{
    public partial class Estabelecimentos
    {
        public Estabelecimentos()
        {
            Enderecos = new HashSet<Enderecos>();
            Telefones = new HashSet<Telefones>();
            Produtos = new HashSet<Produtos>();
        }

        public int Id { get; set; }
        public string Token {get; set;}
        public string Email {get; set;}
        public string Estabelecimento { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public Boolean Ativo {get; set;}
        public virtual ICollection<Produtos> Produtos { get; set; }
        public virtual ICollection<Enderecos> Enderecos { get; set; }
        public virtual ICollection<Telefones> Telefones { get; set; }
    }
}
