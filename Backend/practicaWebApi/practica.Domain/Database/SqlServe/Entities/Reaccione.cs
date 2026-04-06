using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class Reaccione
{
    public int ReaccionId { get; set; }

    public Guid UsuarioId { get; set; }

    public int MensajeId { get; set; }

    public string Emoji { get; set; } = null!;

    public DateTime FechaReaccion { get; set; }

    public virtual Mensaje Mensaje { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
