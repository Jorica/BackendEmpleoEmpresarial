using BackendEmpleoEmpressarial.DTOs.Employment;
using BackendEmpleoEmpressarial.DTOs.Generic;
using BackendEmpleoEmpressarial.Models;
using BackendEmpleoEmpressarial.Utils.Codes;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BackendEmpleoEmpressarial.Domain.Employment
{
    public class EmploymentDomainService : IEmploymentDomainService
    {
        private readonly EmpleoEmpresarialContext context;

        public EmploymentDomainService(EmpleoEmpresarialContext context)
        {
            this.context = context;
        }

        public IEnumerable<GenericDTO> ListaModalidadTrabajo()
        {
            return context.ModalidadTrabajos.AsNoTracking().Select(s => new GenericDTO
            {
                ID = s.Id,
                descripcion = s.Descripcion
            }).AsEnumerable();
        }

        public bool CrearEmpleo(Empleo empleo)
        {
            context.Add(empleo);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool AsociarEmpleo(EmpleoUsuario empleoUsuario)
        {
            context.Add(empleoUsuario);
            return context.SaveChanges() > 0 ? true : false;
        }

        public IEnumerable<OutListaEmpleosByUsuerDTO> ListaEmpleosByUsuario(Guid idUsuario)
        {
            return context.EmpleoUsuarios.AsNoTracking().Where(w => w.IdUsuario.Equals(idUsuario) && w.IdEmpleoNavigation.Activo)
                .OrderByDescending(o => o.IdEmpleoNavigation.FechaHoraRegistro)
                .Select(s => new OutListaEmpleosByUsuerDTO()
                {
                    IdEmpleoUsuario = s.Id,
                    IdEstadoEmpleoUsuario = s.IdEstadoEmpleoUsuario,
                    DescripcionEstadoEmpleoUsuario = s.IdEstadoEmpleoUsuarioNavigation.Descripcion,
                    ObservacionEmpleoUsuario = s.Observacion,
                    CodigoUsuario = s.IdUsuarioNavigation.TipoUsuario.Codigo,
                    CodigoEstadoEmpleoUsuario = s.IdEstadoEmpleoUsuarioNavigation.Codigo,
                    DetalleEmpleo = new DetalleEmpleoDTO()
                    {
                        IdEmpleo = s.IdEmpleo,
                        NombrePublico = s.IdUsuarioNavigation.NombreUsuario + " " + s.IdUsuarioNavigation.Apellido,
                        TituloEmpleo = s.IdEmpleoNavigation.Titulo,
                        DescripcionEmpleo = s.IdEmpleoNavigation.Descripcion,
                        SalarioEmpleo = s.IdEmpleoNavigation.Salario,
                        IdModalidadTrabajo = s.IdEmpleoNavigation.IdModalidadTrabajo,
                        DescripcionModalidadTrabajo = s.IdEmpleoNavigation.IdModalidadTrabajoNavigation.Descripcion,
                        FechaRegistro = s.IdEmpleoNavigation.FechaHoraRegistro.ToString("dd/MMMM/yyyy", new CultureInfo("es-ES"))
                    }
                }).AsEnumerable();
        }

        public bool ActualizarEmpleo(Empleo updateEmpleo)
        {
            context.Empleos.Update(updateEmpleo);
            return context.SaveChanges() > 0 ? true : false;
        }

        public Empleo? getEmpleoById(Guid id)
        {
            return context.Empleos.Find(id);
        }

        public EmpleoUsuario? getEmpleoUsuarioById(Guid id)
        {
            return context.EmpleoUsuarios.Find(id);
        }

        public bool ActualizarEstadoEmpleoUsuario(EmpleoUsuario updateEmpleo)
        {
            context.EmpleoUsuarios.Update(updateEmpleo);
            return context.SaveChanges() > 0 ? true : false;
        }

        public IEnumerable<OutListaEmpleosByUsuerDTO> ListaEmpleosDisponibles(Guid idUsuario)
        {
            IEnumerable<Guid> idsEmpleosPosutlados = context.EmpleoUsuarios.AsNoTracking().Where(w => w.IdUsuario.Equals(idUsuario)).Select(s => s.IdEmpleo);

            return context.EmpleoUsuarios.AsNoTracking()
                .Where(w => 
                    w.IdUsuarioNavigation.TipoUsuario.Codigo.Equals(TipoUsuarioUtil.Empresa) && 
                    w.IdEstadoEmpleoUsuarioNavigation.Codigo.Equals(EstadoEmpleoUsuarioUtil.Publicado) &&
                    !idsEmpleosPosutlados.Contains(w.IdEmpleo))
                .OrderByDescending(o => o.IdEmpleoNavigation.FechaHoraRegistro)
                .Select(s => new OutListaEmpleosByUsuerDTO()
                {
                    IdEmpleoUsuario = s.Id,
                    IdEstadoEmpleoUsuario = s.IdEstadoEmpleoUsuario,
                    DescripcionEstadoEmpleoUsuario = s.IdEstadoEmpleoUsuarioNavigation.Descripcion,
                    ObservacionEmpleoUsuario = s.Observacion,
                    CodigoUsuario = string.Empty,
                    CodigoEstadoEmpleoUsuario = s.IdEstadoEmpleoUsuarioNavigation.Codigo,
                    DetalleEmpleo = new DetalleEmpleoDTO()
                    {
                        IdEmpleo = s.IdEmpleo,
                        NombrePublico = s.IdUsuarioNavigation.Nombre + " " + s.IdUsuarioNavigation.Apellido,
                        TituloEmpleo = s.IdEmpleoNavigation.Titulo,
                        DescripcionEmpleo = s.IdEmpleoNavigation.Descripcion,
                        SalarioEmpleo = s.IdEmpleoNavigation.Salario,
                        IdModalidadTrabajo = s.IdEmpleoNavigation.IdModalidadTrabajo,
                        DescripcionModalidadTrabajo = s.IdEmpleoNavigation.IdModalidadTrabajoNavigation.Descripcion,
                        FechaRegistro = s.IdEmpleoNavigation.FechaHoraRegistro.ToString("dd/MMMM/yyyy", new CultureInfo("es-ES"))

                    }
                }).AsEnumerable();
        }
    }
}
