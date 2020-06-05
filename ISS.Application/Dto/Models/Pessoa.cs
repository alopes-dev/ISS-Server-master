using ISS.Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Dto.Models
{
    public class Pessoa
    {
        [StringLength(50)]
        [Key]
        public string IdPessoa { get; set; }
        public string NomeCompleto { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }
        [Column("NIF")]
        [StringLength(100)]
        public string Nif { get; set; }
        [Column("ProcuradorID")]
        [StringLength(50)]
        public string ProcuradorId { get; set; }
        [StringLength(50)]
        public string CanalId { get; set; }
        public string NumSegurancaSocial { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column("EstadoID")]
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string TipoPessoaId { get; set; }
        [Column("UltModificacaoPorID")]
        [StringLength(50)]
        public string UltModificacaoPorId { get; set; }
        [StringLength(50)]
        public int NumEmpregados { get; set; }
        public double? RendimentoAnual { get; set; }
        public double? RendimentoMensal { get; set; }
        [StringLength(50)]
        public string CodPessoa { get; set; }
        public bool? EumPrestadorDeServico { get; set; }
        [Attributes.IsIdentity] public long NumPessoa { get; set; }
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("CanalId")]
        [InverseProperty("Pessoa")]
        public virtual Canal Canal { get; set; }
        [ForeignKey("EstadoId")]
        [InverseProperty("Pessoa")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("ProcuradorId")]
        [InverseProperty("InverseProcurador")]
        public virtual Pessoa Procurador { get; set; }
        [ForeignKey("TipoPessoaId")]
        [InverseProperty("PessoaNavigation")]
        public virtual TipoPessoa TipoPessoa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Actividade> ActividadeBeneficiario { get; set; }
        [InverseProperty("DonoPedido")]
        public virtual ICollection<Actividade> ActividadeDonoPedido { get; set; }
        [InverseProperty("PessoaResponsavel")]
        public virtual ICollection<Actividade> ActividadePessoaResponsavel { get; set; }
        [InverseProperty("PessoaResponsavel")]
        public virtual ICollection<Agenda> Agenda { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<AnexosPessoa> AnexosPessoa { get; set; }
        [InverseProperty("Produtor")]
        public virtual ICollection<Apolice> Apolice { get; set; }
        [InverseProperty("Aprovador")]
        public virtual ICollection<Aprovacao> AprovacaoAprovador { get; set; }
        [InverseProperty("Preponente")]
        public virtual ICollection<Aprovacao> AprovacaoPreponente { get; set; }
        [InverseProperty("Assinante")]
        public virtual ICollection<AssinantesResseguro> AssinantesResseguro { get; set; }
        [InverseProperty("Accionista")]
        public virtual ICollection<AccionistaEmpresa> AccionistaEmpresaAccionista { get; set; }
        [InverseProperty("Empresa")]
        public virtual ICollection<AccionistaEmpresa> AccionistaEmpresaEmpresa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Assinatura> Assinatura { get; set; }
        [InverseProperty("Proprietario")]
        public virtual ICollection<Automovel> Automovel { get; set; }
        [InverseProperty("Autorizador")]
        public virtual ICollection<Autorizacao> Autorizacao { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<BalcaoPlano> BalcaoPlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Beneficiario> Beneficiario { get; set; }
        [InverseProperty("Produtor")]
        public virtual ICollection<Bonus> Bonus { get; set; }
        [InverseProperty("AgenteProdutor")]
        public virtual ICollection<CanalComissionamentoProdutor> CanalComissionamentoProdutor { get; set; }
        public virtual ICollection<CarteiraCliente> CarteiraClienteProdutor { get; set; }
        [InverseProperty("Tomador")]
        public virtual ICollection<CarteiraCliente> CarteiraClienteTomador { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<CentroCusto> CentroCusto { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<CentroResponsabilidade> CentroResponsabilidade { get; set; }
        [InverseProperty("Fornecedor")]
        public virtual ICollection<CoPagamento> CoPagamento { get; set; }
        [InverseProperty("CompanhiaCoAsseguradora")]
        public virtual ICollection<CoSeguro> CoSeguro { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Comissao> Comissao { get; set; }
        [InverseProperty("Produtor")]
        public virtual ICollection<ComissaoSelecionada> ComissaoSelecionada { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Comissionamento> Comissionamento { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<ComissionamentoPlano> ComissionamentoPlano { get; set; }
        [InverseProperty("Proprietario")]
        public virtual ICollection<Construcao> Construcao { get; set; }
        [InverseProperty("Fornecedor")]
        public virtual ICollection<ConsumoPlafond> ConsumoPlafond { get; set; }
        [InverseProperty("GestorConta")]
        public virtual ICollection<ContaFinanceira> ContaFinanceira { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<ContactoPessoa> ContactoPessoa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<ContinentePlano> ContinentePlano { get; set; }
        [InverseProperty("Contratado")]
        public virtual ICollection<Contratados> Contratados { get; set; }
        [InverseProperty("Contratado")]
        public virtual ICollection<Contrato> Contrato { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<RendimentosPessoa> RendimentosPessoa { get; set; }
        [InverseProperty("Contratado")]
        public virtual ICollection<ContratoPrestadorEmpresa> ContratoPrestadorEmpresaContratado { get; set; }
        [InverseProperty("Contratante")]
        public virtual ICollection<ContratoPrestadorEmpresa> ContratoPrestadorEmpresaContratante { get; set; }
        [InverseProperty("PessoaResponsavelFuncionario1")]
        public virtual ICollection<ContratoPrestadorEmpresa> ContratoPrestadorEmpresaPessoaResponsavelFuncionario1 { get; set; }
        [InverseProperty("PessoaResponsavelPrestadorNavigation")]
        public virtual ICollection<ContratoPrestadorEmpresa> ContratoPrestadorEmpresaPessoaResponsavelPrestadorNavigation { get; set; }
        [InverseProperty("Cobrador")]
        public virtual ICollection<Cotacao> CotacaoCobrador { get; set; }
        [InverseProperty("PessoaContacto")]
        public virtual ICollection<Cotacao> CotacaoPessoaContacto { get; set; }
        [InverseProperty("Produtor")]
        public virtual ICollection<Cotacao> CotacaoProdutor { get; set; }
        [InverseProperty("ResponsavelAceitacao")]
        public virtual ICollection<Cotacao> CotacaoResponsavelAceitacao { get; set; }
        [InverseProperty("Tomador")]
        public virtual ICollection<Cotacao> CotacaoTomador { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Dependente> DependentePessoa { get; set; }
        [InverseProperty("PessoaDependente")]
        public virtual ICollection<Dependente> DependentePessoaDependente { get; set; }
        [InverseProperty("Produtor")]
        public virtual ICollection<Desconto> Desconto { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<DescontoSeleccionado> DescontoSeleccionado { get; set; }
        [InverseProperty("Produtor")]
        public virtual ICollection<Despesa> Despesa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<DespesaSeleccionada> DespesaSeleccionada { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<DocumentoIdentificacao> DocumentoIdentificacao { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<DuracaoTipoContratoPlano> DuracaoTipoContratoPlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<EnderecoPessoa> EnderecoPessoa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<EnderecoPlano> EnderecoPlano { get; set; }
        [InverseProperty("Entidade")]
        public virtual ICollection<Excedente> Excedente { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<NacionalidadePessoa> NacionalidadePessoa { get; set; }
        [InverseProperty("Entidade")]
        public virtual ICollection<FacultativoResseguro> FacultativoResseguro { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Fidelizacao> Fidelizacao { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<FidelizacaoPlano> FidelizacaoPlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<FormaContratacaoPlano> FormaContratacaoPlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<FormaLiquidacaoPremioPlano> FormaLiquidacaoPremioPlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<FormaPagamentoPlano> FormaPagamentoPlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<FraccionamentoPlano> FraccionamentoPlano { get; set; }
        [InverseProperty("Empresa")]
        public virtual ICollection<Funcionario> FuncionarioEmpresa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<FuncionarioInstalacoes> FuncionarioInstalacoes { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Funcionario> FuncionarioPessoa { get; set; }
        [InverseProperty("Administrador")]
        public virtual ICollection<GrupoPessoas> GrupoPessoas { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<HablitacoesLiterariasPlano> HablitacoesLiterariasPlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<InformacaoAdicional> InformacaoAdicional { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<InformacaoBancaria> InformacaoBancaria { get; set; }
        [InverseProperty("AgentePolicial")]
        public virtual ICollection<Infraccoes> InfraccoesAgentePolicial { get; set; }
        [InverseProperty("Condutor")]
        public virtual ICollection<Infraccoes> InfraccoesCondutor { get; set; }
        [InverseProperty("Procurador")]
        public virtual ICollection<Pessoa> InverseProcurador { get; set; }
        [InverseProperty("Fornecedor")]
        public virtual ICollection<Lesado> LesadoFornecedor { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Lesado> LesadoPessoa { get; set; }
        [InverseProperty("Produtor")]
        public virtual ICollection<LimiteCompetencia> LimiteCompetencia { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<ListaNegra> ListaNegra { get; set; }
        [InverseProperty("Produtor")]
        public virtual ICollection<MargemVendaProduto> MargemVendaProduto { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<MargemVendaSeleccionado> MargemVendaSeleccionado { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<MembroAssegurado> MembroAssegurado { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<MembrosGrupo> MembrosGrupo { get; set; }
        [InverseProperty("Motorista")]
        public virtual ICollection<MotoristaAutomovel> MotoristaAutomovel { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Nota> Nota { get; set; }
        [InverseProperty("CondutorSinistro")]
        public virtual ICollection<ObjectoEnvolvido> ObjectoEnvolvidoCondutorSinistro { get; set; }
        [InverseProperty("Dono")]
        public virtual ICollection<ObjectoEnvolvido> ObjectoEnvolvidoDono { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<ObjectoTrabalhoPessoa> ObjectoTrabalhoPessoa { get; set; }
        [InverseProperty("IntroduzidoPorNavigation")]
        public virtual ICollection<ObservacoesBoletimAdesao> ObservacoesBoletimAdesao { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<OrgaoRegularizador> OrgaoRegularizador { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Paciente> Paciente { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<PapelPessoa> PapelPessoa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<PapelPlano> PapelPlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<PerfilDesenvolvimentoPessoa> PerfilDesenvolvimentoPessoa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<PeriodoPlanoPlano> PeriodoPlanoPlano { get; set; }
        public virtual ICollection<PessoaTarefa> PessoaTarefa { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<PessoasPolitamenteExpostas> PessoasPolitamenteExpostas { get; set; }
        [InverseProperty("AgenteProdutor")]
        public virtual ICollection<PlanoComissionamentoProdutor> PlanoComissionamentoProdutor { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<PrecosAtosMedicos> PrecosAtosMedicos { get; set; }
        [InverseProperty("IdPessoaNavigation")]
        public virtual ICollection<PrecosMedicamentos> PrecosMedicamentos { get; set; }
        [InverseProperty("Prestador")]
        public virtual ICollection<ProdutosPrestadores> ProdutosPrestadores { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<ProfissaoPlano> ProfissaoPlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Questionario> Questionario { get; set; }
        [InverseProperty("CausadorDoIncidente")]
        public virtual ICollection<Reclamacao> ReclamacaoCausadorDoIncidente { get; set; }
        [InverseProperty("PessoaRelacionada")]
        public virtual ICollection<Reclamacao> ReclamacaoPessoaRelacionada { get; set; }
        [InverseProperty("Reclamador")]
        public virtual ICollection<Reclamacao> ReclamacaoReclamador { get; set; }
        [InverseProperty("ResponsavelPelaReclamacao")]
        public virtual ICollection<Reclamacao> ReclamacaoResponsavelPelaReclamacao { get; set; }
        [InverseProperty("PessoaSeguraNavigation")]
        public virtual ICollection<ReembolsoDespesasMedicas> ReembolsoDespesasMedicas { get; set; }
        [InverseProperty("PessoaSeguraNavigation")]
        public virtual ICollection<ReembolsoTratamentoDentario> ReembolsoTratamentoDentario { get; set; }
        [InverseProperty("Empregado")]
        public virtual ICollection<RenovacaoApolice> RenovacaoApolice { get; set; }
        [InverseProperty("Fornecedor")]
        public virtual ICollection<Reparacao> Reparacao { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Responsabilizado> Responsabilizado { get; set; }
        [InverseProperty("Mediador")]
        public virtual ICollection<Resseguro> ResseguroMediador { get; set; }
        [InverseProperty("Ressegurador")]
        public virtual ICollection<Resseguro> ResseguroRessegurador { get; set; }
        [InverseProperty("SeguradoraDirecta")]
        public virtual ICollection<Resseguro> ResseguroSeguradoraDirecta { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Scoring> Scoring { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<SectorActividadePlano> SectorActividadePlano { get; set; }
        [InverseProperty("AgenteProdutor")]
        public virtual ICollection<SectorActividadesProdutor> SectorActividadesProdutor { get; set; }
        [InverseProperty("AgenteProdutor")]
        public virtual ICollection<SegmentoComissionamentoProdutor> SegmentoComissionamentoProdutor { get; set; }
        [InverseProperty("Produtor")]
        public virtual ICollection<SegmentoObjectivosComerciais> SegmentoObjectivosComerciais { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<SegmentoProduto> SegmentoProduto { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<SegmentoProdutoPlano> SegmentoProdutoPlano { get; set; }
        [InverseProperty("IncidenteInspector")]
        public virtual ICollection<Sinistro> SinistroIncidenteInspector { get; set; }
        [InverseProperty("ParticipanteSinistro")]
        public virtual ICollection<Sinistro> SinistroParticipanteSinistro { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Sugestao> Sugestao { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<TarefasAgendamento> TarefasAgendamento { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Terceiro> Terceiro { get; set; }
        [InverseProperty("PessoaSeguraNavigation")]
        public virtual ICollection<TermoResponsabilidade> TermoResponsabilidadePessoaSeguraNavigation { get; set; }
        [InverseProperty("PrestadorServicoNavigation")]
        public virtual ICollection<TermoResponsabilidade> TermoResponsabilidadePrestadorServicoNavigation { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Testemunha> Testemunha { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<TipoEntidadePlano> TipoEntidadePlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<TipoPessoaPlano> TipoPessoaPlano { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<Titularidade> Titularidade { get; set; }
        [InverseProperty("Pessoa")]
        public virtual ICollection<RedeSocialPessoa> RedeSocialPessoa { get; set; }
    }
}
