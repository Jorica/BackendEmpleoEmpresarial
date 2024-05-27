namespace BackendEmpleoEmpressarial.DTOs.Employment
{
    public class InGestionEmpleoDialogoDTO
    {
        public Guid? Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descripcion { get; set; }
        public decimal Salario { get; set; }
        public Guid IdModalidad { get; set; }
        public Guid IdUsuario { get; set; }

    }
}
