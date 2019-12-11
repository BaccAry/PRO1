using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRO1.Models
{
    public partial class s17230Context : DbContext
    {
        public s17230Context()
        {
        }

        public s17230Context(DbContextOptions<s17230Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<Rozmiar> Rozmiar { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17230;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdministrator);

                entity.Property(e => e.IdAdministrator).ValueGeneratedNever();

                entity.HasOne(d => d.IdUzytkownikNavigation)
                    .WithMany(p => p.Administrator)
                    .HasForeignKey(d => d.IdUzytkownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Administrator_Uzytkownik");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza);

                entity.Property(e => e.IdPizza).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRozmiarNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.IdRozmiar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Rozmiar");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Skladnik");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocja);

                entity.Property(e => e.IdPromocja).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.Promocja)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promocja_Pizza");
            });

            modelBuilder.Entity<Rozmiar>(entity =>
            {
                entity.HasKey(e => e.IdRozmiar);

                entity.Property(e => e.IdRozmiar).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik);

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.IdUzytkownik);

                entity.Property(e => e.IdUzytkownik).ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DataUrodzenia).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie);

                entity.Property(e => e.IdZamowienie).ValueGeneratedNever();

                entity.Property(e => e.DataZamowienia).HasColumnType("date");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPizza)
                    .HasConstraintName("Zamowienie_Pizza");

                entity.HasOne(d => d.IdPromocjaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPromocja)
                    .HasConstraintName("Zamowienie_Promocja");

                entity.HasOne(d => d.IdUzytkownikNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdUzytkownik)
                    .HasConstraintName("Zamowienie_Uzytkownik");
            });
        }
    }
}
