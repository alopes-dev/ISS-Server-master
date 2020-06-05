using ISS.Application.Models;
using System;
using System.Collections.Generic;

namespace ISS.Application.Dto
{
    public class PessoaDtoBase
    {
        public string IdPessoa { get; set; }
        public string Nif { get; set; }
        public string NomeCompleto { get; set; }
        public string CodPessoa { get; set; }
        public string TipoPessoaId { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string EstadoId { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string CanalId { get; private set; }

        public Estado Estado { get; set; }
        public Canal Canal { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public IEnumerable<PapelDto> Papeis { get; set; }
        public IEnumerable<EnderecoDto> Enderecos { get; set; }
        public IEnumerable<ContactoDto> Contactos { get; set; }
        public IEnumerable<InformacaoBancariaDtoBase> InformacoesBancaria { get; set; }
    }

    /// <summary>
    /// Dto para albergar temporáriamente dos dados da pessoa singular.
    /// </summary>
    public class PessoaSingularDto : PessoaDtoBase
    {
        public string PrimeiroNome { get; set; }
        public string NomeDoMeio { get; set; }
        public string UltimoNome { get; set; }
        public string NomeCurto { get; set; }
        public string SituacaoEmpregoId { get; set; }
        public string RazoesDesemprego { get; set; }
        public string FaixaEtariaId { get; set; }
        public string Alias { get; set; }
        public string NumSegurancaSocial { get; set; }
        public string TipoSanguineoId { get; set; }
        public string DeficienciaId { get; set; }
        public string Pseudonimo { get; set; }
        public string EstadoCivilId { get; set; }
        public string SexoId { get; set; }
        public string TituloId { get; set; }
        public Sexo Sexo { get; set; }
        public Titulo Titulo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Deficiencia Deficiencia { get; set; }
        public FaixaEtaria FaixaEtaria { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public IEnumerable<PessoaSingularDto> Conjuges { get; set; }
        public IEnumerable<NacionalidadeDto> Nacionalidades { get; set; }
        public IEnumerable<HabilitacoesLiterariasDto> HabilitacoesLiterarias { get; set; }
        public IEnumerable<DependenteDto> Dependentes { get; set; }
        public IEnumerable<IdiomaPessoaDto> Idiomas { get; set; }
    }
}
