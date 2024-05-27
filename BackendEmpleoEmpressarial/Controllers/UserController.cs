using BackendCRUD.DTOs;
using BackendEmpleoEmpressarial.Aplication.User;
using BackendEmpleoEmpressarial.DTOs.User;
using BackendEmpleoEmpressarial.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendEmpleoEmpressarial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [HttpPost]
        [Route(nameof(UserController.CrearUsuario))]
        public RequestResult<Boolean> CrearUsuario(InCrearUsuarioDTO dto)
        {
            return userAppService.CrearUsuario(dto);
        }

        [HttpGet]
        [Route(nameof(UserController.ValidarLogin))]
        public RequestResult<OutLoginDTO> ValidarLogin(string usuario)
        {
            return userAppService.ValidarLogin(usuario);
        }

        [HttpGet]
        [Route(nameof(UserController.GetTiposUsuario))]
        public RequestResult<IEnumerable<OutListTiposUsuarioDTO>> GetTiposUsuario()
        {
            return userAppService.GetTiposUsuario();
        }
    }
}
