using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRegistrarAtendimentoUseCase
    {
        public Task ExecuteAsync(string atendimentoInput);
    }
}
