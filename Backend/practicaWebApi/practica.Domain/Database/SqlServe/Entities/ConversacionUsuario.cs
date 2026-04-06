using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class ConversacionUsuario
{
    public int ConversacionUsuarioId { get; set; }

    public Guid UsuarioId { get; set; }

    public int ConversacionId { get; set; }

    public bool MensajeSilenciado { get; set; }

    public virtual Conversacione Conversacion { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
