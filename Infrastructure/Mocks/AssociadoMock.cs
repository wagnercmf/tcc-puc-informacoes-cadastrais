using Bogus;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Infrastructure.Mocks
{
    public class AssociadoMock
    {
        private const string CpfConhecido = "10987654321";
        private readonly Faker _faker = new Faker("pt_BR");
        private string[] especialidades = new string[4] 
            { "Estudante", "Engenheiro", "Advogado", "Professor" };
        private string[] instituicoes = new string[6]
            { "UFMG", "PUC", "UFLA", "Harvard", "UFV", "UFU" };
        private string[] doencas = new string[2]
            { "Pressão Alta", "Asma" };

        public List<Associado> GerarAssociadoMock()
        {
            var listaAssociados = new List<Associado>();

            var associado = new Associado(_faker.Name.FullName(),
                                        CpfConhecido,
                                        _faker.Address.FullAddress());

            associado.SetFormacao(instituicoes[_faker.Random.Int(0, 5)],
                                    especialidades[_faker.Random.Int(0,3)], 
                                    _faker.PickRandomWithout<TipoFormacao>(TipoFormacao.FundamentalIncompleto, TipoFormacao.FundamentalCompleto));

            associado.SetPlanoSaude(_faker.PickRandom<TipoPlano>(),
                StatusPlano.Ativo, _faker.PickRandom<FaixaEtaria>(),
                _faker.PickRandom<ClassificacaoPlano>(),
                _faker.Random.Bool());

            associado.SetInformacoesSaude(instituicoes[_faker.Random.Int(0, 5)], 
                _faker.PickRandom<Frequencia>(), 
                _faker.PickRandom<Frequencia>(), 
                doencas.ToList());

            listaAssociados.Add(associado);
            return listaAssociados;
        }
    }
}
