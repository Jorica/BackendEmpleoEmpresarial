using BackendCRUD.DTOs;
using BackendEmpleoEmpressarial.Aplication.AppliedJob;
using BackendEmpleoEmpressarial.Aplication.Employment;
using BackendEmpleoEmpressarial.DTOs.AppliedJob;
using BackendEmpleoEmpressarial.DTOs.Employment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendEmpleoEmpressarial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppliedJobController : ControllerBase
    {
        private readonly IAppliedJobAppService appliedJobAppService;

        public AppliedJobController(IAppliedJobAppService appliedJobAppService)
        {
            this.appliedJobAppService = appliedJobAppService;
        }

        [HttpGet]
        [Route(nameof(AppliedJobController.GetPostuladosByOferta))]
        public RequestResult<IEnumerable<OutPostuladosByOfertaDTO>> GetPostuladosByOferta(string idEmpleo)
        {
            Guid empleo = Guid.Parse(idEmpleo);
            return appliedJobAppService.GetPostuladosByOferta(empleo);
        }
    }
}
