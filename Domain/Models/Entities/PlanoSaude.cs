using Domain.Enums;

namespace Domain.Entities
{
    public class PlanoSaude
    {
        public int IdPlano { get; set; }
        public TipoPlano TipoPlano { get; set; }
        public StatusPlano StatusPlano { get; set; }
        public FaixaEtaria FaixaEtaria { get; set; }
        public decimal ValorMensalidade { get; set; }
        public ClassificacaoPlano ClassificacaoPlano { get; set; }
        public bool PlanoOdontologico { get; set; } //(+15% mensalidade, se não for VIP)
    }
}
