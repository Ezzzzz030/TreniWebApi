using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TreniDataModel.Models;

public partial class TreniDbContext : DbContext
{
    public TreniDbContext()
    {
    }

    public TreniDbContext(DbContextOptions<TreniDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Stazione> Staziones { get; set; }

    public virtual DbSet<TrattaRiga> TrattaRigas { get; set; }

    public virtual DbSet<TrattaTestum> TrattaTesta { get; set; }

    public virtual DbSet<Treno> Trenos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=RICCARDOPC;Database=TreniDB;User Id=sa;Password=Omega123;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stazione>(entity =>
        {
            entity.ToTable("STAZIONE");

            entity.Property(e => e.Indirizzo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TrattaRiga>(entity =>
        {
            entity.HasKey(e => new { e.IdTratta, e.Sequenza }).HasName("PK_TRATTA_RIGA_1");

            entity.ToTable("TRATTA_RIGA");

            entity.Property(e => e.IdTratta).HasColumnName("IdTRATTA");
            entity.Property(e => e.IdStazione).HasColumnName("IdSTAZIONE");

            entity.HasOne(d => d.IdTrattaNavigation).WithMany(p => p.TrattaRigas)
                .HasForeignKey(d => d.IdTratta)
                .HasConstraintName("FK_TRATTA_RIGA_TRATTA_TESTA");
        });

        modelBuilder.Entity<TrattaTestum>(entity =>
        {
            entity.ToTable("TRATTA_TESTA");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Treno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TRENI");

            entity.ToTable("TRENO");

            entity.Property(e => e.Linea)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.ToTable("UTENTE");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
