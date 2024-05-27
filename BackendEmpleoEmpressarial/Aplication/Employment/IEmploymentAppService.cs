using Azure.Core;
using BackendCRUD.DTOs;
using BackendEmpleoEmpressarial.DTOs.Employment;
using BackendEmpleoEmpressarial.DTOs.Generic;

namespace BackendEmpleoEmpressarial.Aplication.Employment
{
    public interface IEmploymentAppService
    {
        RequestResult<IEnumerable<GenericDTO>> ListaModalidadTrabajo();
        RequestResult<bool> CrearEmpleo(InGestionEmpleoDialogoDTO inGestionEmpleoDialogoDTO);
        RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>> ListaEmpleosByUsuario(Guid idUsuario);
        RequestResult<bool> ActualizarEmpleo(InGestionEmpleoDialogoDTO inGestionEmpleoDialogoDTO);
        RequestResult<bool> ActualizarEstadoEmpleoUsuario(GenericDTO genericDTO);
        RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>> ListaEmpleosDisponibles(Guid idUsuario);
        RequestResult<bool> AplicarOferta(GenericDTO genericDTO);
    }
}
