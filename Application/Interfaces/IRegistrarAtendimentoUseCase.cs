using Application.Models;
namespace Application.Interfaces
{
    public interface IRegistrarAtendimentoUseCase
    {
        public Task<bool> ExecuteAsync(AtendimentoInput atendimentoInput);
    }
}
