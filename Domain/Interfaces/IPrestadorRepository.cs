using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface IPrestadorRepository
    {
        Task<List<Prestador>> GetPrestadorPorEspecialidade(string especialidade);
    }
}
