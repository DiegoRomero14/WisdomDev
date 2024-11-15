using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WisdomDev.Models;

public partial class WisdomDevDbContext : DbContext
{
    public WisdomDevDbContext()
    {
    }

    public WisdomDevDbContext(DbContextOptions<WisdomDevDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciclo> Ciclos { get; set; }

    public virtual DbSet<CuentaAdministrador> CuentaAdministradors { get; set; }

    public virtual DbSet<CuentaCurso> CuentaCursos { get; set; }

    public virtual DbSet<CuentaEstudiante> CuentaEstudiantes { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<UsuarioAdministrador> UsuarioAdministradors { get; set; }

    public virtual DbSet<UsuarioEstudiante> UsuarioEstudiantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DiegoRomero\\SQLEXPRESS;Database=WisdomDevDB;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciclo>(entity =>
        {
            entity.HasKey(e => e.IdCiclo).HasName("PK__Ciclo__754248200DD555D7");

            entity.ToTable("Ciclo");

            entity.Property(e => e.IdCiclo).HasColumnName("idCiclo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreCiclo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombreCiclo");
        });

        modelBuilder.Entity<CuentaAdministrador>(entity =>
        {
            entity.HasKey(e => e.IdCuentaAdministrador).HasName("PK__CuentaAd__AA3901BFC2C51547");

            entity.ToTable("CuentaAdministrador");

            entity.Property(e => e.IdCuentaAdministrador).HasColumnName("idCuentaAdministrador");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.IdUsuarioAdministrador).HasColumnName("idUsuarioAdministrador");

            entity.HasOne(d => d.IdUsuarioAdministradorNavigation).WithMany(p => p.CuentaAdministradors)
                .HasForeignKey(d => d.IdUsuarioAdministrador)
                .HasConstraintName("FK__CuentaAdm__contr__5441852A");
        });

        modelBuilder.Entity<CuentaCurso>(entity =>
        {
            entity.HasKey(e => e.IdCuentaCurso).HasName("PK__CuentaCu__C519799EEA255978");

            entity.ToTable("CuentaCurso");

            entity.Property(e => e.IdCuentaCurso).HasColumnName("idCuentaCurso");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdCuentaEstudiante).HasColumnName("idCuentaEstudiante");
            entity.Property(e => e.IdCurso).HasColumnName("idCurso");
            entity.Property(e => e.Progreso)
                .HasDefaultValue(0)
                .HasColumnName("progreso");

            entity.HasOne(d => d.IdCuentaEstudianteNavigation).WithMany(p => p.CuentaCursos)
                .HasForeignKey(d => d.IdCuentaEstudiante)
                .HasConstraintName("FK__CuentaCur__idCue__5CD6CB2B");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.CuentaCursos)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK__CuentaCur__idCur__5DCAEF64");
        });

        modelBuilder.Entity<CuentaEstudiante>(entity =>
        {
            entity.HasKey(e => e.IdCuentaEstudiante).HasName("PK__CuentaEs__0BD09D73DE35CBBE");

            entity.ToTable("CuentaEstudiante");

            entity.Property(e => e.IdCuentaEstudiante).HasColumnName("idCuentaEstudiante");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.IdUsuarioEstudiante).HasColumnName("idUsuarioEstudiante");

            entity.HasOne(d => d.IdUsuarioEstudianteNavigation).WithMany(p => p.CuentaEstudiantes)
                .HasForeignKey(d => d.IdUsuarioEstudiante)
                .HasConstraintName("FK__CuentaEst__idUsu__5165187F");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__Curso__8551ED057A86D154");

            entity.ToTable("Curso");

            entity.Property(e => e.IdCurso).HasColumnName("idCurso");
            entity.Property(e => e.Alumnos).HasColumnName("alumnos");
            entity.Property(e => e.Autor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.CargaHoraria)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cargaHoraria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCiclo).HasColumnName("idCiclo");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCurso");
            entity.Property(e => e.UltimaActualizacion).HasColumnName("ultimaActualizacion");

            entity.HasOne(d => d.IdCicloNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdCiclo)
                .HasConstraintName("FK__Curso__idCiclo__59063A47");
        });

        modelBuilder.Entity<UsuarioAdministrador>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioAdministrador).HasName("PK__UsuarioA__02FB5687A901F6DC");

            entity.ToTable("UsuarioAdministrador");

            entity.Property(e => e.IdUsuarioAdministrador).HasColumnName("idUsuarioAdministrador");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("Medellín")
                .HasColumnName("ciudad");
            entity.Property(e => e.DocumentoIdentificacion)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("documentoIdentificacion");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Pais)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("Colombia")
                .HasColumnName("pais");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<UsuarioEstudiante>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioEstudiante).HasName("PK__UsuarioE__FE3D6E82BE6D1AA5");

            entity.ToTable("UsuarioEstudiante");

            entity.Property(e => e.IdUsuarioEstudiante).HasColumnName("idUsuarioEstudiante");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("Medellín")
                .HasColumnName("ciudad");
            entity.Property(e => e.DocumentoIdentificacion)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("documentoIdentificacion");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Pais)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("Colombia")
                .HasColumnName("pais");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
