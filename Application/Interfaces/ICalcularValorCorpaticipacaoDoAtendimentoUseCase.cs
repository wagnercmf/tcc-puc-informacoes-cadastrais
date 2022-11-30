using Application.Models;
namespace Application.Interfaces
{
    public interface ICalcularValorCorpaticipacaoDoAtendimentoUseCase
    {
        public Task<double> ExecuteAsync(AtendimentoInput atendimentoInput);
    }
}
