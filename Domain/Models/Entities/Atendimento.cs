namespace Domain.Entities
{
    public class Atendimento 
    {
        public Atendimento(Prestador prestador, Associado associado, DateTime dataAtendimento, double valorConsulta)
        {
            Prestador = prestador;
            Associado = associado;
            DataAtendimento = dataAtendimento;
            ValorConsulta = valorConsulta;
        }

        public Prestador Prestador { get; set; }
        public Associado Associado { get; set; }
        public DateTime DataAtendimento { get; set; }
        public double ValorConsulta { get; set; }
        public double ValorCopartipacao { get { return CalcularValorCoparticipacao(); } }

        public double CalcularValorCoparticipacao()
        {
            return Associado.CalcularValorCoparticipacaoConsulta(ValorConsulta);
        }
    }
}
