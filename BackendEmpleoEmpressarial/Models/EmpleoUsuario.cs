using System;
using System.Collections.Generic;

namespace BackendEmpleoEmpressarial.Models;

public partial class EmpleoUsuario
{
    public Guid Id { get; set; }

    public Guid IdEmpleo { get; set; }

    public Guid IdUsuario { get; set; }

    public Guid IdEstadoEmpleoUsuario { get; set; }

    public string? Observacion { get; set; }

    public virtual Empleo IdEmpleoNavigation { get; set; } = null!;

    public virtual EstadoEmpleoUsuario IdEstadoEmpleoUsuarioNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
