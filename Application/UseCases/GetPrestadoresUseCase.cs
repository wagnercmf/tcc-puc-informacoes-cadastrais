using Application.Interfaces;
using Domain.Entities;
using Domain.Services.Interfaces;

namespace Application.UseCases
{
    public class GetPrestadoresPorEspecialidadeUseCase : IGetPrestadoresPorEspecialidadeUseCase
    {
        private readonly IPrestadorRepository _prestadorRepository;
        public GetPrestadoresPorEspecialidadeUseCase(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        public async Task<List<Prestador>> ExecuteAsync(string especialidade)
        {
            try
            {
                var prestador = await _prestadorRepository.GetPrestadorPorEspecialidade(especialidade);
                return prestador;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
