using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class Usuario
{
    public Guid UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string FotoPerfil { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<AdministradorGrupo> AdministradorGrupos { get; set; } = new List<AdministradorGrupo>();

    public virtual ICollection<Bloqueo> BloqueoBloqueadors { get; set; } = new List<Bloqueo>();

    public virtual ICollection<Bloqueo> BloqueoBloqueados { get; set; } = new List<Bloqueo>();

    public virtual ICollection<ConversacionUsuario> ConversacionUsuarios { get; set; } = new List<ConversacionUsuario>();

    public virtual ICollection<Estado> Estados { get; set; } = new List<Estado>();

    public virtual ICollection<MensajeLeido> MensajeLeidos { get; set; } = new List<MensajeLeido>();

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();

    public virtual ICollection<Reaccione> Reacciones { get; set; } = new List<Reaccione>();

    public virtual ICollection<UsuariosGrupo> UsuariosGrupos { get; set; } = new List<UsuariosGrupo>();
}
