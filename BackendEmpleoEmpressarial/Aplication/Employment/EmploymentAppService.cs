using BackendCRUD.DTOs;
using BackendEmpleoEmpressarial.Domain.Employment;
using BackendEmpleoEmpressarial.Domain.StatusEmploymentUser;
using BackendEmpleoEmpressarial.DTOs.Employment;
using BackendEmpleoEmpressarial.DTOs.Generic;
using BackendEmpleoEmpressarial.Models;
using BackendEmpleoEmpressarial.Utils.Codes;

namespace BackendEmpleoEmpressarial.Aplication.Employment
{
    public class EmploymentAppService : IEmploymentAppService
    {
        private readonly EmpleoEmpresarialContext context;
        private readonly IEmploymentDomainService employmentDomainService;
        private readonly IStatusEmploymentUserDomainService statusEmploymentUserDomainService;

        public EmploymentAppService(
            EmpleoEmpresarialContext context,
            IEmploymentDomainService employmentDomainService,
            IStatusEmploymentUserDomainService statusEmploymentUserDomainService
            )
        {
            this.context = context;
            this.employmentDomainService = employmentDomainService;
            this.statusEmploymentUserDomainService = statusEmploymentUserDomainService;
        }

        public RequestResult<IEnumerable<GenericDTO>> ListaModalidadTrabajo()
        {
            try
            {
                IEnumerable<GenericDTO> outDto = employmentDomainService.ListaModalidadTrabajo();

                if (!outDto.Any())
                    return RequestResult<IEnumerable<GenericDTO>>.CreateUnsuccessful(new List<string> { "No se han encontrado registros para la modalidad de trabajo." });

                return RequestResult<IEnumerable<GenericDTO>>.CreateSuccessful(outDto, new List<string>() { string.Empty });
            }
            catch (Exception ex)
            {
                return RequestResult<IEnumerable<GenericDTO>>.CreateError(ex.Message);
            }
        }

        public RequestResult<bool> CrearEmpleo(InGestionEmpleoDialogoDTO inDto)
        {
            using (var trasaction = context.Database.BeginTransaction())
            {
                try
                {

                    Guid? estadoPublicado = statusEmploymentUserDomainService.GetIdEstadoByCodigo(EstadoEmpleoUsuarioUtil.Publicado);

                    if (estadoPublicado == Guid.Empty)
                        return RequestResult<bool>.CreateUnsuccessful(new List<string> { "Error al guardar el empleo: no se pudo encontrar el estado 'Publicado'." });


                    Empleo empleo = new Empleo()
                    {
                        Id = Guid.NewGuid(),
                        Titulo = inDto.Titulo,
                        Descripcion = inDto.Descripcion,
                        Salario = inDto.Salario,
                        IdModalidadTrabajo = inDto.IdModalidad,
                        Activo = true,
                    };

                    bool empleoCreado = employmentDomainService.CrearEmpleo(empleo);

                    if (!empleoCreado)
                        throw new Exception("Error al intentar crear la oferta.");


                    EmpleoUsuario empleoUsuario = new EmpleoUsuario()
                    {
                        Id = Guid.NewGuid(),
                        IdEmpleo = empleo.Id,
                        IdUsuario = inDto.IdUsuario,
                        IdEstadoEmpleoUsuario = estadoPublicado.HasValue ? estadoPublicado.Value : Guid.Empty,
                        Observacion = null
                    };

                    bool asociarEmpleo = employmentDomainService.AsociarEmpleo(empleoUsuario);

                    if (!asociarEmpleo)
                        throw new Exception("Error al intentar asociar la oferta con el usuario");

                    trasaction.Commit();
                    return RequestResult<bool>.CreateSuccessful(true, new List<string>() { "Empleo Creado Exitosamente." });
                }
                catch (Exception ex)
                {
                    trasaction.Rollback();
                    return RequestResult<bool>.CreateError(ex.Message);
                }
            }

        }

        public RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>> ListaEmpleosByUsuario(Guid idUsuario)
        {
            try
            {
                IEnumerable<OutListaEmpleosByUsuerDTO> outDto = employmentDomainService.ListaEmpleosByUsuario(idUsuario);

                if (!outDto.Any())
                    return RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>>.CreateUnsuccessful(new List<string>() { "No se encontraron empleos asociados al usuario" });

                return RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>>.CreateSuccessful(outDto, new List<string>() { string.Empty });
            }
            catch (Exception ex)
            {
                return RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>>.CreateError(ex.Message);
            }
        }

        public RequestResult<bool> ActualizarEmpleo(InGestionEmpleoDialogoDTO inDto)
        {
            try
            {
                Empleo? empleo = employmentDomainService.getEmpleoById(inDto.Id ?? Guid.Empty);

                if (empleo == null)
                    throw new Exception("Se produjo un error al intentar consultar la oferta.");

                empleo!.Id = empleo.Id;
                empleo!.Titulo = inDto.Titulo;
                empleo!.Descripcion = inDto.Descripcion;
                empleo!.Salario = inDto.Salario;
                empleo!.IdModalidadTrabajo = inDto.IdModalidad;

                bool empleoActualizado = employmentDomainService.ActualizarEmpleo(empleo);

                if (!empleoActualizado)
                    throw new Exception("Se produjo un error al intentar actualizar la oferta.");

                return RequestResult<bool>.CreateSuccessful(true, new List<string>() { "oferta actualizada exitosamente." });
            }
            catch (Exception ex)
            {
                return RequestResult<bool>.CreateError(ex.Message);
            }
        }

        public RequestResult<bool> ActualizarEstadoEmpleoUsuario(GenericDTO inDTO)
        {
            using (var trasaction = context.Database.BeginTransaction())
            {
                try
                {

                    EmpleoUsuario? empleoUsuario = employmentDomainService.getEmpleoUsuarioById(inDTO.ID);

                    if (empleoUsuario == null)
                        throw new Exception("Se produjo un error al intentar consultar el empleoUsuario.");

                    Guid? idEstado = statusEmploymentUserDomainService.GetIdEstadoByCodigo(inDTO.Codigo ?? string.Empty);

                    if (idEstado == Guid.Empty)
                        throw new Exception("Error al actualizar la oferta: no se pudo encontrar el estado relacionado.");

                    empleoUsuario.IdEstadoEmpleoUsuario = idEstado ?? Guid.Empty;
                    empleoUsuario.Observacion = inDTO.descripcion;

                    bool actulizoEstado = employmentDomainService.ActualizarEstadoEmpleoUsuario(empleoUsuario);

                    if (!actulizoEstado)
                        throw new Exception("Error durante la actualización del EstadoEmpleoUsuario");


                    if (EstadoEmpleoUsuarioUtil.Eliminado.Equals(inDTO.Codigo))
                    {
                        Guid idEmpleo = empleoUsuario.IdEmpleo;

                        Empleo? empleoActualizado = employmentDomainService.getEmpleoById(idEmpleo);

                        if (empleoActualizado == null)
                            throw new Exception("Error durante la consulta de la oferta");

                        empleoActualizado!.Activo = false;

                        bool actualizoEmpleo = employmentDomainService.ActualizarEmpleo(empleoActualizado);

                        if (!actualizoEmpleo)
                            throw new Exception("Error durante la actualización de la oferta");

                    }

                    trasaction.Commit();

                    return RequestResult<bool>.CreateSuccessful(true, new List<string>() { "Empleo actualizado exitosamente." });

                }
                catch (Exception ex)
                {
                    trasaction.Rollback();
                    return RequestResult<bool>.CreateError(ex.Message);
                }
            }

        }

        public RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>> ListaEmpleosDisponibles(Guid idUsuario)
        {
            try
            {
                IEnumerable<OutListaEmpleosByUsuerDTO> dto = employmentDomainService.ListaEmpleosDisponibles(idUsuario);

                if (!dto.Any())
                    return RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>>.CreateUnsuccessful(new List<string>() { "No se encontraron Empleos Disponibles" });

                return RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>>.CreateSuccessful(dto, new List<string>() { "" });
            }
            catch (Exception ex)
            {
                return RequestResult<IEnumerable<OutListaEmpleosByUsuerDTO>>.CreateError(ex.Message);
            }

        }

        public RequestResult<bool> AplicarOferta(GenericDTO genericDTO)
        {
            try
            {
                Guid? estadoAplicado = statusEmploymentUserDomainService.GetIdEstadoByCodigo(EstadoEmpleoUsuarioUtil.Aplicado);

                if (estadoAplicado == Guid.Empty)
                    throw new Exception("Error al aplicar a la oferta: no se pudo encontrar el estado relacionado.");


                EmpleoUsuario empleoUsuario = new EmpleoUsuario()
                {
                    Id = Guid.NewGuid(),
                    IdEmpleo = genericDTO.ID,
                    IdUsuario = genericDTO.IdUsuario ?? Guid.Empty,
                    IdEstadoEmpleoUsuario = estadoAplicado.HasValue ? estadoAplicado.Value : Guid.Empty,
                    Observacion = null
                };

                bool asociarEmpleo = employmentDomainService.AsociarEmpleo(empleoUsuario);

                if (!asociarEmpleo)
                    throw new Exception("Error al asociar la oferta con el usuario");

                return RequestResult<bool>.CreateSuccessful(true, new List<string> { "Postulación Exitosa." });

            }
            catch (Exception ex)
            {
                return RequestResult<bool>.CreateError(ex.Message);
            }
        }
    }
}
