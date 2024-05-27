using BackendCRUD.DTOs;
using BackendEmpleoEmpressarial.Aplication.Employment;
using BackendEmpleoEmpressarial.Aplication.User;
using BackendEmpleoEmpressarial.DTOs.Employment;
using BackendEmpleoEmpressarial.DTOs.Generic;
using BackendEmpleoEmpressarial.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendEmpleoEmpressarial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentController : ControllerBase
    {
        private readonly IEmploymentAppService employmentAppService;

        public EmploymentController(IEmploymentAppService employmentAppService)
        {
            this.employmentAppService = employmentAppService;
        }

        [HttpGet]
        [Route(nameof(EmploymentController.ListaModalidadTrabajo))]
        public RequestResult<IEnumerable<GenericDTO>> ListaModalidadTrabajo()
        {
            return employmentAppService.ListaModalidadTrabajo();
        }

        [HttpPost]
        [Route(nameof(EmploymentController.CrearEmpleo))]
        public RequestResult<bool> CrearEmpleo(InGestionEmpleoDialogoDTO dto)
        {
            return employmentAppService.CrearEmpleo(dto);
        }

        [HttpGet]
        [Route(nameof(EmploymentController.ListaEmpleosByUsuario))]
        public RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>> ListaEmpleosByUsuario(string idUsuario)
        {
            Guid usuario = Guid.Parse(idUsuario);
            return employmentAppService.ListaEmpleosByUsuario(usuario);
        }

        [HttpPost]
        [Route(nameof(EmploymentController.ActualizarEmpleo))]
        public RequestResult<bool> ActualizarEmpleo(InGestionEmpleoDialogoDTO dto)
        {
            return employmentAppService.ActualizarEmpleo(dto);
        }

        [HttpPost]
        [Route(nameof(EmploymentController.ActualizarEstadoEmpleoUsuario))]
        public RequestResult<bool> ActualizarEstadoEmpleoUsuario(GenericDTO dto)
        {
            return employmentAppService.ActualizarEstadoEmpleoUsuario(dto);
        }

        [HttpGet]
        [Route(nameof(EmploymentController.ListaEmpleosDisponibles))]
        public RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>> ListaEmpleosDisponibles(string idUsuario)
        {
            Guid usuario = Guid.Parse(idUsuario);
            return employmentAppService.ListaEmpleosDisponibles(usuario);
        }

        [HttpPost]
        [Route(nameof(EmploymentController.AplicarOferta))]
        public RequestResult<bool> AplicarOferta(GenericDTO dto)
        {
            return employmentAppService.AplicarOferta(dto);
        }
    }
}
