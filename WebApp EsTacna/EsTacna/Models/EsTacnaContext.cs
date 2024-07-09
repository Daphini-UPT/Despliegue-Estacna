using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EsTacna.Models;

/**
* Contexto de base de datos para la aplicación EsTacna.
*/

public partial class EsTacnaContext : DbContext
{
    /**
    * Constructor por defecto del contexto de base de datos.
    */
    public EsTacnaContext()
    {
    }

    /**
    * Constructor que recibe opciones de configuración para el contexto de base de datos.
    * @param options Opciones de configuración del contexto.
    */
    public EsTacnaContext(DbContextOptions<EsTacnaContext> options)
        : base(options)
    {
    }

    /**
    * Conjunto de entidades de tipo Busquedum en la base de datos.
    */
    public virtual DbSet<Busquedum> Busqueda { get; set; }

    /**
    * Conjunto de entidades de tipo Eps en la base de datos.
    */
    public virtual DbSet<Ep> Eps { get; set; }

    /**
    * Conjunto de entidades de tipo EpsEstablecimientoSalud en la base de datos.
    */
    public virtual DbSet<EpsEstablecimientoSalud> EpsEstablecimientoSaluds { get; set; }

    /**
    * Conjunto de entidades de tipo EstablecimientoSalud en la base de datos.
    */
    public virtual DbSet<EstablecimientoSalud> EstablecimientoSaluds { get; set; }

    /**
    * Conjunto de entidades de tipo Usuario en la base de datos.
    */
    public virtual DbSet<Usuario> Usuarios { get; set; }

    /**
    * Conjunto de entidades de tipo Valoracion en la base de datos.
    */
    public virtual DbSet<Valoracion> Valoracions { get; set; }

    /**
    * Configuración de la conexión a la base de datos y el modelo de datos.
    * @param optionsBuilder Constructor de opciones de configuración del contexto.
    */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:estacna.database.windows.net,1433;Initial Catalog=EsTacna;Persist Security Info=False;User ID=jpazos06;Password=upt2024!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    /**
    * Configuración de las relaciones y restricciones entre las entidades del modelo de datos.
    * @param modelBuilder Constructor de modelo de entidades.
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Busquedum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Busqueda__3213E83F32A81CAF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.TerminoBusqueda)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("termino_busqueda");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Busqueda)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Busqueda__usuari__412EB0B6");
        });

        modelBuilder.Entity<Ep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Eps__3213E83F80453229");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<EpsEstablecimientoSalud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Eps_Esta__3213E83FE93A04E0");

            entity.ToTable("Eps_EstablecimientoSalud");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EpsId).HasColumnName("eps_id");
            entity.Property(e => e.EstablecimientoId).HasColumnName("establecimiento_id");

            entity.HasOne(d => d.Eps).WithMany(p => p.EpsEstablecimientoSaluds)
                .HasForeignKey(d => d.EpsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Eps_Estab__eps_i__4222D4EF");

            entity.HasOne(d => d.Establecimiento).WithMany(p => p.EpsEstablecimientoSaluds)
                .HasForeignKey(d => d.EstablecimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Eps_Estab__estab__4316F928");
        });

        modelBuilder.Entity<EstablecimientoSalud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Establec__3213E83F9FAB1D0B");

            entity.ToTable("EstablecimientoSalud");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Latitud)
                .HasColumnType("decimal(12, 8)")
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasColumnType("decimal(12, 8)")
                .HasColumnName("longitud");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F94FA0A1D");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Valoracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Valoraci__3213E83FC11D4BA9");

            entity.ToTable("Valoracion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calificacion).HasColumnName("calificacion");
            entity.Property(e => e.Comentario)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comentario");
            entity.Property(e => e.EstablecimientoId).HasColumnName("establecimiento_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Establecimiento).WithMany(p => p.Valoracions)
                .HasForeignKey(d => d.EstablecimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Valoracio__estab__44FF419A");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Valoracions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Valoracio__usuar__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    /**
    * Método parcial para configuración adicional del modelo de entidades.
    * @param modelBuilder Constructor de modelo de entidades.
    */
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
