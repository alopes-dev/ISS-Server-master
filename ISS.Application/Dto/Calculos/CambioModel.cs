using System.Collections.Generic;

namespace ISS.Application.Dto.Calculos
{
    public class CambioModel
    {
        public string Moeda { get; set; }
        public string OutraMoeda { get; set; }

        public string MoedaId { get; set; }
        public string OutraMoedaId { get; set; }

        public string CodMoeda { get; set; }
        public string CodOutraMoeda { get; set; }

        public string SimboloMoeda { get; set; }
        public string SimboloOutraMoeda { get; set; }

        public double? Valor { get; set; }
        public double? ValorOutraMoeda { get; set; }
        public List<string> Mensagens = new List<string>();
    }

}
