using System;
using System.Collections.Generic;

namespace BackendEmpleoEmpressarial.Models;

public partial class EstadoEmpleoUsuario
{
    public Guid Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string? CodigoGrupo { get; set; }

    public virtual ICollection<EmpleoUsuario> EmpleoUsuarios { get; set; } = new List<EmpleoUsuario>();
}
