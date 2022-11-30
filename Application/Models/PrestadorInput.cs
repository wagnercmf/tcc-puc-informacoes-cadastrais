using Domain.Enums;

namespace Application.Models
{
    public class PrestadorInput
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Instituicao { get; set; }
        public string Curso { get; set; }
        public int TipoFormacao { get; set; }
        public string Especialidade { get; set; }

        public bool IsValid() => !string.IsNullOrEmpty(Nome) || !string.IsNullOrEmpty(Documento) ||
            !string.IsNullOrEmpty(Endereco) || !string.IsNullOrEmpty(Instituicao) || !string.IsNullOrEmpty(Curso) || !string.IsNullOrEmpty(Especialidade);

    }
}
