using BackendCRUD.DTOs;
using BackendEmpleoEmpressarial.DTOs.User;
using BackendEmpleoEmpressarial.Models;

namespace BackendEmpleoEmpressarial.Aplication.User
{
    public interface IUserAppService
    {
        RequestResult<bool> CrearUsuario(InCrearUsuarioDTO dto);
        RequestResult<OutLoginDTO> ValidarLogin(string usuario);
        RequestResult<IEnumerable<OutListTiposUsuarioDTO>> GetTiposUsuario();
    }
}
