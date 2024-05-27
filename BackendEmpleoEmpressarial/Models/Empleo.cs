using System;
using System.Collections.Generic;

namespace BackendEmpleoEmpressarial.Models;

public partial class Empleo
{
    public Guid Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Salario { get; set; }

    public Guid IdModalidadTrabajo { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaHoraRegistro { get; set; }

    public virtual ICollection<EmpleoUsuario> EmpleoUsuarios { get; set; } = new List<EmpleoUsuario>();

    public virtual ModalidadTrabajo IdModalidadTrabajoNavigation { get; set; } = null!;
}
