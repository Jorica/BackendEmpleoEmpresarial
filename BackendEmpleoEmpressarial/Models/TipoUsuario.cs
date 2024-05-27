using System;
using System.Collections.Generic;

namespace BackendEmpleoEmpressarial.Models;

public partial class TipoUsuario
{
    public Guid TipoUsuarioId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
