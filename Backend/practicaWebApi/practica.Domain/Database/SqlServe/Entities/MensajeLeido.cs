using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class MensajeLeido
{
    public int MensajeLeidoId { get; set; }

    public int MensajeId { get; set; }

    public Guid UsuarioId { get; set; }

    public DateTime FechaLeido { get; set; }

    public virtual Mensaje Mensaje { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
