using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class EstadoMensaje
{
    public int EstadoMensajeId { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
}
