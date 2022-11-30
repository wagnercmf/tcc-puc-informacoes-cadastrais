using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface IAtendimentoRepository
    {
        public Task RegistrarAtendimento(Atendimento atendimento);
    }
}
