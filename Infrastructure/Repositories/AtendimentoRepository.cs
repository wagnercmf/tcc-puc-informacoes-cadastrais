
using Domain.Entities;
using Domain.Services.Interfaces;
using Infrastructure.Mocks;

namespace Infrastructure.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        public async Task RegistrarAtendimento(Atendimento atendimento)
        {
            //Salvar No Banco de Dados
        }
    }
}
