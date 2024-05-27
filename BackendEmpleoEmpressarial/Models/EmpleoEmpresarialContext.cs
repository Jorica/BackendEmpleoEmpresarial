using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendEmpleoEmpressarial.Models;

public partial class EmpleoEmpresarialContext : DbContext
{
    public EmpleoEmpresarialContext()
    {
    }

    public EmpleoEmpresarialContext(DbContextOptions<EmpleoEmpresarialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleo> Empleos { get; set; }

    public virtual DbSet<EmpleoUsuario> EmpleoUsuarios { get; set; }

    public virtual DbSet<EstadoEmpleoUsuario> EstadoEmpleoUsuarios { get; set; }

    public virtual DbSet<ModalidadTrabajo> ModalidadTrabajos { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleo__3214EC270B5CFE28");

            entity.ToTable("Empleo");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaHoraRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Salario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModalidadTrabajoNavigation).WithMany(p => p.Empleos)
                .HasForeignKey(d => d.IdModalidadTrabajo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleo__IdModali__37A5467C");
        });

        modelBuilder.Entity<EmpleoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EmpleoUs__3214EC27FCA4BCEB");

            entity.ToTable("EmpleoUsuario");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Observacion)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleoNavigation).WithMany(p => p.EmpleoUsuarios)
                .HasForeignKey(d => d.IdEmpleo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmpleoUsu__IdEmp__3B75D760");

            entity.HasOne(d => d.IdEstadoEmpleoUsuarioNavigation).WithMany(p => p.EmpleoUsuarios)
                .HasForeignKey(d => d.IdEstadoEmpleoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmpleoUsu__IdEst__3D5E1FD2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.EmpleoUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmpleoUsu__IdUsu__3C69FB99");
        });

        modelBuilder.Entity<EstadoEmpleoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstadoEm__3214EC277473CD13");

            entity.ToTable("EstadoEmpleoUsuario");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodigoGrupo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ModalidadTrabajo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Modalida__3214EC27AE2F5E37");

            entity.ToTable("ModalidadTrabajo");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.TipoUsuarioId).HasName("PK__TipoUsua__7F22C70233968892");

            entity.ToTable("TipoUsuario");

            entity.Property(e => e.TipoUsuarioId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("TipoUsuarioID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798D11418C0");

            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TipoUsuarioId).HasColumnName("TipoUsuarioID");

            entity.HasOne(d => d.TipoUsuario).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__TipoUsu__2E1BDC42");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
