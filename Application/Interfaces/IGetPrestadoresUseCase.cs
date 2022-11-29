
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGetPrestadoresPorEspecialidadeUseCase
    {
        public Task<List<Prestador>> ExecuteAsync(string especialidade);
    }
}
