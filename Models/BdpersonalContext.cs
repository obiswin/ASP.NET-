using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace practica04.Models;

public partial class BdpersonalContext : DbContext
{
    public BdpersonalContext()
    {
    }

    public BdpersonalContext(DbContextOptions<BdpersonalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatosPersonale> DatosPersonales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            //      => optionsBuilder.UseSqlServer(" server=GALAXY10\\SQLEXPRESS; database=bdpersonal; integrated security=true; TrustServerCertificate=True;");

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatosPersonale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DatosPer__3214EC27D7ED645D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Carnet).HasMaxLength(20);
            entity.Property(e => e.Celular).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
