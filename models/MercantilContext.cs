using System;
using Microsoft.EntityFrameworkCore;
using apiMercantil;

namespace apiMercantil.Models
{
    public partial class MercantilContext : DbContext
    {
        public MercantilContext()
        {
        }

        public MercantilContext(DbContextOptions<MercantilContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Enderecos> Enderecos { get; set; }
        public virtual DbSet<Estabelecimentos> Estabelecimentos { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<ProdutosDb> ProdutosDb { get; set; }
        public virtual DbSet<Telefones> Telefones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.ToTable("categorias");
            });           

            modelBuilder.Entity<Estabelecimentos>(entity =>
            {
                entity.ToTable("estabelecimentos");

                entity.Property(e => e.Estabelecimento).HasColumnName("_Estabelecimento");
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.ToTable("produtos");

                entity.HasIndex(e => e.CategoriaId);

                entity.Property(e => e.Produto).HasColumnName("_Produto");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.CategoriaId);
            });

            modelBuilder.Entity<ProdutosDb>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasMaxLength(100);

                entity.Property(e => e.CestCodigo)
                    .HasColumnName("cest_codigo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Codbar)
                    .HasColumnName("codbar")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Embalagem)
                    .HasColumnName("embalagem")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FotoGif)
                    .HasColumnName("foto_gif")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FotoPng)
                    .HasColumnName("foto_png")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FotoTabloideGif)
                    .HasColumnName("foto_tabloide_gif")
                    .HasMaxLength(255);

                entity.Property(e => e.FotoTabloidePng)
                    .HasColumnName("foto_tabloide_png")
                    .HasMaxLength(255);

                entity.Property(e => e.ImgGtin)
                    .HasColumnName("img_gtin")
                    .HasMaxLength(255);

                entity.Property(e => e.Marca)
                    .HasColumnName("marca")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ncm)
                    .HasColumnName("ncm")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Peso)
                    .HasColumnName("peso")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoMedio).HasColumnName("preco_medio");

                entity.Property(e => e.Produto)
                    .HasColumnName("produto")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProdutoAcento)
                    .HasColumnName("produto_acento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProdutoUpper)
                    .HasColumnName("produto_upper")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QuantidadeEmbalagem)
                    .HasColumnName("quantidade_embalagem")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
