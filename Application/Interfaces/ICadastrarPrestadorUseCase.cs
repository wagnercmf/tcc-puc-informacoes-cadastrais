using Application.Models;
namespace Application.Interfaces
{
    public interface ICadastrarPrestadorUseCase
    {
        public Task<bool> ExecuteAsync(PrestadorInput prestadorInput);
    }
}
