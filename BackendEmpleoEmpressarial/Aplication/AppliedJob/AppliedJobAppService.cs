using BackendCRUD.DTOs;
using BackendEmpleoEmpressarial.Domain.AppliedJob;
using BackendEmpleoEmpressarial.DTOs.AppliedJob;

namespace BackendEmpleoEmpressarial.Aplication.AppliedJob
{
    public class AppliedJobAppService : IAppliedJobAppService
    {
        private readonly IAppliedJobDomainService appliedJobDomainService;

        public AppliedJobAppService(IAppliedJobDomainService appliedJobDomainService)
        {
            this.appliedJobDomainService = appliedJobDomainService;
        }

        public RequestResult<IEnumerable<OutPostuladosByOfertaDTO>> GetPostuladosByOferta(Guid idEmpleo)
        {
            try
            {
                IEnumerable<OutPostuladosByOfertaDTO> dto = appliedJobDomainService.GetPostuladosByOferta(idEmpleo);

                if (!dto.Any())
                    return RequestResult<IEnumerable<OutPostuladosByOfertaDTO>>.CreateUnsuccessful(new List<string>() { "Aún no hay candidatos para la oferta." });

                return RequestResult<IEnumerable<OutPostuladosByOfertaDTO>>.CreateSuccessful(dto,new List<string>() {string.Empty});
            }
            catch (Exception ex)
            {
                return RequestResult<IEnumerable<OutPostuladosByOfertaDTO>>.CreateError(ex.Message);
            }
        }
    }
}
