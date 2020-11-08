using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SquadraWeb.Api.Models;

namespace SquadraWeb.Api
{
    public partial class SquadraWEBContext : DbContext
    {
        public SquadraWEBContext()
        {
        }

        public SquadraWEBContext(DbContextOptions<SquadraWEBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<Venda> Venda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-38K4DAU;Database=SquadraWEB;User Id=DESKTOP-38K4DAU\\Leslye Esteves Gomes;Password=;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("endereco")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__Livro__99F9D0A5D5A60A24");

                entity.Property(e => e.Isbn)
                    .HasColumnName("isbn")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasColumnName("autor")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Editora)
                    .IsRequired()
                    .HasColumnName("editora")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Preco)
                    .HasColumnName("preco")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataCompra)
                    .HasColumnName("data_compra")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdLivro)
                    .IsRequired()
                    .HasColumnName("idLivro")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__ItemVenda__idCli__403A8C7D");

                entity.HasOne(d => d.Livro)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemVenda__idLiv__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
