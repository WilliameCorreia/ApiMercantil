using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace apiMercantil.Models
{
    public partial class Estabelecimentos
    {
        public Estabelecimentos()
        {
            Produtos = new HashSet<Produtos>();
        }

        public int Id { get; set; }
        public string Token {get; set;}
        public string Email {get; set;}
        public string Estabelecimento { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public Boolean Ativo {get; set;}
        public string Telefones { get; set; }
        public string Enderecos { get; set; }
        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
