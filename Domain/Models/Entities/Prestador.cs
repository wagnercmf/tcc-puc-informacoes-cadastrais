
namespace Domain.Entities
{
    public class Prestador : Pessoa
    {
        public Prestador(string nome, string documento, string endereco, string especialidade) 
            : base(nome, documento, endereco)
        {
            Especialidade = especialidade;
        }

        public string Especialidade { get; private set; }

    }
}