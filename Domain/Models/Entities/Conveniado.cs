using Domain.Enums;

namespace Domain.Entities
{
    public class Conveniado
    { 
        public TipoConveniado TipoConveniado { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public bool ConvenioAtivo { get; set; }

    }
}

