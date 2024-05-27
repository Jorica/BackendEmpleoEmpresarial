namespace BackendEmpleoEmpressarial.DTOs.AppliedJob
{
    public class OutPostuladosByOfertaDTO
    {
        public Guid IdEmpleoUsuario { get; set; }
        public required string NombrePostulado { get; set; }
        public required string ApellidoPostulado { get; set; }
        public required string CorreoPostulado { get; set; }
        public required string TelefonoPostulado { get; set; }
        public required string EstadoPostulacion { get; set; }
        public string? Observacion { get; set; }

    }
}
