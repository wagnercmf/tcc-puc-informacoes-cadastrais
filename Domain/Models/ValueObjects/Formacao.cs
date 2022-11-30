using Domain.Enums;
namespace Domain.ValueObjects
{
    public class Formacao
    {
        public Formacao(string instituicao, string curso, TipoFormacao tipoFormacao)
        {
            Instituicao = instituicao;
            Profissao = curso;
            TipoFormacao = tipoFormacao;
        }

        public string Instituicao { get; set; }
        public string Profissao { get; set; }
        public TipoFormacao TipoFormacao { get; set; }
    }
}