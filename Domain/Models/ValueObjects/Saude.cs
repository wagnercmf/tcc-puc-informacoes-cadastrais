using Domain.Entities;
using Domain.Enums;
using System;
using System.Globalization;

namespace Domain.ValueObjects
{
    public class Saude
    {
        public string Instituicao { get; set; }
        public string Curso { get; set; }
        public TipoFormacao TipoFormacao { get; set; }
        public Frequencia FrequenciaFumar { get; set; }
        public Frequencia FrequenciaConsumoAlcool { get; set; }
        public List<string> Doencas { get; set; }
    }
}