using BackendCRUD.DTOs;
using BackendEmpleoEmpressarial.Domain.User;
using BackendEmpleoEmpressarial.DTOs.User;
using BackendEmpleoEmpressarial.Models;

namespace BackendEmpleoEmpressarial.Aplication.User
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService userDomainService;

        public UserAppService(IUserDomainService userDomainService)
        {
            this.userDomainService = userDomainService;
        }

        public RequestResult<bool> CrearUsuario(InCrearUsuarioDTO dto)
        {
            try
            {
                if (userDomainService.UsuarioExiste(dto.NombreUsuario))
                    return RequestResult<bool>.CreateUnsuccessful(new List<string> { "El nombre de usuario ya está en uso." });

                Usuario usuario = new Usuario()
                {
                    UsuarioId = Guid.NewGuid(),
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Correo = dto.Correo,
                    Telefono = dto.Telefono,
                    NombreUsuario = dto.NombreUsuario,
                    Password = dto.Password,
                    TipoUsuarioId = dto.IdTipoUsuario
                };

                bool usuarioCreado = userDomainService.CrearNuevoUsuario(usuario);

                if (!usuarioCreado)
                    throw new Exception("Error al intentar crear el usuario.");

                return RequestResult<bool>.CreateSuccessful(true, new List<string> { "Usuario Creado Exitosamente." });
            }
            catch (Exception ex)
            {
                return RequestResult<bool>.CreateError(ex.Message);
            }
            
        }

        public RequestResult<IEnumerable<OutListTiposUsuarioDTO>> GetTiposUsuario()
        {
            try
            {
                IEnumerable<OutListTiposUsuarioDTO> listaTipoUsuarios = userDomainService.GetTiposUsuario();

                if (!listaTipoUsuarios.Any())
                    return RequestResult<IEnumerable<OutListTiposUsuarioDTO>>.CreateUnsuccessful(new List<string> { "No se encontraron registros de tipos de usuarios disponibles." });

                return RequestResult<IEnumerable<OutListTiposUsuarioDTO>>.CreateSuccessful(listaTipoUsuarios, new List<string> { "" });
            }
            catch (Exception ex)
            {
                return RequestResult<IEnumerable<OutListTiposUsuarioDTO>>.CreateError(ex.Message);
            }
        }

        public RequestResult<OutLoginDTO> ValidarLogin(string usuario)
        {
            try
            {

                OutLoginDTO? outLoginDTO = userDomainService.ValidarLogin(usuario);

                if (outLoginDTO == null)
                    throw new Exception("Error de autenticación: Las credenciales ingresadas no son válidas.");

                return RequestResult<OutLoginDTO>.CreateSuccessful(outLoginDTO, new List<string> { string.Empty });

            }
            catch (Exception ex)
            {
                return RequestResult<OutLoginDTO>.CreateError(ex.Message);
            }
        }
    }
}
