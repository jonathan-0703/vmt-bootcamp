using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class Bloqueo
{
    public Guid BloqueadorId { get; set; }

    public Guid BloqueadoId { get; set; }

    public DateTime FechaBloqueo { get; set; }

    public virtual Usuario Bloqueado { get; set; } = null!;

    public virtual Usuario Bloqueador { get; set; } = null!;
}
