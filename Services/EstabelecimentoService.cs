using apiMercantil.Models;
using System.Collections.Generic;
using System.Linq;
namespace apiMercantil.Services
{
    public class EstabelecimentoService
    {
        private readonly MercantilContext _context;
        public EstabelecimentoService(MercantilContext context){
            _context = context;
        }
        public IEnumerable<Estabelecimentos> GetAllEstabelecimentos()
        {

            var estabelecimentos = _context.Estabelecimentos.ToList();

            return estabelecimentos;
        }

        public Estabelecimentos find(int id)
        {

            var estabelecimentos = _context.Estabelecimentos.FirstOrDefault(item => item.Id == id);

            return estabelecimentos;
        }

        public Estabelecimentos findToken(string token)
        {

            var estabelecimentos = _context.Estabelecimentos.FirstOrDefault(item => item.Token == token);

            return estabelecimentos;
        }

        public bool AddEstabelecimento(Estabelecimentos estabelecimento)
        {
            var retorno = _context.Estabelecimentos.Where(s => s.Cnpj == estabelecimento.Cnpj).Select(s => s.Cnpj).Count();
            if(retorno <= 0){
                _context.Estabelecimentos.Add(estabelecimento);
                _context.SaveChanges();
                return true;
            }else{
                return false;
            }
        }

        public void delete(int id)
        {
            var estabelecimento = _context.Estabelecimentos.FirstOrDefault(estabelecimento => estabelecimento.Id == id);
            _context.Remove(estabelecimento);
            _context.SaveChanges();
        }

        public void update(int id, Estabelecimentos estabelecimento)
        {
            var _estabelecimento = find(id);
            _estabelecimento.Token = estabelecimento.Token;
            _estabelecimento.Email = estabelecimento.Email;
            _estabelecimento.Estabelecimento = estabelecimento.Estabelecimento;
            _estabelecimento.Cnpj = estabelecimento.Cnpj;
            _estabelecimento.RazaoSocial = estabelecimento.RazaoSocial;
            _estabelecimento.Ativo = estabelecimento.Ativo;
            _estabelecimento.Telefones = estabelecimento.Telefones;
            _estabelecimento.Enderecos = estabelecimento.Enderecos;
            _context.Estabelecimentos.Update(_estabelecimento);
            _context.SaveChanges();
        }
    }
}