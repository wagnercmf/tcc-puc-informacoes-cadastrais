using Domain.Entities;
using Domain.Enums;
using System;
using System.Globalization;

namespace Domain.ValueObjects
{
    public class Saude
    {
        public Saude(string instituicao, Frequencia frequenciaFumar, Frequencia frequenciaConsumoAlcool, List<string> doencas)
        {
            Instituicao = instituicao;
            FrequenciaFumar = frequenciaFumar;
            FrequenciaConsumoAlcool = frequenciaConsumoAlcool;
            Doencas = doencas;
        }

        public string Instituicao { get; set; }
        public Frequencia FrequenciaFumar { get; set; }
        public Frequencia FrequenciaConsumoAlcool { get; set; }
        public List<string> Doencas { get; set; }
    }
}