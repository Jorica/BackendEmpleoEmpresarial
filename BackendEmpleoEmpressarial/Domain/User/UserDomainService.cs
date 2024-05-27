using BackendEmpleoEmpressarial.DTOs.User;
using BackendEmpleoEmpressarial.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendEmpleoEmpressarial.Domain.User
{
    public class UserDomainService : IUserDomainService
    {
        private readonly EmpleoEmpresarialContext context;

        public UserDomainService(EmpleoEmpresarialContext context)
        {
            this.context = context;
        }

        public bool UsuarioExiste(string nombreUsuario)
        {
            return context.Usuarios.AsNoTracking().Where(x => x.NombreUsuario.Equals(nombreUsuario)).Any();
        }

        public bool CrearNuevoUsuario(Usuario usuario)
        {
            context.Add(usuario);
            return context.SaveChanges() > 0 ? true : false;
        }

        public OutLoginDTO? ValidarLogin(string usuario)
        {
            return context.Usuarios.AsNoTracking().Where(x =>
                x.NombreUsuario.Equals(usuario)
             ).Select(s => new OutLoginDTO
             {
                 IdUsuario = s.UsuarioId,
                 NombreCompleto = s.Nombre + " " + s.Apellido,
                 Correo = s.Correo,
                 Telefono = s.Telefono,
                 CodigoTipoUsuario = s.TipoUsuario.Codigo.ToString(),
                 CodigoInterno = s.Password,
             }).FirstOrDefault() ?? null;
        }

        public IEnumerable<OutListTiposUsuarioDTO> GetTiposUsuario()
        {
            return context.TipoUsuarios.AsNoTracking().Select(s => new OutListTiposUsuarioDTO
            {
                IdTipoUsuario = s.TipoUsuarioId,
                Nombre = s.Nombre
            }).AsEnumerable();
        }
    }
}
