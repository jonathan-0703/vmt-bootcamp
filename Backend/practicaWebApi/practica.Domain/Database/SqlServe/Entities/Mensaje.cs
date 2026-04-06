using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class Mensaje
{
    public int MensajeId { get; set; }

    public int ConversacionId { get; set; }

    public int EstadoMensajeId { get; set; }

    public Guid UsuarioId { get; set; }

    public string? Contenido { get; set; }

    public string? TipoDocumento { get; set; }

    public DateTime FechaEnvio { get; set; }

    public bool? MensajeEliminado { get; set; }

    public string? RespuestaMensaje { get; set; }

    public virtual Conversacione Conversacion { get; set; } = null!;

    public virtual EstadoMensaje EstadoMensaje { get; set; } = null!;

    public virtual ICollection<MensajeLeido> MensajeLeidos { get; set; } = new List<MensajeLeido>();

    public virtual ICollection<Reaccione> Reacciones { get; set; } = new List<Reaccione>();

    public virtual Usuario Usuario { get; set; } = null!;
}
