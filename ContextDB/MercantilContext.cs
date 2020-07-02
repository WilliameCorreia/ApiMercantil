using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using apiMercantil.models;

namespace apiMercantil.ContextDB
{
    public class MercantilContext:DbContext
    {
        public MercantilContext(DbContextOptions<MercantilContext> options)
            :base(options){
        }
        public DbSet<Categoria> categorias {get; set;}
        public DbSet<Produto> produtos {get; set;}
        public DbSet<Estabelecimento> estabelecimentos {get; set;}
        public DbSet<Endereco> enderecos {get; set;}
        public DbSet<Telefone> telefones {get; set;}
    }
}