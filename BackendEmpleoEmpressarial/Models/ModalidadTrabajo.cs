using System;
using System.Collections.Generic;

namespace BackendEmpleoEmpressarial.Models;

public partial class ModalidadTrabajo
{
    public Guid Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual ICollection<Empleo> Empleos { get; set; } = new List<Empleo>();
}
