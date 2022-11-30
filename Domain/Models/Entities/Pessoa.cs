using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Pessoa
    {
        public Pessoa(string nome, string documento, string endereco)
        {
            Nome = nome;
            Documento = documento;
            Endereco = endereco;
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Endereco { get; private set; }
        public Formacao Formacao { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime DataAlteracao { get; private set; } 

        public void SetFormacao(string instituicao, string curso, TipoFormacao tipoFormacao)
        {
            Formacao = new Formacao(instituicao, curso, tipoFormacao);
        }
    }
}