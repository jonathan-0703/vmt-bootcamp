using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class AdministradorGrupo
{
    public Guid AdministadorId { get; set; }

    public Guid UsuarioId { get; set; }

    public int GrupoId { get; set; }

    public string Permisos { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual Grupo Grupo { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
