namespace BackendEmpleoEmpressarial.DTOs.Employment
{
    public class OutListaEmpleosByUsuerDTO
    {
        public Guid IdEmpleoUsuario{ get; set; }
        public Guid IdEstadoEmpleoUsuario { get; set; }
        public required string DescripcionEstadoEmpleoUsuario{ get; set; }
        public required string CodigoEstadoEmpleoUsuario{ get; set; }
        public string? ObservacionEmpleoUsuario { get; set; }
        public required string CodigoUsuario { get; set; }
        public required DetalleEmpleoDTO DetalleEmpleo { get; set; }
    }
}
