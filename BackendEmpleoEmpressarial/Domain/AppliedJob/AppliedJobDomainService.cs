using BackendEmpleoEmpressarial.DTOs.AppliedJob;
using BackendEmpleoEmpressarial.Models;
using BackendEmpleoEmpressarial.Utils.Codes;
using Microsoft.EntityFrameworkCore;

namespace BackendEmpleoEmpressarial.Domain.AppliedJob
{
    public class AppliedJobDomainService : IAppliedJobDomainService
    {
        private readonly EmpleoEmpresarialContext context;

        public AppliedJobDomainService(EmpleoEmpresarialContext context)
        {
            this.context = context;
        }

        public IEnumerable<OutPostuladosByOfertaDTO> GetPostuladosByOferta(Guid idEmpleo)
        {
            return context.EmpleoUsuarios.AsNoTracking()
                .Where(w => w.IdUsuarioNavigation.TipoUsuario.Codigo.Equals(TipoUsuarioUtil.PersonaNatural) &&
                            w.IdEmpleo.Equals(idEmpleo))
                .Select(s => new OutPostuladosByOfertaDTO
                {
                    IdEmpleoUsuario = s.Id,
                    NombrePostulado = s.IdUsuarioNavigation.Nombre,
                    ApellidoPostulado = s.IdUsuarioNavigation.Apellido,
                    CorreoPostulado = s.IdUsuarioNavigation.Correo,
                    TelefonoPostulado = s.IdUsuarioNavigation.Telefono,
                    EstadoPostulacion = s.IdEstadoEmpleoUsuarioNavigation.Descripcion,
                    Observacion = s.Observacion
                }).AsEnumerable();
        }
    }
}
