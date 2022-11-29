using System.ComponentModel;

namespace Domain.Enums
{
    public enum FaixaEtaria
    {
        [Description("Entre 0 e 18 anos")]
        Jovem = 0,

        [Description("Entre 19 e 30 anos")]
        JovemAdulto = 1,

        [Description("Entre 31 e 65 anos")]
        Adulto = 2,

        [Description("Acima de 65 anos")]
        Idoso = 3
    }
}
