namespace BackendEmpleoEmpressarial.DTOs.Generic
{
    public class GenericDTO
    {
        public Guid ID{ get; set; }
        public string? descripcion { get; set; }
        public string? Codigo { get; set; }
        public string? CodigoGrupo { get; set; }
        public Guid? IdUsuario { get; set; }
    }
}
