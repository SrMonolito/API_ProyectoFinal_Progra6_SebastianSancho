using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_ProyectoFinal_Progra6_SebastianSancho.Models;

public partial class ProyectoProgra6Context : DbContext
{
    public ProyectoProgra6Context()
    {
    }

    public ProyectoProgra6Context(DbContextOptions<ProyectoProgra6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TblComentario> TblComentarios { get; set; }

    public virtual DbSet<TblMiembro> TblMiembros { get; set; }

    public virtual DbSet<TblMiembrosTarea> TblMiembrosTareas { get; set; }

    public virtual DbSet<TblProyecto> TblProyectos { get; set; }

    public virtual DbSet<TblRol> TblRols { get; set; }

    public virtual DbSet<TblTarea> TblTareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblComentario>(entity =>
        {
            entity.HasKey(e => e.ComentarioId).HasName("PK__TBL_Come__F18449581837FDCC");

            entity.ToTable("TBL_Comentario");

            entity.Property(e => e.ComentarioId).HasColumnName("ComentarioID");
            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");
            entity.Property(e => e.TareaId).HasColumnName("TareaID");

            entity.HasOne(d => d.Miembro).WithMany(p => p.TblComentarios)
                .HasForeignKey(d => d.MiembroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Comen__Miemb__5629CD9C");

            entity.HasOne(d => d.Tarea).WithMany(p => p.TblComentarios)
                .HasForeignKey(d => d.TareaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Comen__Tarea__5535A963");
        });

        modelBuilder.Entity<TblMiembro>(entity =>
        {
            entity.HasKey(e => e.MiembroId).HasName("PK__TBL_Miem__CC213FB9E534A393");

            entity.ToTable("TBL_Miembro");

            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.TblMiembros)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Miemb__RolID__4F7CD00D");
        });

        modelBuilder.Entity<TblMiembrosTarea>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBL_Miembros_Tarea");

            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");

            entity.HasOne(d => d.Miembro).WithMany()
                .HasForeignKey(d => d.MiembroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Miemb__Miemb__5165187F");

            entity.HasOne(d => d.Tarea).WithMany()
                .HasForeignKey(d => d.TareaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Miemb__Tarea__52593CB8");
        });

        modelBuilder.Entity<TblProyecto>(entity =>
        {
            entity.HasKey(e => e.ProyectoId).HasName("PK__TBL_Proy__CF241D45A4611EA7");

            entity.ToTable("TBL_Proyecto");

            entity.Property(e => e.ProyectoId).HasColumnName("ProyectoID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblRol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__TBL_Rol__F92302D13C83812B");

            entity.ToTable("TBL_Rol");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblTarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PK__TBL_Tare__5CD836716CAEF34C");

            entity.ToTable("TBL_Tareas");

            entity.Property(e => e.TareaId).HasColumnName("TareaID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
