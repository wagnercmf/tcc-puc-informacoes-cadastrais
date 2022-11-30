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
        public double ValorMensalidade { get; set; }
        public double ValorCopartipacao { get; set; } = 0.3;
        public ClassificacaoPlano ClassificacaoPlano { get; set; }
        public bool PlanoOdontologico { get; set; }

        public double CalcularValorMensalidade()
        {
            if(ClassificacaoPlano == ClassificacaoPlano.Enfermaria) 
                ValorMensalidade = (int)FaixaEtaria;
            if (ClassificacaoPlano == ClassificacaoPlano.Apartamento)
                ValorMensalidade = (int)FaixaEtaria*(double)1.5;
            if (ClassificacaoPlano == ClassificacaoPlano.Apartamento)
                ValorMensalidade = (int)FaixaEtaria*3;
            if (PlanoOdontologico && ClassificacaoPlano != ClassificacaoPlano.Vip)
                ValorMensalidade = ValorMensalidade * (double)1.15;
            return ValorMensalidade;
        }

        public double CalcularValorCoparticipacaoConsulta(double valorConsulta)
        {
            if (ClassificacaoPlano == ClassificacaoPlano.Vip)
                return 0;
            return valorConsulta* ValorCopartipacao;
        }
    }
}
