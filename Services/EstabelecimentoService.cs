using apiMercantil.Models;
using System.Linq;
namespace ApiMercantil.Services
{
    public class EstabelecimentoService
    {
        private readonly MercantilContext _context;
        public EstabelecimentoService(MercantilContext context){
            _context = context;
        }
        // public bool ValidarEstabelecimento(string cnpj){
        //     var retorno = _context.Estabelecimentos.Where(s => s.Cnpj == cnpj); // (from s in _context.Estabelecimentos where s.Cnpj == cnpj select s)
        //     return false;
        // }
    }
}