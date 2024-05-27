namespace BackendEmpleoEmpressarial.DTOs.User
{
    public class OutLoginDTO
    {
        public Guid IdUsuario{ get; set; }
        public required string NombreCompleto { get; set; }
        public required string Correo { get; set; }
        public required string Telefono { get; set; }
        public required string CodigoTipoUsuario { get; set; }
        public required string CodigoInterno{ get; set; }



    }
}
