using System;
using System.Collections.Generic;

namespace practica.Domain.Database.SqlServe.Entities;

public partial class Grupo
{
    public int GrupoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? FotoGrupal { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<AdministradorGrupo> AdministradorGrupos { get; set; } = new List<AdministradorGrupo>();

    public virtual ICollection<UsuariosGrupo> UsuariosGrupos { get; set; } = new List<UsuariosGrupo>();
}
