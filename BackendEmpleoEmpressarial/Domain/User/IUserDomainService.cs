using BackendEmpleoEmpressarial.DTOs.User;
using BackendEmpleoEmpressarial.Models;

namespace BackendEmpleoEmpressarial.Domain.User
{
    public interface IUserDomainService
    {
        bool UsuarioExiste(string nombreUsuario);
        bool CrearNuevoUsuario(Usuario usuario);
        OutLoginDTO? ValidarLogin(string usuario);
        IEnumerable<OutListTiposUsuarioDTO> GetTiposUsuario();
    }
}
