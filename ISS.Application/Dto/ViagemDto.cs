using System;

namespace ISS.Application.Dto
{
    /// <summary>
    /// Dto para albergar temporariamente os dados da viagem.
    /// </summary>
    public class ViagemDtoBase
    {
        public string IdDadosViagem { get; set; }
        public string PaisOrigemId { get; set; }
        public string PaisDestinoId { get; set; }
        public string MeioTransporteId { get; set; }
        public DateTime? DataCompraBilhete { get; set; }
        public string CompanhiaViagemId { get; set; }
        public string PeriodoPlanoId { get; set; }
    }
}
