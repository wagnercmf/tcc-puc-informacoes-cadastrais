using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Associado : Pessoa
    {
        public Associado(string nome, string documento, string endereco) : base(nome, documento, endereco)
        {
        }

        public PlanoSaude PlanoSaude { get; set; }
        public Saude Saude { get; set; }
    }
}
