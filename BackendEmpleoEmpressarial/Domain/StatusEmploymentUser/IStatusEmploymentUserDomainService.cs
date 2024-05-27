namespace BackendEmpleoEmpressarial.Domain.StatusEmploymentUser
{
    public interface IStatusEmploymentUserDomainService
    {
        Guid? GetIdEstadoByCodigo(string codigo);
    }
}
