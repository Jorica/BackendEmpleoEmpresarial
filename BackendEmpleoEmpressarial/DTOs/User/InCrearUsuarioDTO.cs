namespace BackendEmpleoEmpressarial.DTOs.User
{
    public class InCrearUsuarioDTO
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Correo { get; set; }
        public required string Telefono { get; set; }
        public required string NombreUsuario { get; set; }
        public required string Password { get; set; }
        public Guid IdTipoUsuario { get; set; }
    }
}
