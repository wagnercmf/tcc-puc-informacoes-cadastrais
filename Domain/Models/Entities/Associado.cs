using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Associado : Pessoa
    {
        public Associado(string nome, string documento, string endereco) 
            : base(nome, documento, endereco)
        {
        }

        public PlanoSaude PlanoSaude { get; set; }
        public Saude Saude { get; set; }

        public void SetPlanoSaude(TipoPlano tipoPlano, StatusPlano statusPlano, FaixaEtaria faixaEtaria, ClassificacaoPlano classificacaoPlano, bool planoOdontologico)
        {
            new PlanoSaude(tipoPlano, statusPlano, faixaEtaria, classificacaoPlano, planoOdontologico);
        }

        public void SetInformacoesSaude(string instituicao, Frequencia frequenciaFumar, Frequencia frequenciaConsumoAlcool, List<string> doencas)
        {
            new Saude(instituicao, frequenciaFumar, frequenciaConsumoAlcool, doencas);
        }

        public double CalcularMensalidadePlano()
        {
            return PlanoSaude.CalcularValorMensalidade();
        }

        public double CalcularValorCoparticipacaoConsulta(double valorConsulta)
        {
            return PlanoSaude.CalcularValorCoparticipacaoConsulta(valorConsulta);
        }
    }
}
