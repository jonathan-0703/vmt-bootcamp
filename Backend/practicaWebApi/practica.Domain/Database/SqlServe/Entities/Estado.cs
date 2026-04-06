using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class Estado
{
    public int EstadosId { get; set; }

    public Guid UsuarioId { get; set; }

    public string Url { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
