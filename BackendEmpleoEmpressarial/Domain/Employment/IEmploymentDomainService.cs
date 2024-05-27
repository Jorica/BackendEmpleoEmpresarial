using BackendEmpleoEmpressarial.DTOs.Employment;
using BackendEmpleoEmpressarial.DTOs.Generic;
using BackendEmpleoEmpressarial.Models;

namespace BackendEmpleoEmpressarial.Domain.Employment
{
    public interface IEmploymentDomainService
    {
        IEnumerable<GenericDTO> ListaModalidadTrabajo();
        bool CrearEmpleo(Empleo empleo);
        bool AsociarEmpleo(EmpleoUsuario empleoUsuario);
        IEnumerable<OutListaEmpleosByUsuerDTO> ListaEmpleosByUsuario(Guid idUsuario);
        bool ActualizarEmpleo(Empleo updateEmpleo);
        Empleo? getEmpleoById(Guid id);
        EmpleoUsuario? getEmpleoUsuarioById(Guid id);
        bool ActualizarEstadoEmpleoUsuario(EmpleoUsuario updateEmpleo);
        IEnumerable<OutListaEmpleosByUsuerDTO> ListaEmpleosDisponibles(Guid idUsuario);


    }
}
