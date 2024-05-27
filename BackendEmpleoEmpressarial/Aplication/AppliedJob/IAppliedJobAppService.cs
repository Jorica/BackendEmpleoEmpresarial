using BackendCRUD.DTOs;
using BackendEmpleoEmpressarial.DTOs.AppliedJob;

namespace BackendEmpleoEmpressarial.Aplication.AppliedJob
{
    public interface IAppliedJobAppService
    {
        RequestResult<IEnumerable<OutPostuladosByOfertaDTO>> GetPostuladosByOferta(Guid idEmpleo);
    }
}
