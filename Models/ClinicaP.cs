using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TRABAJO_FINAL.Models;

public partial class ClinicaP : DbContext
{
    public ClinicaP()
    {
    }

    public ClinicaP(DbContextOptions<ClinicaP> options)
        : base(options)
    {
    }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<Dium> Dia { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=sql8005.site4now.net;Initial Catalog=db_a9ac78_clinica;User ID=db_a9ac78_clinica_admin;Password=C12345678;Integrated Security=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Citum>(entity =>
        {
            entity.HasKey(e => e.IdCita);

            entity.Property(e => e.IdCita).HasColumnName("idCita");
            entity.Property(e => e.Costo).HasColumnName("costo");
            entity.Property(e => e.Dia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdDia).HasColumnName("idDia");
            entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");
            entity.Property(e => e.IdEspecialidad).HasColumnName("idEspecialidad");
            entity.Property(e => e.IdHorarios).HasColumnName("idHorarios");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.NomDoctor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nomDoctor");
            entity.Property(e => e.NomEspecialidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nomEspecialidad");
            entity.Property(e => e.NomUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nomUser");

            entity.HasOne(d => d.IdDiaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdDia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cita_Dia");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cita_Doctor");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdEspecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cita_Especialidad");

            entity.HasOne(d => d.IdHorariosNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdHorarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cita_Horarios");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cita_Usuario");
        });

        modelBuilder.Entity<Dium>(entity =>
        {
            entity.HasKey(e => e.IdDia).HasName("PK__Dia__3E416597EC42D4C3");

            entity.Property(e => e.IdDia).HasColumnName("idDia");
            entity.Property(e => e.Dia)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__Doctor__418956C34249DFBB");

            entity.ToTable("Doctor");

            entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");
            entity.Property(e => e.ApellidoD)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("apellidoD");
            entity.Property(e => e.ContraseñaD)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("contraseñaD");
            entity.Property(e => e.CorreoD)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("correoD");
            entity.Property(e => e.IdEspecialidad).HasColumnName("idEspecialidad");
            entity.Property(e => e.NombreD)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombreD");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.IdEspecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_Especialidad");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad);

            entity.ToTable("Especialidad");

            entity.Property(e => e.IdEspecialidad).HasColumnName("idEspecialidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorarios);

            entity.Property(e => e.IdHorarios).HasColumnName("idHorarios");
            entity.Property(e => e.FechaF).HasColumnName("fecha_f");
            entity.Property(e => e.FechaI).HasColumnName("fecha_i");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Apellidou)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidou");
            entity.Property(e => e.Contraseñau)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contraseñau");
            entity.Property(e => e.Correou)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correou");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nacimiento)
                .HasColumnType("date")
                .HasColumnName("nacimiento");
            entity.Property(e => e.Nombreu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreu");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
