using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface IPrestadorRepository
    {
        public Task<List<Prestador>> GetPrestadorPorEspecialidade(string especialidade);
        public Task<Prestador> GetPrestadorPorCpf(string cpf);
        public Task SalvarPrestador(Prestador prestador);

    }
}
