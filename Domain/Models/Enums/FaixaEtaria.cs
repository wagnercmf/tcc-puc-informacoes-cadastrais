using System.ComponentModel;

namespace Domain.Enums
{
    public enum FaixaEtaria
    {
        [Description("Entre 0 e 18 anos")]
        Jovem = 400,

        [Description("Entre 19 e 30 anos")]
        JovemAdulto = 600,

        [Description("Entre 31 e 65 anos")]
        Adulto = 800,

        [Description("Acima de 65 anos")]
        Idoso = 1000
    }
}
