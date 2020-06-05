using System;

namespace ISS.Application.Dto.Pessoa
{
    public class FuncionarioDto : PessoaSingularDto
    {
        public string NumIdentificacao { get; set; }
        public DateTime? DataContratacao { get; set; }
        public DateTime? DataInicioTrabalho { get; set; }
        public string DepartamentoId { get; set; }
        public string SectorId { get; set; }
        public string SeccaoId { get; set; }
        public string FuncaoId { get; set; }
        public string CategoriaId { get; set; }
        public string CargoFuncionarioId { get; set; }
        public string AreaId { get; set; }
        public int? NumeroCedulaProfissional { get; set; }
    }
}
