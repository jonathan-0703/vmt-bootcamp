using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using practica.Domain.Database.SqlServe.Entities;

namespace practica.Domain.Database.SqlServe.Context;

public partial class WhatsappProyectoFinalContext : DbContext
{
    public WhatsappProyectoFinalContext()
    {
    }

    public WhatsappProyectoFinalContext(DbContextOptions<WhatsappProyectoFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdministradorGrupo> AdministradorGrupos { get; set; }

    public virtual DbSet<Bloqueo> Bloqueos { get; set; }

    public virtual DbSet<ConversacionUsuario> ConversacionUsuarios { get; set; }

    public virtual DbSet<Conversacione> Conversaciones { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<EstadoMensaje> EstadoMensajes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<MensajeLeido> MensajeLeidos { get; set; }

    public virtual DbSet<Reaccione> Reacciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuariosGrupo> UsuariosGrupos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;User=sa;Password=MyStrongPass123;Database=WhatsappProyectoFinal;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdministradorGrupo>(entity =>
        {
            entity.HasKey(e => e.AdministadorId).HasName("PK__Administ__5476D4679EAC2867");

            entity.ToTable("AdministradorGrupo");

            entity.Property(e => e.AdministadorId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Permisos).HasMaxLength(200);

            entity.HasOne(d => d.Grupo).WithMany(p => p.AdministradorGrupos)
                .HasForeignKey(d => d.GrupoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminGrupos");

            entity.HasOne(d => d.Usuario).WithMany(p => p.AdministradorGrupos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioAdministrador");
        });

        modelBuilder.Entity<Bloqueo>(entity =>
        {
            entity.HasKey(e => new { e.BloqueadorId, e.BloqueadoId }).HasName("PK__Bloqueo__73F3493759662ED2");

            entity.ToTable("Bloqueo");

            entity.Property(e => e.BloqueadoId).HasColumnName("BLoqueadoId");
            entity.Property(e => e.FechaBloqueo).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Bloqueado).WithMany(p => p.BloqueoBloqueados)
                .HasForeignKey(d => d.BloqueadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BLoqueadoId");

            entity.HasOne(d => d.Bloqueador).WithMany(p => p.BloqueoBloqueadors)
                .HasForeignKey(d => d.BloqueadorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BloqueadorId");
        });

        modelBuilder.Entity<ConversacionUsuario>(entity =>
        {
            entity.HasKey(e => e.ConversacionUsuarioId).HasName("PK__Conversa__1A6FFF9D3DA1DE4E");

            entity.ToTable("ConversacionUsuario");

            entity.Property(e => e.MensajeSilenciado).HasDefaultValue(true);

            entity.HasOne(d => d.Conversacion).WithMany(p => p.ConversacionUsuarios)
                .HasForeignKey(d => d.ConversacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConversacionUsuario");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ConversacionUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioConversion");
        });

        modelBuilder.Entity<Conversacione>(entity =>
        {
            entity.HasKey(e => e.ConversacionId).HasName("PK__Conversa__438B7B59061B5305");

            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Nombre).HasMaxLength(250);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadosId).HasName("PK__Estados__0662EE280CF15B54");

            entity.Property(e => e.FechaPublicacion).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.FechaVencimiento).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Url).HasColumnName("URL");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Estados)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioEstado");
        });

        modelBuilder.Entity<EstadoMensaje>(entity =>
        {
            entity.HasKey(e => e.EstadoMensajeId).HasName("PK__EstadoMe__AC3959E7E4EBADCD");

            entity.ToTable("EstadoMensaje");

            entity.Property(e => e.NombreEstado).HasMaxLength(50);
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.GrupoId).HasName("PK__Grupos__556BF0400CBFB649");

            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Nombre).HasMaxLength(250);
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.MensajeId).HasName("PK__Mensaje__FEA0555F95BAFE19");

            entity.ToTable("Mensaje");

            entity.Property(e => e.FechaEnvio).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.MensajeEliminado).HasDefaultValue(false);

            entity.HasOne(d => d.Conversacion).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.ConversacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConversaionMensajeId");

            entity.HasOne(d => d.EstadoMensaje).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.EstadoMensajeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstadoMensajeId");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioMensajeId");
        });

        modelBuilder.Entity<MensajeLeido>(entity =>
        {
            entity.HasKey(e => e.MensajeLeidoId).HasName("PK__MensajeL__510ABCD7BFD4BD2B");

            entity.HasIndex(e => new { e.MensajeId, e.UsuarioId }, "UQ_Mensaje_Usuario").IsUnique();

            entity.Property(e => e.MensajeLeidoId).HasColumnName("MensajeLeidoID");
            entity.Property(e => e.FechaLeido).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Mensaje).WithMany(p => p.MensajeLeidos)
                .HasForeignKey(d => d.MensajeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MensajeLeido");

            entity.HasOne(d => d.Usuario).WithMany(p => p.MensajeLeidos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MensajeLeidoUsuario");
        });

        modelBuilder.Entity<Reaccione>(entity =>
        {
            entity.HasKey(e => e.ReaccionId).HasName("PK__Reaccion__EAF7E4EA15BB9508");

            entity.Property(e => e.Emoji).HasColumnType("text");
            entity.Property(e => e.FechaReaccion).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Mensaje).WithMany(p => p.Reacciones)
                .HasForeignKey(d => d.MensajeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MensajeReaccion");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reacciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioReaccion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B8D4B528DA");

            entity.Property(e => e.UsuarioId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.FotoPerfil).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(250);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<UsuariosGrupo>(entity =>
        {
            entity.HasKey(e => e.UsuarioGrupos).HasName("PK__Usuarios__2B6C0D6BC2ECDEC6");

            entity.HasOne(d => d.Grupo).WithMany(p => p.UsuariosGrupos)
                .HasForeignKey(d => d.GrupoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposUsuarios");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuariosGrupos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuariosGrupos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
