namespace Application.Models
{
    public class AtendimentoInput
    {
        public string CpfPrestador { get; set; }
        public string CpfAssociado { get; set; }
        public DateTime DataAtendimento { get; set; }
        public double ValorConsulta { get; set; }
        public bool IsValid() => !string.IsNullOrEmpty(CpfAssociado) || !string.IsNullOrEmpty(CpfPrestador) || ValorConsulta <= 0;
    }
}
