using BackendEmpleoEmpressarial.DTOs.AppliedJob;

namespace BackendEmpleoEmpressarial.Domain.AppliedJob
{
    public interface IAppliedJobDomainService
    {
        IEnumerable<OutPostuladosByOfertaDTO> GetPostuladosByOferta(Guid idEmpleo);
    }
}
