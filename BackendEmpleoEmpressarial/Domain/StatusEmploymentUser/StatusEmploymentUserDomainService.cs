
using BackendEmpleoEmpressarial.Models;

namespace BackendEmpleoEmpressarial.Domain.StatusEmploymentUser
{
    public class StatusEmploymentUserDomainService : IStatusEmploymentUserDomainService
    {
        private readonly EmpleoEmpresarialContext context;

        public StatusEmploymentUserDomainService(EmpleoEmpresarialContext context)
        {
            this.context = context;
        }

        public Guid? GetIdEstadoByCodigo(string codigo)
        {
            return context.EstadoEmpleoUsuarios.Where(w => w.Codigo.Equals(codigo)).FirstOrDefault().Id;
        }
    }
}
