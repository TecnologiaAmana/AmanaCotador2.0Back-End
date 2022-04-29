using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using amanaWebAPI.Domains;

#nullable disable

namespace amanaWebAPI.Context
{
    public partial class CotadorContext : DbContext
    {
        public CotadorContext()
        {
        }

        public CotadorContext(DbContextOptions<CotadorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cotacao> Cotacaos { get; set; }
        public virtual DbSet<Cultura> Culturas { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Nivelcobertura> Nivelcoberturas { get; set; }
        public virtual DbSet<Plantio> Plantios { get; set; }
        public virtual DbSet<Seguradora> Seguradoras { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Uf> Ufs { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Versaosaca> Versaosacas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__CLIENTE__885457EE96A60B94");

                entity.ToTable("CLIENTE");

                entity.HasIndex(e => e.IdUsuario, "UQ__CLIENTE__645723A78552F6DF")
                    .IsUnique();

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.IdUsuario)
                    .HasConstraintName("FK__CLIENTE__idUsuar__2B3F6F97");
            });

            modelBuilder.Entity<Cotacao>(entity =>
            {
                entity.HasKey(e => e.IdCotacao)
                    .HasName("PK__COTACAO__3454BFA70A3C6208");

                entity.ToTable("COTACAO");

                entity.Property(e => e.IdCotacao).HasColumnName("idCotacao");

                entity.Property(e => e.IdPlantio).HasColumnName("idPlantio");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Lmgareplantio).HasColumnName("LMGAReplantio");

                entity.Property(e => e.PeriodoSaca)
                    .HasColumnType("date")
                    .HasColumnName("periodoSaca");

                entity.Property(e => e.ProdutividadeEsperada).HasColumnName("produtividadeEsperada");

                entity.Property(e => e.TaxaBasica).HasColumnName("taxaBasica");

                entity.Property(e => e.TaxaReplantio).HasColumnName("taxaReplantio");

                entity.Property(e => e.ValorSaca).HasColumnName("valorSaca");

                entity.Property(e => e.VersaoSaca).HasColumnName("versaoSaca");

                entity.HasOne(d => d.IdPlantioNavigation)
                    .WithMany(p => p.Cotacaos)
                    .HasForeignKey(d => d.IdPlantio)
                    .HasConstraintName("FK__COTACAO__idPlant__4316F928");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cotacaos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__COTACAO__idUsuar__4222D4EF");

                entity.HasOne(d => d.VersaoSacaNavigation)
                    .WithMany(p => p.Cotacaos)
                    .HasForeignKey(d => d.VersaoSaca)
                    .HasConstraintName("FK__COTACAO__versaoS__440B1D61");
            });

            modelBuilder.Entity<Cultura>(entity =>
            {
                entity.HasKey(e => e.IdCultura)
                    .HasName("PK__CULTURA__2962D6F4594DA139");

                entity.ToTable("CULTURA");

                entity.HasIndex(e => e.Nome, "UQ__CULTURA__6F71C0DC95C140FD")
                    .IsUnique();

                entity.Property(e => e.IdCultura).HasColumnName("idCultura");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK__MUNICIPI__FD10E4003A7791F5");

                entity.ToTable("MUNICIPIO");

                entity.Property(e => e.IdMunicipio).HasColumnName("idMunicipio");

                entity.Property(e => e.IdUf).HasColumnName("idUf");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdUfNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdUf)
                    .HasConstraintName("FK__MUNICIPIO__idUf__37A5467C");
            });

            modelBuilder.Entity<Nivelcobertura>(entity =>
            {
                entity.HasKey(e => e.IdNivelCobertura)
                    .HasName("PK__NIVELCOB__86CEB0C4B2BA5D3D");

                entity.ToTable("NIVELCOBERTURA");

                entity.Property(e => e.IdNivelCobertura)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idNivelCobertura");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<Plantio>(entity =>
            {
                entity.HasKey(e => e.IdPlantio)
                    .HasName("PK__PLANTIO__559C612E1CA0AF80");

                entity.ToTable("PLANTIO");

                entity.Property(e => e.IdPlantio).HasColumnName("idPlantio");

                entity.Property(e => e.IdCultura).HasColumnName("idCultura");

                entity.Property(e => e.IdMunicipio).HasColumnName("idMunicipio");

                entity.Property(e => e.IdNivelCobertura).HasColumnName("idNivelCobertura");

                entity.Property(e => e.IdSeguradora).HasColumnName("idSeguradora");

                entity.HasOne(d => d.IdCulturaNavigation)
                    .WithMany(p => p.Plantios)
                    .HasForeignKey(d => d.IdCultura)
                    .HasConstraintName("FK__PLANTIO__idCultu__3C69FB99");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Plantios)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK__PLANTIO__idMunic__3D5E1FD2");

                entity.HasOne(d => d.IdNivelCoberturaNavigation)
                    .WithMany(p => p.Plantios)
                    .HasForeignKey(d => d.IdNivelCobertura)
                    .HasConstraintName("FK__PLANTIO__idNivel__3B75D760");

                entity.HasOne(d => d.IdSeguradoraNavigation)
                    .WithMany(p => p.Plantios)
                    .HasForeignKey(d => d.IdSeguradora)
                    .HasConstraintName("FK__PLANTIO__idSegur__3A81B327");
            });

            modelBuilder.Entity<Seguradora>(entity =>
            {
                entity.HasKey(e => e.IdSeguradora)
                    .HasName("PK__SEGURADO__CD22E8C6A20696D6");

                entity.ToTable("SEGURADORA");

                entity.HasIndex(e => e.Nome, "UQ__SEGURADO__6F71C0DCAC152FFE")
                    .IsUnique();

                entity.Property(e => e.IdSeguradora).HasColumnName("idSeguradora");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPOUSUA__03006BFFFC06E8BF");

                entity.ToTable("TIPOUSUARIO");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Uf>(entity =>
            {
                entity.HasKey(e => e.IdUf)
                    .HasName("PK__UF__9DB8003712B06AC3");

                entity.ToTable("UF");

                entity.Property(e => e.IdUf).HasColumnName("idUf");

                entity.Property(e => e.Abreviacao)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("abreviacao");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A6DC3AB512");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E6164239343C1")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIO__idTipoU__276EDEB3");
            });

            modelBuilder.Entity<Versaosaca>(entity =>
            {
                entity.HasKey(e => e.IdVersaoSaca)
                    .HasName("PK__VERSAOSA__AC97CC43A872D1AF");

                entity.ToTable("VERSAOSACA");

                entity.Property(e => e.IdVersaoSaca).HasColumnName("idVersaoSaca");

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("valor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
