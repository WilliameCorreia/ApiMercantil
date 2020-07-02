using System.Collections.Generic;

namespace apiMercantil.models
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string _Estabelecimento { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public List<Endereco> EndercoId { get; set; }
        public List<Telefone> NumeroId { get; set; }
    }
}