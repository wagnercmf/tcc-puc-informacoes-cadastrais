using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface IAssociadoRepository
    {
        public Task<Associado> GetAssociadoPorCpf(string cpf);
    }
}
