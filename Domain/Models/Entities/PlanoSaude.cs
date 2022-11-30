using Domain.Enums;

namespace Domain.Entities
{
    public class PlanoSaude
    {
        public PlanoSaude(TipoPlano tipoPlano, StatusPlano statusPlano, FaixaEtaria faixaEtaria, ClassificacaoPlano classificacaoPlano, bool planoOdontologico)
        {
            TipoPlano = tipoPlano;
            StatusPlano = statusPlano;
            FaixaEtaria = faixaEtaria;
            ClassificacaoPlano = classificacaoPlano;
            PlanoOdontologico = planoOdontologico;
        }

        public int IdPlano { get; set; }
        public TipoPlano TipoPlano { get; set; }
        public StatusPlano StatusPlano { get; set; }
        public FaixaEtaria FaixaEtaria { get; set; }
        public double ValorMensalidade { get { return CalcularValorMensalidade(); } }
        public double ValorCopartipacao { get; set; } = 0.3;
        public ClassificacaoPlano ClassificacaoPlano { get; set; }
        public bool PlanoOdontologico { get; set; }

        public double CalcularValorMensalidade()
        {
            double valorMensalidade = default;
            if(ClassificacaoPlano == ClassificacaoPlano.Enfermaria)
                valorMensalidade = (int)FaixaEtaria;
            if (ClassificacaoPlano == ClassificacaoPlano.Apartamento)
                valorMensalidade = (int)FaixaEtaria*(double)1.5;
            if (ClassificacaoPlano == ClassificacaoPlano.Vip)
                valorMensalidade = (int)FaixaEtaria*3;
            if (PlanoOdontologico && ClassificacaoPlano != ClassificacaoPlano.Vip)
                valorMensalidade = ValorMensalidade * (double)1.15;
            return valorMensalidade;
        }

        public double CalcularValorCoparticipacaoConsulta(double valorConsulta)
        {
            if (ClassificacaoPlano == ClassificacaoPlano.Vip)
                return 0;
            return valorConsulta* ValorCopartipacao;
        }
    }
}
