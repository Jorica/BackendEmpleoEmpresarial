namespace BackendEmpleoEmpressarial.DTOs.Employment
{
    public class DetalleEmpleoDTO
    {
        public Guid IdEmpleo { get; set; }
        public required string NombrePublico { get; set; }
        public required string TituloEmpleo { get; set; }
        public required string DescripcionEmpleo { get; set; }
        public decimal SalarioEmpleo { get; set; }
        public Guid IdModalidadTrabajo { get; set; }
        public required string DescripcionModalidadTrabajo { get; set; }
        public required string FechaRegistro { get; set; }
    }
}
