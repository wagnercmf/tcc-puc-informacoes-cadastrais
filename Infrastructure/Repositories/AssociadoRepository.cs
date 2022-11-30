
using Domain.Entities;
using Domain.Services.Interfaces;
using Infrastructure.Mocks;

namespace Infrastructure.Repositories
{
    public class AssociadoRepository : IAssociadoRepository
    {
        private readonly AssociadoMock associadoMock = new AssociadoMock();

        public async Task<Associado> GetAssociadoPorCpf(string cpf)
        {
            var associados = associadoMock.GerarAssociadoMock();
            if(associados.Any())
                return associados.Where(x => x.Documento == cpf).FirstOrDefault();
            return null;
        }
    }
}
