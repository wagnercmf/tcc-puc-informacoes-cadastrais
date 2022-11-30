using Bogus;
using Bogus.Extensions.Brazil;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Mocks
{
    public class PrestadorMock
    {
        private const int NumeroPrestadores = 50;
        private const string CpfConhecido = "12345678910";
        private readonly Faker _faker = new Faker("pt_BR");
        private string[] especialidades = new string[6] 
            { "Clinico Geral", "Pediatra", "Mamografo", "Cardiologista", "Neurologista", "Ortopedista" };
        private string[] instituicoes = new string[6]
            { "UFMG", "PUC", "UFLA", "Harvard", "UFV", "UFU" };

        public List<Prestador> GerarPrestadoresMock()
        {
            var listaPrestadores = new List<Prestador>();

            var prestadorCpfConhecido = new Prestador(_faker.Name.FullName(),
                          CpfConhecido,
                          _faker.Address.FullAddress(),
                          especialidades[_faker.Random.Int(0, 5)]);

            prestadorCpfConhecido.SetFormacao(instituicoes[_faker.Random.Int(0, 5)],
                                  "Medicina",
                                  _faker.PickRandomWithout<TipoFormacao>(TipoFormacao.FundamentalIncompleto, TipoFormacao.FundamentalCompleto));

            listaPrestadores.Add(prestadorCpfConhecido);

            for (int i = 0; i < NumeroPrestadores; i++)
            {
                var prestador = new Prestador(_faker.Name.FullName(),
                                          _faker.Person.Cpf(),
                                          _faker.Address.FullAddress(),
                                          especialidades[_faker.Random.Int(0, 5)]);

                prestador.SetFormacao(instituicoes[_faker.Random.Int(0, 5)],
                                      "Medicina", 
                                      _faker.PickRandomWithout<TipoFormacao>(TipoFormacao.FundamentalIncompleto, TipoFormacao.FundamentalCompleto));

                listaPrestadores.Add(prestador);
            }

            return listaPrestadores;
        }
    }
}
