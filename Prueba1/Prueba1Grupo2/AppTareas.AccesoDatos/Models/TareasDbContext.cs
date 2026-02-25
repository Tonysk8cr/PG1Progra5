using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AppTareas.Entities;

namespace AppTareas.AccesoDatos.Models;

public partial class TareasDbContext : DbContext
{
    public TareasDbContext()
    {
    }

    public TareasDbContext(DbContextOptions<TareasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tareas__3214EC07B87B1216");

            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Titulo).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
