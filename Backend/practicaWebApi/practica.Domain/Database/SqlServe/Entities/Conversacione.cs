using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class Conversacione
{
    public int ConversacionId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<ConversacionUsuario> ConversacionUsuarios { get; set; } = new List<ConversacionUsuario>();

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
}
