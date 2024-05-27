using System;
using System.Collections.Generic;

namespace BackendEmpleoEmpressarial.Models;

public partial class Usuario
{
    public Guid UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid TipoUsuarioId { get; set; }

    public virtual ICollection<EmpleoUsuario> EmpleoUsuarios { get; set; } = new List<EmpleoUsuario>();

    public virtual TipoUsuario TipoUsuario { get; set; } = null!;
}
