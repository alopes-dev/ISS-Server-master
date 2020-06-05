using System;

namespace ISS.Application.Dto
{
    public class HabilitacoesLiterariasDto
    {
        public string IdHabilitacoesLiterariasPessoa { get; set; }
        public string HabilitacoesLiterariasId { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public string Designacao { get; set; }
        public string CursoId { get; set; }
        public string Curso { get; set; }
        public DateTime? DataInicioHabilitacao { get; set; }
        public DateTime? DataFimHabilitacao { get; set; }
        public string CodHabilitacoesLiterariasPessoa { get; set; }
    }
}