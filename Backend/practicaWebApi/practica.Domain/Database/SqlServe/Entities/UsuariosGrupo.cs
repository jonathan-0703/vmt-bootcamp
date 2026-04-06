using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class UsuariosGrupo
{
    public int UsuarioGrupos { get; set; }

    public Guid UsuarioId { get; set; }

    public int GrupoId { get; set; }

    public virtual Grupo Grupo { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
