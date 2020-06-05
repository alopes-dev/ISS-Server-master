using System;
using ISS.Application;
using LinqToDB;
using System.Linq;
using ISS.Application.Dto;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.Calculo;
using ISS.Application.ViewModels;
using ISS.Application.Dto.Calculos;
using System.Threading.Tasks;
using System.Collections.Generic;
using ISS.GraphQL.Type.Base;
using ISS.GraphQL.Repository;
using ISS.Application.Cambio;
using ISS.GraphQL.ServiceExtentions;
using Microsoft.Extensions.DependencyInjection;
using ISS.GraphQL.Type;
using Microsoft.Data.SqlClient;
using Dapper;
using FileSystem.FileSystem;

namespace ISS.GraphQL.Query
{
    public class AppQuery : AppQueryBase
    {
        public AppQuery(IRepository repository) : base(repository)
        { 
            #region GraphQL Types Padronizados
            FieldGenericAsync<AccionistaEmpresaType, AccionistaEmpresa>();
            FieldGenericAsync<AcrescimoCapitalMinimoType, AcrescimoCapitalMinimo>();
            FieldGenericAsync<AcrescimoPremiosType, AcrescimoPremios>();
            FieldGenericAsync<ActividadeContratadaType, ActividadeContratada>();
            FieldGenericAsync<ActividadesAgendaType, ActividadesAgenda>();
            FieldGenericAsync<ActividadeType, Actividade>();
            FieldGenericAsync<ActividadePlanoType, ActividadePlano>();
            FieldGenericAsync<AgendaType, Agenda>();
            FieldGenericAsync<AgendaPlanoType, AgendaPlano>();
            FieldGenericAsync<AgravamentoAcidentesTrabalhoType, AgravamentoAcidentesTrabalho>();
            FieldGenericAsync<AgravamentoApoliceType, AgravamentoApolice>();
            FieldGenericAsync<AgravamentoDespesaType, AgravamentoDespesa>();
            FieldGenericAsync<AgravamentoLimiteComparticipacaoType, AgravamentoLimiteComparticipacao>();
            FieldGenericAsync<AgravamentoLinhaType, AgravamentoLinha>();
            FieldGenericAsync<AgravamentoPessoaType, AgravamentoPessoa>();
            FieldGenericAsync<AgravamentoPlanoType, AgravamentoPlano>();
            FieldGenericAsync<AgravamentoType, Agravamento>();
            FieldGenericAsync<AjudaCampoTabelaType, AjudaCampoTabela>();
            FieldGenericAsync<AmbitoPlanoType, AmbitoPlano>();
            FieldGenericAsync<AmbitoType, Ambito>();
            FieldGenericAsync<AnexosAutomovelType, AnexosAutomovel>();
            FieldGenericAsync<AnexosPessoaType, AnexosPessoa>();
            FieldGenericAsync<AnimaisType, Animais>();
            FieldGenericAsync<AnosType, Anos>();
            FieldGenericAsync<ApoliceType, Apolice>();
            FieldGenericAsync<AprovacaoType, Aprovacao>();
            FieldGenericAsync<AreaType, Area>();
            FieldGenericAsync<ArtigoType, Artigo>();
            FieldGenericAsync<AscensoresMontaCargaType, AscensoresMontaCarga>();
            FieldGenericAsync<AssinantesResseguroType, AssinantesResseguro>();
            FieldGenericAsync<AssinantesType, Assinantes>();
            FieldGenericAsync<AssinaturaType, Assinatura>();
            FieldGenericAsync<AtosMedicosType, AtosMedicos>();
            FieldGenericAsync<AutomovelType, Automovel>();
            FieldGenericAsync<AutoridadesContactadasType, AutoridadesContactadas>();
            FieldGenericAsync<AutoridadeSupervisaoType, AutoridadeSupervisao>();
            FieldGenericAsync<AutorizacaoType, Autorizacao>();
            FieldGenericAsync<BairroType, Bairro>();
            FieldGenericAsync<BalancoType, Balanco>();
            FieldGenericAsync<BalcaoPlanoType, BalcaoPlano>();
            FieldGenericAsync<BalcaoType, Balcao>();
            FieldGenericAsync<BancoType, Banco>();
            FieldGenericAsync<BemAfectadoType, BemAfectado>();
            FieldGenericAsync<BemSalvadoType, BemSalvado>();
            FieldGenericAsync<BeneficiarioType, Beneficiario>();
            FieldGenericAsync<BeneficioCoberturaType, BeneficioCobertura>();
            FieldGenericAsync<BoletimAdesaoSaudeType, BoletimAdesaoSaude>();
            FieldGenericAsync<BonusType, Bonus>();
            FieldGenericAsync<CaePlanoType, CaePlano>();
            FieldGenericAsync<CaeType, Cae>();
            FieldGenericAsync<CaixaType, Caixa>();
            FieldGenericAsync<CambioType, Cambio>();
            FieldGenericAsync<CanaisComissionamentoType, CanaisComissionamento>();
            FieldGenericAsync<CanalComissionamentoProdutorType, CanalComissionamentoProdutor>();
            FieldGenericAsync<CanalComissionamentoType, CanalComissionamento>();
            FieldGenericAsync<CanalContratosType, CanalContratos>();
            FieldGenericAsync<CanalDescontoType, CanalDesconto>();
            FieldGenericAsync<CanalPlanoType, CanalPlano>();
            FieldGenericAsync<CanalType, Canal>();
            FieldGenericAsync<CapitalPremioAutomovelType, CapitalPremioAutomovel>();
            FieldGenericAsync<CapitalSeguroAutomovelType, CapitalSeguroAutomovel>();
            FieldGenericAsync<CapituloType, Capitulo>();
            FieldGenericAsync<CaracteristicaAtutomovelType, CaracteristicaAtutomovel>();
            FieldGenericAsync<CaracteristicaClassificacaoType, CaracteristicaClassificacao>();
            FieldGenericAsync<CaracteristicaObjectoType, CaracteristicaObjecto>();
            FieldGenericAsync<CaracteristicasConstrucaoType, CaracteristicasConstrucao>();
            FieldGenericAsync<CaraterizacaoEventualType, CaraterizacaoEventual>();
            FieldGenericAsync<CarenciaType, Carencia>();
            FieldGenericAsync<CargoPublicoType, CargoPublico>();
            FieldGenericAsync<CargoType, Cargo>();
            FieldGenericAsync<CartaConducaoType, CartaConducao>();
            FieldGenericAsync<CartaoCreditoType, CartaoCredito>();
            FieldGenericAsync<CartaoPagamentoType, CartaoPagamento>();
            FieldGenericAsync<CarteiraClienteType, CarteiraCliente>();
            FieldGenericAsync<CasosInconsideravelAcidentePessoalType, CasosInconsideravelAcidentePessoal>();
            FieldGenericAsync<CategoriaFranquiaType, CategoriaFranquia>();
            FieldGenericAsync<CategoriaFuncaoType, CategoriaFuncao>();
            FieldGenericAsync<CategoriaGlossarioType, CategoriaGlossario>();
            FieldGenericAsync<CategoriaItensType, CategoriaItens>();
            FieldGenericAsync<CategoriaJustificacaoType, CategoriaJustificacao>();
            FieldGenericAsync<CategoriaLaboralType, CategoriaLaboral>();
            FieldGenericAsync<CategoriaMetricaKpiType, CategoriaMetricaKpi>();
            FieldGenericAsync<CategoriasProdutosInstalacoesType, CategoriasProdutosInstalacoes>();
            FieldGenericAsync<CategoriaSujeitoDanoType, CategoriaSujeitoDano>();
            FieldGenericAsync<CategoriaTarefaType, CategoriaTarefa>();
            FieldGenericAsync<CausadorSinistroType, CausadorSinistro>();
            FieldGenericAsync<CentroCustoType, CentroCusto>();
            FieldGenericAsync<CentroResponsabilidadeType, CentroResponsabilidade>();
            FieldGenericAsync<ChefeDepartamentoType, ChefeDepartamento>();
            FieldGenericAsync<ChefeSeccaoType, ChefeSeccao>();
            FieldGenericAsync<ChefeSectorType, ChefeSector>();
            FieldGenericAsync<CidadeType, Cidade>();
            FieldGenericAsync<CilindragemAutomovelType, CilindragemAutomovel>();
            FieldGenericAsync<CircunstanciaObjectoEnvolvidoType, CircunstanciaObjectoEnvolvido>();
            FieldGenericAsync<CircunstanciaPerdaType, CircunstanciaPerda>();
            FieldGenericAsync<ClasseCofreType, ClasseCofre>();
            FieldGenericAsync<ClasseContaType, ClasseConta>();
            FieldGenericAsync<ClasseModalidadeSeguroType, ClasseModalidadeSeguro>();
            FieldGenericAsync<ClasseRiscoType, ClasseRisco>();
            FieldGenericAsync<ClassificacaoAprovacaoType, ClassificacaoAprovacao>();
            FieldGenericAsync<ClassificacaoAscensoresMontaCargaType, ClassificacaoAscensoresMontaCarga>();
            FieldGenericAsync<ClassificacaoAutomovelType, ClassificacaoAutomovel>();
            FieldGenericAsync<ClassificacaoCaixaType, ClassificacaoCaixa>();
            FieldGenericAsync<ClassificacaoCascoType, ClassificacaoCasco>();
            FieldGenericAsync<ClassificacaoContaType, ClassificacaoConta>();
            FieldGenericAsync<ClassificacaoContratoResseguroType, ClassificacaoContratoResseguro>();
            FieldGenericAsync<ClassificacaoEntidadeType, ClassificacaoEntidade>();
            FieldGenericAsync<ClassificacaoGrupoType, ClassificacaoGrupo>();
            FieldGenericAsync<ClassificacaoImpostoType, ClassificacaoImposto>();
            FieldGenericAsync<ClassificacaoIncapacidadeType, ClassificacaoIncapacidade>();
            FieldGenericAsync<ClassificacaoIndustriaType, ClassificacaoIndustria>();
            FieldGenericAsync<ClassificacaoModalidadeCaeType, ClassificacaoModalidadeCae>();
            FieldGenericAsync<ClassificacaoOperacaoType, ClassificacaoOperacao>();
            FieldGenericAsync<ClassificacaoParticipanteSinistroType, ClassificacaoParticipanteSinistro>();
            FieldGenericAsync<ClassificacaoReclamacaoType, ClassificacaoReclamacao>();
            FieldGenericAsync<ClassificacaoType, Classificacao>();
            FieldGenericAsync<ClausulaType, Clausula>();
            FieldGenericAsync<ClienteType, Cliente>();
            FieldGenericAsync<CoberturaCosseguroType, CoberturaCosseguro>();
            FieldGenericAsync<CoberturaPlanoType, CoberturaPlano>();
            FieldGenericAsync<CoberturaResseguroType, CoberturaResseguro>();
            FieldGenericAsync<CoberturaSelecionadaType, CoberturaSelecionada>();
            FieldGenericAsync<CoberturaType, Cobertura>();
            FieldGenericAsync<CobradorType, Cobrador>();
            FieldGenericAsync<CodigoResponsabilidadeType, CodigoResponsabilidade>();
            FieldGenericAsync<CoeficienteLimiteIndemnizacaoPartoType, CoeficienteLimiteIndemnizacaoParto>();
            FieldGenericAsync<CoeficienteLimiteIndemnizacaoProteseOrtesesType, CoeficienteLimiteIndemnizacaoProteseOrteses>();
            FieldGenericAsync<CoeficientePremioAdesaoType, CoeficientePremioAdesao>();
            FieldGenericAsync<CoeficientePremioDoencasPreExistentesType, CoeficientePremioDoencasPreExistentes>();
            FieldGenericAsync<CoeficientePremioLimiteIndemnizacaoType, CoeficientePremioLimiteIndemnizacao>();
            FieldGenericAsync<CoeficientePremioPessoasType, CoeficientePremioPessoas>();
            FieldGenericAsync<CofreType, Cofre>();
            FieldGenericAsync<CombustivelType, Combustivel>();
            FieldGenericAsync<ComissaoPlanoType, ComissaoPlano>();
            FieldGenericAsync<ComissaoResseguroType, ComissaoResseguro>();
            FieldGenericAsync<ComissaoSelecionadaType, ComissaoSelecionada>();
            FieldGenericAsync<ComissaoType, Comissao>();
            FieldGenericAsync<ComissionamentoPlanoType, ComissionamentoPlano>();
            FieldGenericAsync<ComissionamentoType, Comissionamento>();
            FieldGenericAsync<ComiteType, Comite>();
            FieldGenericAsync<CompanhiaViagemType, CompanhiaViagem>();
            FieldGenericAsync<CompetenciaAreaType, CompetenciaArea>();
            FieldGenericAsync<ComponenteClassificacaoType, ComponenteClassificacao>();
            FieldGenericAsync<ComponenteSalarialPessoaType, ComponenteSalarialPessoa>();
            FieldGenericAsync<ComunaType, Comuna>();
            FieldGenericAsync<CondicaoAgravamentoType, CondicaoAgravamento>();
            FieldGenericAsync<CondicaoAplicacaoAgravamentoType, CondicaoAplicacaoAgravamento>();
            FieldGenericAsync<CondicaoAplicacaoTarifaType, CondicaoAplicacaoTarifa>();
            FieldGenericAsync<CondicaoOperacaoType, CondicaoOperacao>();
            FieldGenericAsync<CondicaoTarifaType, CondicaoTarifa>();
            FieldGenericAsync<CondicoesApoliceType, CondicoesApolice>();
            FieldGenericAsync<CondicoesCoSeguroType, CondicoesCoSeguro>();
            FieldGenericAsync<CondicoesProdutoType, CondicoesProduto>();
            FieldGenericAsync<CondicoesReSeguroType, CondicoesReSeguro>();
            FieldGenericAsync<CondicoesType, Condicoes>();
            FieldGenericAsync<ConjuguePessoaType, ConjuguePessoa>();
            FieldGenericAsync<ConsequenciaSinistroType, ConsequenciaSinistro>();
            FieldGenericAsync<ConstrucaoType, Construcao>();
            FieldGenericAsync<ConsumoPlafondType, ConsumoPlafond>();
            FieldGenericAsync<ContaBancariaPosType, ContaBancariaPos>();
            FieldGenericAsync<ContactoEmpresaType, ContactoEmpresa>();
            FieldGenericAsync<ContactoPessoaType, ContactoPessoa>();
            FieldGenericAsync<ContactoType, Contacto>();
            FieldGenericAsync<ContadoresRegistosType, ContadoresRegistos>();
            FieldGenericAsync<ContaFinanceiraType, ContaFinanceira>();
            FieldGenericAsync<ContaTerceirosType, ContaTerceiros>();
            FieldGenericAsync<ContinentePlanoType, ContinentePlano>();
            FieldGenericAsync<ContinenteType, Continente>();
            FieldGenericAsync<ContratadosAssinantesType, ContratadosAssinantes>();
            FieldGenericAsync<ContratadosType, Contratados>();
            FieldGenericAsync<ContratantesAssinantesType, ContratantesAssinantes>();
            FieldGenericAsync<ContratoCaeType, ContratoCae>();
            FieldGenericAsync<ContratoCanaisType, ContratoCanais>();
            FieldGenericAsync<ContratoClausulaType, ContratoClausula>();
            FieldGenericAsync<ContratoFormaPagamentoType, ContratoFormaPagamento>();
            FieldGenericAsync<ContratoMoedaType, ContratoMoeda>();
            FieldGenericAsync<ContratoPlanoType, ContratoPlano>();
            FieldGenericAsync<ContratoPrestadorEmpresaType, ContratoPrestadorEmpresa>();
            FieldGenericAsync<ContratoResseguroType, ContratoResseguro>();
            FieldGenericAsync<ContratoSegmentosType, ContratoSegmentos>();
            FieldGenericAsync<ContratoType, Contrato>();
            FieldGenericAsync<CoPagamentoType, CoPagamento>();
            FieldGenericAsync<CorType, Cor>();
            FieldGenericAsync<CoSeguroType, CoSeguro>();
            FieldGenericAsync<CotacaoDependenteType, CotacaoDependente>();
            FieldGenericAsync<CotacaoType, Cotacao>();
            FieldGenericAsync<CriterioComissionamentoType, CriterioComissionamento>();
            FieldGenericAsync<CriterioPlanoType, CriterioPlano>();
            FieldGenericAsync<CrossSellingRateType, CrossSellingRate>();
            FieldGenericAsync<CrossSellingType, CrossSelling>();
            FieldGenericAsync<CursosType, Cursos>();
            FieldGenericAsync<CustoType, Custo>();
            FieldGenericAsync<DeclaracaoTestemunhaType, DeclaracaoTestemunha>();
            FieldGenericAsync<DeficienciaType, Deficiencia>();
            FieldGenericAsync<DetalhePlanoType, DetalhePlano>();
            FieldGenericAsync<DenunciaType, Denuncia>();
            FieldGenericAsync<DepartamentoType, Departamento>();
            FieldGenericAsync<DependenteType, Dependente>();
            FieldGenericAsync<DescaraterizacaoEventualType, DescaraterizacaoEventual>();
            FieldGenericAsync<DescontoApoliceGrupoPlanoType, DescontoApoliceGrupoPlano>();
            FieldGenericAsync<DescontoApoliceGrupoType, DescontoApoliceGrupo>();
            FieldGenericAsync<DescontoFranquiaMedicamentoType, DescontoFranquiaMedicamento>();
            FieldGenericAsync<DescontoFranquiaType, DescontoFranquia>();
            FieldGenericAsync<DescontoLinhaType, DescontoLinha>();
            FieldGenericAsync<DescontoPessoaPlanoType, DescontoPessoaPlano>();
            FieldGenericAsync<DescontoPessoaType, DescontoPessoa>();
            FieldGenericAsync<DescontoPlanoType, DescontoPlano>();
            FieldGenericAsync<DescontoSeleccionadoType, DescontoSeleccionado>();
            FieldGenericAsync<DescontoTipoContaType, DescontoTipoConta>();
            FieldGenericAsync<DescontoType, Desconto>();
            FieldGenericAsync<DescricaoBeneficioCoberturaType, DescricaoBeneficioCobertura>();
            FieldGenericAsync<DescricaoTratamentoDentarioType, DescricaoTratamentoDentario>();
            FieldGenericAsync<DespesaLinhaType, DespesaLinha>();
            FieldGenericAsync<DespesaPlanoType, DespesaPlano>();
            FieldGenericAsync<DespesasCoberturaType, DespesasCobertura>();
            FieldGenericAsync<DespesaSeleccionadaType, DespesaSeleccionada>();
            FieldGenericAsync<DespesasTipoContaType, DespesasTipoConta>();
            FieldGenericAsync<DespesaType, Despesa>();
            FieldGenericAsync<DestaquesPaginaType, DestaquesPagina>();
            FieldGenericAsync<DesvalorizacaoInvalidezPermanenteType, DesvalorizacaoInvalidezPermanente>();
            FieldGenericAsync<DesvalorizacaoPlanoType, DesvalorizacaoPlano>();
            FieldGenericAsync<DesvalorizacaoType, Desvalorizacao>();
            FieldGenericAsync<DiasContagemType, DiasContagem>();
            FieldGenericAsync<DimensaoConstrucaoType, DimensaoConstrucao>();
            FieldGenericAsync<DimensaoEmpresaType, DimensaoEmpresa>();
            FieldGenericAsync<DireccaoEmpresaDepartamentoType, DireccaoEmpresaDepartamento>();
            FieldGenericAsync<DireccaoEmpresaType, DireccaoEmpresa>();
            FieldGenericAsync<DireccaoType, Direccao>();
            FieldGenericAsync<DirectorDireccaoType, DirectorDireccao>();
            FieldGenericAsync<DistritoType, Distrito>();
            FieldGenericAsync<DocumentoIdentificacaoType, DocumentoIdentificacao>();
            FieldGenericAsync<DocumentoMembroAsseguradoType, DocumentoMembroAssegurado>();
            FieldGenericAsync<DocumentosAnexosApoliceType, DocumentosAnexosApolice>();
            FieldGenericAsync<DocumentosCoberturasType, DocumentosCoberturas>();
            FieldGenericAsync<DocumentosLesadoType, DocumentosLesado>();
            FieldGenericAsync<DocumentosLinhaType, DocumentosLinha>();
            FieldGenericAsync<DocumentosNecessarioPorLinhaType, DocumentosNecessarioPorLinha>();
            FieldGenericAsync<DocumentosObjectoEnvolvidoType, DocumentosObjectoEnvolvido>();
            FieldGenericAsync<DocumentosObrigatorioPlanoType, DocumentosObrigatorioPlano>();
            FieldGenericAsync<DocumentosObrigatorioProdutoType, DocumentosObrigatorioProduto>();
            FieldGenericAsync<DocumentosTestemunhaType, DocumentosTestemunha>();
            FieldGenericAsync<DuracaoPremiosAcidentesPessoaisTemporarioType, DuracaoPremiosAcidentesPessoaisTemporario>();
            FieldGenericAsync<DuracaoTipoContratoPlanoType, DuracaoTipoContratoPlano>();
            FieldGenericAsync<DuracaoTipoContratoType, DuracaoTipoContrato>();
            FieldGenericAsync<EmissoraDocumentosType, EmissoraDocumentos>();
            FieldGenericAsync<EmpresaType, Empresa>();
            FieldGenericAsync<EncargoLinhaType, EncargoLinha>();
            FieldGenericAsync<EncargoPlanoType, EncargoPlano>();
            FieldGenericAsync<EncargosTipoContaType, EncargosTipoConta>();
            FieldGenericAsync<EncargosType, Encargos>();
            FieldGenericAsync<EnderecoPessoaType, EnderecoPessoa>();
            FieldGenericAsync<EnderecoPlanoType, EnderecoPlano>();
            FieldGenericAsync<EnderecoType, Endereco>();
            FieldGenericAsync<EntidadeEmpregadoraType, EntidadeEmpregadora>();
            FieldGenericAsync<EspecieAnimaisType, EspecieAnimais>();
            FieldGenericAsync<EstadoCivilPlanoType, EstadoCivilPlano>();
            FieldGenericAsync<EstadoCivilType, EstadoCivil>();
            FieldGenericAsync<EstadoType, Estado>();
            FieldGenericAsync<ExcedenteType, Excedente>();
            FieldGenericAsync<ExcepcoesPlanoType, ExcepcoesPlano>();
            FieldGenericAsync<ExcepcoesType, Excepcoes>();
            FieldGenericAsync<ExcessoPerdaType, ExcessoPerda>();
            FieldGenericAsync<ExclusoesCoberturaType, ExclusoesCobertura>();
            FieldGenericAsync<ExclusoesPlanoType, ExclusoesPlano>();
            FieldGenericAsync<ExclusoesSelecionadaApoliceType, ExclusoesSelecionadaApolice>();
            FieldGenericAsync<ExclusoesSelecionadaLinhaProdutoType, ExclusoesSelecionadaLinhaProduto>();
            FieldGenericAsync<ExclusoesSelecionadaPlanoType, ExclusoesSelecionadaPlano>();
            FieldGenericAsync<ExclusoesType, Exclusoes>();
            FieldGenericAsync<ExemplarModeloAutomovelType, ExemplarModeloAutomovel>();
            FieldGenericAsync<ExercicioType, Exercicio>();
            FieldGenericAsync<ExportacoesProdutosInstalacoesType, ExportacoesProdutosInstalacoes>();
            FieldGenericAsync<CalculoDetalheType, ISS.Application.Dto.CalculoDetalhe>();
            FieldGenericAsync<CalculoModelType, ISS.Application.Dto.CalculoModel>();
            FieldGenericAsync<FileDtoType, ISS.Application.Dto.FileDto>();
            FieldGenericAsync<FactorRiscoType, FactorRisco>();
            FieldGenericAsync<FaculdadeCursoType, FaculdadeCurso>();
            FieldGenericAsync<FaculdadeType, Faculdade>();
            FieldGenericAsync<FacultativoResseguroType, FacultativoResseguro>();
            FieldGenericAsync<FaixaEtariaType, FaixaEtaria>();
            FieldGenericAsync<FaseDocumentosObrigatorioType, FaseDocumentosObrigatorio>();
            FieldGenericAsync<FeriadoType, Feriado>();
            FieldGenericAsync<FidelizacaoComissionamentoType, FidelizacaoComissionamento>();
            FieldGenericAsync<FidelizacaoContratoType, FidelizacaoContrato>();
            FieldGenericAsync<FidelizacaoPlanoType, FidelizacaoPlano>();
            FieldGenericAsync<FidelizacaoType, Fidelizacao>();
            FieldGenericAsync<FileSystType, ISS.Application.Dto.FileSyst>();
            FieldGenericAsync<FiliacaoType, Filiacao>();
            FieldGenericAsync<FinalidadeApoliceType, FinalidadeApolice>();
            FieldGenericAsync<FormaContratacaoPlanoType, FormaContratacaoPlano>();
            FieldGenericAsync<FormaContratacaoType, FormaContratacao>();
            FieldGenericAsync<FormaEntregaType, FormaEntrega>();
            FieldGenericAsync<FormaLiquidacaoPremioPlanoType, FormaLiquidacaoPremioPlano>();
            FieldGenericAsync<FormaLiquidacaoPremioType, FormaLiquidacaoPremio>();
            FieldGenericAsync<FormaMovimentoContaFinanceiraType, FormaMovimentoContaFinanceira>();
            FieldGenericAsync<FormaPagamentoPlanoType, FormaPagamentoPlano>();
            FieldGenericAsync<FormaPagamentoType, FormaPagamento>();
            FieldGenericAsync<FormaReparacaoType, FormaReparacao>();
            FieldGenericAsync<FormaResseguroType, FormaResseguro>();
            FieldGenericAsync<FormasCobrancaType, FormasCobranca>();
            FieldGenericAsync<FormaTerminoType, FormaTermino>();
            FieldGenericAsync<FornecedorType, Fornecedor>();
            FieldGenericAsync<FotografiasObjectoEnvolvidoType, FotografiasObjectoEnvolvido>();
            FieldGenericAsync<FraccionamentoModelType, ISS.Application.Dto.FraccionamentoModel>();
            FieldGenericAsync<FraccionamentoPlanoType, FraccionamentoPlano>();
            FieldGenericAsync<FraccionamentoType, Fraccionamento>();
            FieldGenericAsync<FranquiaInvalidezTemporariaType, FranquiaInvalidezTemporaria>();
            FieldGenericAsync<FranquiaSeleccionadoType, FranquiaSeleccionado>();
            FieldGenericAsync<FranquiaType, Franquia>();
            FieldGenericAsync<FuncaoDependenteType, FuncaoDependente>();
            FieldGenericAsync<FuncaoType, Funcao>();
            FieldGenericAsync<FuncionalidadeType, Funcionalidade>();
            FieldGenericAsync<FuncionarioInstalacoesType, FuncionarioInstalacoes>();
            FieldGenericAsync<FuncionarioType, Funcionario>();
            FieldGenericAsync<GarantiaPlanoType, GarantiaPlano>();
            FieldGenericAsync<GarantiasAfetasDespesasMedicasType, GarantiasAfetasDespesasMedicas>();
            FieldGenericAsync<GarantiasCoberturaType, GarantiasCobertura>();
            FieldGenericAsync<GarantiasContratadasType, GarantiasContratadas>();
            FieldGenericAsync<GeneroPlanoType, GeneroPlano>();
            FieldGenericAsync<GetPlanoType, PlanoObjectivoCormecialDto>();
            FieldGenericAsync<GlossarioType, Glossario>();
            FieldGenericAsync<GpsautomovelType, Gpsautomovel>();
            FieldGenericAsync<GrauParentescoType, GrauParentesco>();
            FieldGenericAsync<GrupoEtarioType, GrupoEtario>();
            FieldGenericAsync<GrupoImpostoType, GrupoImposto>();
            FieldGenericAsync<GrupoPessoasType, GrupoPessoas>();
            FieldGenericAsync<HabilitacoesLiterariasPessoaType, HabilitacoesLiterariasPessoa>();
            FieldGenericAsync<HabilitacoesLiterariasType, HabilitacoesLiterarias>();
            FieldGenericAsync<HablitacoesLiterariasPlanoType, HablitacoesLiterariasPlano>();
            FieldGenericAsync<HistoricoAgravamentoType, HistoricoAgravamento>();
            FieldGenericAsync<HistoricoComissaoType, HistoricoComissao>();
            FieldGenericAsync<HistoricoContadoresRegistosType, HistoricoContadoresRegistos>();
            FieldGenericAsync<HistoricoDescontoType, HistoricoDesconto>();
            FieldGenericAsync<HistoricoDespesaType, HistoricoDespesa>();
            FieldGenericAsync<HistoricoEncargoType, HistoricoEncargo>();
            FieldGenericAsync<HistoricoFranquiaType, HistoricoFranquia>();
            FieldGenericAsync<HistoricoImpostoType, HistoricoImposto>();
            FieldGenericAsync<HistoricoLoginType, HistoricoLogin>();
            FieldGenericAsync<HistoricoMargemVendaProdutoType, HistoricoMargemVendaProduto>();
            FieldGenericAsync<HistoricoOfertaType, HistoricoOferta>();
            FieldGenericAsync<HistoricoPadraoType, HistoricoPadrao>();
            FieldGenericAsync<HistoricoPrecarioProdutoType, HistoricoPrecarioProduto>();
            FieldGenericAsync<HistoricoVerificacaoIdentidadeType, HistoricoVerificacaoIdentidade>();
            FieldGenericAsync<IdiomaPessoaType, IdiomaPessoa>();
            FieldGenericAsync<IdiomasType, Idiomas>();
            FieldGenericAsync<ImagemProdutoType, ImagemProduto>();
            FieldGenericAsync<ImagensConstrucaoType, ImagensConstrucao>();
            FieldGenericAsync<ImpostoLinhaType, ImpostoLinha>();
            FieldGenericAsync<ImpostoPrecarioType, ImpostoPrecario>();
            FieldGenericAsync<ImpostoTipoContaType, ImpostoTipoConta>();
            FieldGenericAsync<ImpostoTipoDocumentosType, ImpostoTipoDocumentos>();
            FieldGenericAsync<ImpostoType, Imposto>();
            FieldGenericAsync<IncapacidadePessoaType, IncapacidadePessoa>();
            FieldGenericAsync<IncapacidadeTemporariaType, IncapacidadeTemporaria>();
            FieldGenericAsync<IndeminizacaoType, Indeminizacao>();
            FieldGenericAsync<IndexadorType, Indexador>();
            FieldGenericAsync<IndiceCargaPneuType, IndiceCargaPneu>();
            FieldGenericAsync<IndiceVelocidadePneuType, IndiceVelocidadePneu>();
            FieldGenericAsync<InformacaoAdicionalType, InformacaoAdicional>();
            FieldGenericAsync<InformacaoBancariaContratoType, InformacaoBancariaContrato>();
            FieldGenericAsync<InformacaoBancariaPosType, InformacaoBancariaPos>();
            FieldGenericAsync<InformacaoBancariaType, InformacaoBancaria>();
            FieldGenericAsync<InformacaoSuporteType, InformacaoSuporte>();
            FieldGenericAsync<InformacoesAdicionaisProdutoType, InformacoesAdicionaisProduto>();
            FieldGenericAsync<InfraccoesType, Infraccoes>();
            FieldGenericAsync<InstalacoesType, Instalacoes>();
            FieldGenericAsync<InstitutoSuperiorType, InstitutoSuperior>();
            FieldGenericAsync<IntervaloRecorrenciaType, IntervaloRecorrencia>();
            FieldGenericAsync<ItensPerguntaType, ItensPergunta>();
            FieldGenericAsync<JustificacaoType, Justificacao>();
            FieldGenericAsync<LadoVolanteType, LadoVolante>();
            FieldGenericAsync<LeadType, Lead>();
            FieldGenericAsync<LembreteType, Lembrete>();
            FieldGenericAsync<LesadoType, Lesado>();
            FieldGenericAsync<LesaoLesadoType, LesaoLesado>();
            FieldGenericAsync<LicencaModuloType, LicencaModulo>();
            FieldGenericAsync<LicencaModuloUserType, LicencaModuloUser>();
            FieldGenericAsync<LicencaType, Licenca>();
            FieldGenericAsync<LimiteCoberturaType, LimiteCobertura>();
            FieldGenericAsync<LimiteComissionamentoPlanoType, LimiteComissionamentoPlano>();
            FieldGenericAsync<LimiteComissionamentoProdutorType, LimiteComissionamentoProdutor>();
            FieldGenericAsync<LimiteCompetenciaType, LimiteCompetencia>();
            FieldGenericAsync<LimiteGarantiaResponsabilidadeCivilType, LimiteGarantiaResponsabilidadeCivil>();
            FieldGenericAsync<LimiteResponsabilidadeType, LimiteResponsabilidade>();
            FieldGenericAsync<LimiteResponsablidadeCivilAutomovelType, LimiteResponsablidadeCivilAutomovel>();
            FieldGenericAsync<LimitesAceitacaoType, LimitesAceitacao>();
            FieldGenericAsync<LimitesComissionamentoType, LimitesComissionamento>();
            FieldGenericAsync<LimitesRapelType, LimitesRapel>();
            FieldGenericAsync<LinhaProdutoImpostoType, LinhaProdutoImposto>();
            FieldGenericAsync<LinhaProdutoType, LinhaProduto>();
            FieldGenericAsync<ListaNegraType, ListaNegra>();
            FieldGenericAsync<LocaisCoberturaType, LocaisCobertura>();
            FieldGenericAsync<LocaisComissaoType, LocaisComissao>();
            FieldGenericAsync<LocaisDescontoType, LocaisDesconto>();
            FieldGenericAsync<LocaisEncargoType, LocaisEncargo>();
            FieldGenericAsync<LocaisFranquiaType, LocaisFranquia>();
            FieldGenericAsync<LocaisImpostoType, LocaisImposto>();
            FieldGenericAsync<LocaisLimiteCompetenciaType, LocaisLimiteCompetencia>();
            FieldGenericAsync<LocaisObjectivosComerciaisType, LocaisObjectivosComerciais>();
            FieldGenericAsync<LocaisOfertaType, LocaisOferta>();
            FieldGenericAsync<LocalAplicacaoPlanoType, LocalAplicacaoPlano>();
            FieldGenericAsync<LocalConsultaType, LocalConsulta>();
            FieldGenericAsync<LocalidadeAntenaType, LocalidadeAntena>();
            FieldGenericAsync<LocalizacaoInstalacoesType, LocalizacaoInstalacoes>();
            FieldGenericAsync<LocalizacaoPneuType, LocalizacaoPneu>();
            FieldGenericAsync<LocalTrabalhoPessoaType, LocalTrabalhoPessoa>();
            FieldGenericAsync<LocalTrabalhoType, LocalTrabalho>();
            FieldGenericAsync<LugaresAutoAssegurarType, LugaresAutoAssegurar>();
            FieldGenericAsync<MapaType, Mapa>();
            FieldGenericAsync<MarcaAutomovelType, MarcaAutomovel>();
            FieldGenericAsync<MarcaGpsType, MarcaGps>();
            FieldGenericAsync<MargemVendaProdutoType, MargemVendaProduto>();
            FieldGenericAsync<MargemVendaSeleccionadoType, MargemVendaSeleccionado>();
            FieldGenericAsync<MediacaoComissaoType, MediacaoComissao>();
            FieldGenericAsync<MedicamentosPrestadoresType, MedicamentosPrestadores>();
            FieldGenericAsync<MedicamentosType, Medicamentos>();
            FieldGenericAsync<MedicoType, Medico>();
            FieldGenericAsync<MeioAutorizacaoType, MeioAutorizacao>();
            FieldGenericAsync<MeioTransporteType, MeioTransporte>();
            FieldGenericAsync<MembroAsseguradoType, MembroAssegurado>();
            FieldGenericAsync<MembroCadType, MembroCad>();
            FieldGenericAsync<MembrosGrupoType, MembrosGrupo>();
            FieldGenericAsync<MenuType, Menu>();
            FieldGenericAsync<MesesType, Meses>();
            FieldGenericAsync<MetodoSistemaAquecimentoType, MetodoSistemaAquecimento>();
            FieldGenericAsync<MetricaKpiType, MetricaKpi>();
            FieldGenericAsync<MetricasProdutoType, MetricasProduto>();
            FieldGenericAsync<ModalidadeAssegurarType, ModalidadeAssegurar>();
            FieldGenericAsync<ModalidadeAtrasoViagemType, ModalidadeAtrasoViagem>();
            FieldGenericAsync<ModalidadeContratoNaoProporcionalType, ModalidadeContratoNaoProporcional>();
            FieldGenericAsync<ModalidadeContratoProporcionalType, ModalidadeContratoProporcional>();
            FieldGenericAsync<ModalidadeReembolsoType, ModalidadeReembolso>();
            FieldGenericAsync<ModalidadeSeguroType, ModalidadeSeguro>();
            FieldGenericAsync<ModalidadesRcselecionadasType, ModalidadesRcselecionadas>();
            FieldGenericAsync<ModalidadesResponsabilidadeCivilType, ModalidadesResponsabilidadeCivil>();
            FieldGenericAsync<ModeloAutomovelType, ModeloAutomovel>();
            FieldGenericAsync<ModeloGpsType, ModeloGps>();
            FieldGenericAsync<ModeloMapaType, ModeloMapa>();
            FieldGenericAsync<ModificacaoType, Modificacao>();
            FieldGenericAsync<ModuloCoreDireccaoType, ModuloCoreDireccao>();
            FieldGenericAsync<ModuloCoreType, ModuloCore>();
            FieldGenericAsync<MoedaType, Moeda>();
            FieldGenericAsync<MotivoViagemType, MotivoViagem>();
            FieldGenericAsync<MotoristaAutomovelType, MotoristaAutomovel>();
            FieldGenericAsync<MotoristaType, Motorista>();
            FieldGenericAsync<MovimentoHistoricoType, MovimentoHistorico>();
            FieldGenericAsync<MovimentoType, Movimento>();
            FieldGenericAsync<MunicipioType, Municipio>();
            FieldGenericAsync<NacionalidadePessoaPlanoType, NacionalidadePessoaPlano>();
            FieldGenericAsync<NacionalidadePessoaType, NacionalidadePessoa>();
            FieldGenericAsync<NaturezaMovimentoType, NaturezaMovimento>();
            FieldGenericAsync<NewsletterType, Newsletter>();
            FieldGenericAsync<NivelAbrangenciaType, NivelAbrangencia>();
            FieldGenericAsync<NivelAcessoType, NivelAcesso>();
            FieldGenericAsync<NivelCompetenciaType, NivelCompetencia>();
            FieldGenericAsync<NivelDesempenhoType, NivelDesempenho>();
            FieldGenericAsync<NivelRiscoCoberturaType, NivelRiscoCobertura>();
            FieldGenericAsync<NivelRiscoType, NivelRisco>();
            FieldGenericAsync<NotasType, Notas>();
            FieldGenericAsync<NotaType, Nota>();
            FieldGenericAsync<NumeroPessoasAbrangivelType, NumeroPessoasAbrangivel>();
            FieldGenericAsync<ObjectivoComercialType, ObjectivoComercial>();
            FieldGenericAsync<ObjectivoPlanoType, ObjectivoPlano>();
            FieldGenericAsync<ObjectivoProdutoType, ObjectivoProduto>();
            FieldGenericAsync<ObjectivosAreaType, ObjectivosArea>();
            FieldGenericAsync<ObjectivosComerciaisType, ObjectivosComerciais>();
            FieldGenericAsync<ObjectoEnvolvidoType, ObjectoEnvolvido>();
            FieldGenericAsync<ObjectoSeguradoType, ObjectoSegurado>();
            FieldGenericAsync<ObjectoTrabalhoPessoaType, ObjectoTrabalhoPessoa>();
            FieldGenericAsync<ObjectoTrabalhoType, ObjectoTrabalho>();
            FieldGenericAsync<ObrigacoesProdutoType, ObrigacoesProduto>();
            FieldGenericAsync<ObservacoesBoletimAdesaoType, ObservacoesBoletimAdesao>();
            FieldGenericAsync<OfertaLinhaType, OfertaLinha>();
            FieldGenericAsync<OfertaPlanoType, OfertaPlano>();
            FieldGenericAsync<OpcaoType, Opcao>();
            FieldGenericAsync<OperacaoPlanoType, OperacaoPlano>();
            FieldGenericAsync<OperacaoType, Operacao>();
            FieldGenericAsync<OperaccoesPagamentoType, OperaccoesPagamento>();
            FieldGenericAsync<OperacoesCrudpessoaType, OperacoesCrudpessoa>();
            FieldGenericAsync<OperacoesCrudType, OperacoesCrud>();
            FieldGenericAsync<OperacoesPagamentoType, OperacoesPagamento>();
            FieldGenericAsync<OperacoesRecebimentoType, OperacoesRecebimento>();
            FieldGenericAsync<OrgaoRegularizadorType, OrgaoRegularizador>();
            FieldGenericAsync<OrigemFabricoEmbalagemType, OrigemFabricoEmbalagem>();
            FieldGenericAsync<OutraSeguradoraContratoType, OutraSeguradoraContrato>();
            FieldGenericAsync<OutrasInformacoesSinistroType, OutrasInformacoesSinistro>();
            FieldGenericAsync<OutrosContratosApoliceType, OutrosContratosApolice>();
            FieldGenericAsync<OutrosSegurosType, OutrosSeguros>();
            FieldGenericAsync<PacienteType, Paciente>();
            FieldGenericAsync<PadraoRecorrenciaType, PadraoRecorrencia>();
            // FieldGenericAsync<PagamentoType, Pagamento>();
            FieldGenericAsync<PaisesPlanoProdutoType, PaisesPlanoProduto>();
            FieldGenericAsync<PaisType, Pais>();
            FieldGenericAsync<PapelDescontoType, PapelDesconto>();
            FieldGenericAsync<PapelModuloFuncionalidadeType, PapelModuloFuncionalidade>();
            FieldGenericAsync<PapelModuloPessoaType, PapelModuloPessoa>();
            FieldGenericAsync<PapelPessoaResseguroType, PapelPessoaResseguro>();
            FieldGenericAsync<PapelPessoaType, PapelPessoa>();
            FieldGenericAsync<PapelPlanoType, PapelPlano>();
            FieldGenericAsync<PapelProdutorType, PapelProdutor>();
            FieldGenericAsync<PapelType, Papel>();
            FieldGenericAsync<PerdaType, Perda>();
            FieldGenericAsync<PerfilDesenvolvimentoPessoaType, PerfilDesenvolvimentoPessoa>();
            FieldGenericAsync<PerfilDesenvolvimentoType, PerfilDesenvolvimento>();
            FieldGenericAsync<PerguntasFrequentesEmpresaType, PerguntasFrequentesEmpresa>();
            FieldGenericAsync<PerguntasFrequentesProdutoType, PerguntasFrequentesProduto>();
            FieldGenericAsync<PerguntasType, Perguntas>();
            FieldGenericAsync<PeriodoAnualImpostoType, PeriodoAnualImposto>();
            FieldGenericAsync<PeriodoCoberturaProdutoType, PeriodoCoberturaProduto>();
            FieldGenericAsync<PeriodoPlanoPlanoType, PeriodoPlanoPlano>();
            FieldGenericAsync<PeriodoPlanoType, PeriodoPlano>();
            FieldGenericAsync<PeriodoType, Periodo>();
            FieldGenericAsync<PerspicaciaType, Perspicacia>();
            FieldGenericAsync<PesoAutomovelType, PesoAutomovel>();
            FieldGenericAsync<PessoaContactoContratadoType, PessoaContactoContratado>();
            FieldGenericAsync<PessoaContactoContratanteType, PessoaContactoContratante>();
            FieldGenericAsync<PessoaMovimentoType, PessoaMovimento>();
            FieldGenericAsync<PessoaProfissaoType, PessoaProfissao>();
            FieldGenericAsync<PessoasAbrangidasType, PessoasAbrangidas>();
            FieldGenericAsync<PessoasPolitamenteExpostasType, PessoasPolitamenteExpostas>();
            FieldGenericAsync<PessoasPosType, PessoasPos>();
            FieldGenericAsync<PessoaTarefaType, PessoaTarefa>();
            FieldGenericAsync<PessoaType, Pessoa>();
            FieldGenericAsync<PlanoComercialPorProdutorType, PlanoComercialPorProdutor>();
            FieldGenericAsync<PlanoComissionamentoProdutorType, PlanoComissionamentoProdutor>();
            FieldGenericAsync<PlanoContasType, PlanoContas>();
            FieldGenericAsync<PlanoLimiteComissionamentoProdutorType, PlanoLimiteComissionamentoProdutor>();
            FieldGenericAsync<PlanoObjectivoComercialType, PlanoObjectivoComercial>();
            FieldGenericAsync<PlanoProdutoType, PlanoProduto>();
            FieldGenericAsync<PneuType, Pneu>();
            FieldGenericAsync<PontosClausulaType, PontosClausula>();
            FieldGenericAsync<PortfolioProdutoType, PortfolioProduto>();
            FieldGenericAsync<PosicaoType, Posicao>();
            FieldGenericAsync<PosType, Pos>();
            FieldGenericAsync<PrazosCurtosType, PrazosCurtos>();
            FieldGenericAsync<PrazosType, Prazos>();
            FieldGenericAsync<PrecarioProdutoType, PrecarioProduto>();
            FieldGenericAsync<PrecosAtosMedicosType, PrecosAtosMedicos>();
            FieldGenericAsync<PrecosMedicamentosType, PrecosMedicamentos>();
            FieldGenericAsync<PrecosProdutosFarmaceuticosType, PrecosProdutosFarmaceuticos>();
            FieldGenericAsync<PrejuizoSofridoVeiculoTerceiroType, PrejuizoSofridoVeiculoTerceiro>();
            FieldGenericAsync<PremiosCoberturaAcidentesPessoaisType, PremiosCoberturaAcidentesPessoais>();
            FieldGenericAsync<PremiosExploracaoRuralType, PremiosExploracaoRural>();
            FieldGenericAsync<PremiosMercadoriasNaoOrdinariasType, PremiosMercadoriasNaoOrdinarias>();
            FieldGenericAsync<PremiosMinimosType, PremiosMinimos>();
            FieldGenericAsync<PremiosProfissoesAgravamentoType, PremiosProfissoesAgravamento>();
            FieldGenericAsync<PremiosRiscosSimplesOrdinariosType, PremiosRiscosSimplesOrdinarios>();
            FieldGenericAsync<PremiosRiscosSimplesType, PremiosRiscosSimples>();
            FieldGenericAsync<PremiosType, Premios>();
            FieldGenericAsync<PressupostoAcidentePessoalType, PressupostoAcidentePessoal>();
            FieldGenericAsync<PrestacoesFraccionamentoType, PrestacoesFraccionamento>();
            FieldGenericAsync<PrestadorType, Prestador>();
            FieldGenericAsync<PrioridadeTarefaType, PrioridadeTarefa>();
            FieldGenericAsync<PrioridadeType, Prioridade>();
            FieldGenericAsync<ProcessoFuncionalidadeType, ProcessoFuncionalidade>();
            FieldGenericAsync<ProcessoType, Processo>();
            FieldGenericAsync<ProdutosEmpresaType, ProdutosEmpresa>();
            FieldGenericAsync<ProdutosFarmaceuticosType, ProdutosFarmaceuticos>();
            FieldGenericAsync<ProdutosInstalacoesType, ProdutosInstalacoes>();
            FieldGenericAsync<ProdutosPrestadoresType, ProdutosPrestadores>();
            FieldGenericAsync<ProdutoType, Produto>();
            FieldGenericAsync<ProfissaoPlanoType, ProfissaoPlano>();
            FieldGenericAsync<ProfissaoType, Profissao>();
            FieldGenericAsync<ProvinciaComissionamentoType, ProvinciaComissionamento>();
            FieldGenericAsync<ProvinciaPlanoType, ProvinciaPlano>();
            FieldGenericAsync<ProvinciasLimitesComissionamentoProdutorType, ProvinciasLimitesComissionamentoProdutor>();
            FieldGenericAsync<ProvinciaType, Provincia>();
            FieldGenericAsync<QuadroDanosType, QuadroDanos>();
            FieldGenericAsync<QualidadeProponenteType, QualidadeProponente>();
            FieldGenericAsync<QualidadeSeguraType, QualidadeSegura>();
            FieldGenericAsync<QuestionarioType, Questionario>();
            FieldGenericAsync<RamoQualidadeSeguraType, RamoQualidadeSegura>();
            FieldGenericAsync<RapelProdutorType, RapelProdutor>();
            FieldGenericAsync<ReciboType, Recibo>();
            FieldGenericAsync<ReclamacaoType, Reclamacao>();
            FieldGenericAsync<RecorrenciaDiarioType, RecorrenciaDiario>();
            FieldGenericAsync<RecorrenciaMesAnoType, RecorrenciaMesAno>();
            FieldGenericAsync<RecorrenciaSemanalType, RecorrenciaSemanal>();
            FieldGenericAsync<RedeSociaisType, RedeSociais>();
            FieldGenericAsync<RedeSocialPessoaType, RedeSocialPessoa>();
            FieldGenericAsync<ReducaoPremioAcidentesTrabalhoType, ReducaoPremioAcidentesTrabalho>();
            FieldGenericAsync<ReducoesAutorizadasType, ReducoesAutorizadas>();
            FieldGenericAsync<ReembolsoDespesasMedicasType, ReembolsoDespesasMedicas>();
            FieldGenericAsync<ReembolsoTratamentoDentarioType, ReembolsoTratamentoDentario>();
            FieldGenericAsync<RegiaoType, Regiao>();
            FieldGenericAsync<ReivindicacoesFeitasApoliceType, ReivindicacoesFeitasApolice>();
            FieldGenericAsync<RelatorioContaType, RelatorioConta>();
            FieldGenericAsync<RelatorioLinksType, RelatorioLinks>();
            FieldGenericAsync<RelatorioPoliciaType, RelatorioPolicia>();
            FieldGenericAsync<RelatorioProdutoType, RelatorioProduto>();
            FieldGenericAsync<RelatorioType, Relatorio>();
            FieldGenericAsync<RendimentosPessoaType, RendimentosPessoa>();
            FieldGenericAsync<RenovacaoApoliceType, RenovacaoApolice>();
            FieldGenericAsync<ReparacaoType, Reparacao>();
            FieldGenericAsync<ReservasTecnicasType, ReservasTecnicas>();
            FieldGenericAsync<ResponsabilizadoType, Responsabilizado>();
            FieldGenericAsync<ResponsavelBalcaoType, ResponsavelBalcao>();
            FieldGenericAsync<ResponsavelObrigacoesType, ResponsavelObrigacoes>();
            FieldGenericAsync<RespostaPerguntaType, RespostaPergunta>();
            FieldGenericAsync<ResseguroType, Resseguro>();
            FieldGenericAsync<RestricoesCategoriasCartaConducaoType, RestricoesCategoriasCartaConducao>();
            FieldGenericAsync<RestricoesPessoaisCartaConducaoType, RestricoesPessoaisCartaConducao>();
            FieldGenericAsync<RestricoesViaturaCartaConducaoType, RestricoesViaturaCartaConducao>();
            FieldGenericAsync<RiscoOutraSeguradoraContratoType, RiscoOutraSeguradoraContrato>();
            FieldGenericAsync<RiscoPlanoProdutoType, RiscoPlanoProduto>();
            FieldGenericAsync<RiscosExcluidosType, RiscosExcluidos>();
            FieldGenericAsync<RiscoType, Risco>();
            FieldGenericAsync<RuaType, Rua>();
            FieldGenericAsync<RendimentoPessoaType, RendimentoPessoa>();
            FieldGenericAsync<SaldoType, Saldo>();
            FieldGenericAsync<ScoringType, Scoring>();
            FieldGenericAsync<SeccaoType, Seccao>();
            FieldGenericAsync<SectorActividadeComissionamentoType, SectorActividadeComissionamento>();
            FieldGenericAsync<SectorActividadePlanoType, SectorActividadePlano>();
            FieldGenericAsync<SectorActividadesProdutorType, SectorActividadesProdutor>();
            FieldGenericAsync<SectorActividadeType, SectorActividade>();
            FieldGenericAsync<SectorAtividadeEconomicaType, SectorAtividadeEconomica>();
            FieldGenericAsync<SectorType, Sector>();
            FieldGenericAsync<SegmentoComissionamentoProdutorType, SegmentoComissionamentoProdutor>();
            FieldGenericAsync<SegmentoFranquiaType, SegmentoFranquia>();
            FieldGenericAsync<SegmentoObjectivosComerciaisType, SegmentoObjectivosComerciais>();
            FieldGenericAsync<SegmentoOfertaType, SegmentoOferta>();
            FieldGenericAsync<SegmentoProdutoPlanoType, SegmentoProdutoPlano>();
            FieldGenericAsync<SegmentoProdutoType, SegmentoProduto>();
            FieldGenericAsync<SegmentoTipoCoberturaType, SegmentoTipoCobertura>();
            FieldGenericAsync<SeguradoType, Segurado>();
            FieldGenericAsync<ServicosAdicionaisType, ServicosAdicionais>();
            FieldGenericAsync<ServicosBaseType, ServicosBase>();
            FieldGenericAsync<ServicoType, Servico>();
            FieldGenericAsync<SessaoImpostoType, SessaoImposto>();
            FieldGenericAsync<SexoPlanoType, SexoPlano>();
            FieldGenericAsync<SexoType, Sexo>();
            FieldGenericAsync<SimulacaoType, Simulacao>();
            FieldGenericAsync<SimulacaoDependenteType, SimulacaoDependente>();
            FieldGenericAsync<SinistradoType, Sinistrado>();
            FieldGenericAsync<SinistroType, Sinistro>();
            FieldGenericAsync<SistemaAquecimentoType, SistemaAquecimento>();
            FieldGenericAsync<SistemaLiquidacaoSinistroType, SistemaLiquidacaoSinistro>();
            FieldGenericAsync<SituacaoEmpregoType, SituacaoEmprego>();
            FieldGenericAsync<SlideType, Slide>();
            FieldGenericAsync<SobrePremioCoberturaAdicionalType, SobrePremioCoberturaAdicional>();
            FieldGenericAsync<SubCategoriaItensType, SubCategoriaItens>();
            FieldGenericAsync<SubClasseModalidadeSeguroType, SubClasseModalidadeSeguro>();
            FieldGenericAsync<SubClassificacaoContratoResseguroType, SubClassificacaoContratoResseguro>();
            FieldGenericAsync<SubClausulasPontosType, SubClausulasPontos>();
            FieldGenericAsync<SubFormaResseguroInformacaoType, SubFormaResseguroInformacao>();
            FieldGenericAsync<SubFormaResseguroType, SubFormaResseguro>();
            FieldGenericAsync<SubPontoAmbitoType, SubPontoAmbito>();
            FieldGenericAsync<SubPontosClausulaType, SubPontosClausula>();
            FieldGenericAsync<SubRamoType, SubRamo>();
            FieldGenericAsync<SubRiscoType, SubRisco>();
            FieldGenericAsync<SubscricaoCessaoRetencaoType, SubscricaoCessaoRetencao>();
            FieldGenericAsync<SubSectorType, SubSector>();
            FieldGenericAsync<SubTarefaType, SubTarefa>();
            FieldGenericAsync<SubTipoContaType, SubTipoConta>();
            FieldGenericAsync<SubTipoDeRecebimentoType, SubTipoDeRecebimento>();
            FieldGenericAsync<SubTipoDesvalorizacaoType, SubTipoDesvalorizacao>();
            FieldGenericAsync<SubTipoPagamentoType, SubTipoPagamento>();
            FieldGenericAsync<SubTituloDesvalorizacaoInvalidezPermanenteType, SubTituloDesvalorizacaoInvalidezPermanente>();
            FieldGenericAsync<SugestaoType, Sugestao>();
            FieldGenericAsync<TabuaAngm1940Type, TabuaAngm1940>();
            FieldGenericAsync<TabuaAngv2020PType, TabuaAngv2020P>();
            FieldGenericAsync<TarefaRecorrenteType, TarefaRecorrente>();
            FieldGenericAsync<TarefaReparacaoType, TarefaReparacao>();
            FieldGenericAsync<TarefasActividadeType, TarefasActividade>();
            FieldGenericAsync<TarefasAgendamentoType, TarefasAgendamento>();
            FieldGenericAsync<TarefaType, Tarefa>();
            FieldGenericAsync<TarefaPlanoType, TarefaPlano>();
            FieldGenericAsync<TarifasAutomovelType, TarifasAutomovel>();
            FieldGenericAsync<TarifasDanosPropriosType, TarifasDanosProprios>();
            FieldGenericAsync<TarifasPremioAutoAcidentesTrabalhoType, TarifasPremioAutoAcidentesTrabalho>();
            FieldGenericAsync<TarifasPremioAutoAt2Type, TarifasPremioAutoAt2>();
            FieldGenericAsync<TarifasResponsabilidadeCivilType, TarifasResponsabilidadeCivil>();
            FieldGenericAsync<TarifaType, Tarifa>();
            FieldGenericAsync<TaxaPremioFixoIndicNomeType, TaxaPremioFixoIndicNome>();
            FieldGenericAsync<TaxaSinistralidadeType, TaxaSinistralidade>();
            FieldGenericAsync<TaxasType, Taxas>();
            FieldGenericAsync<TerceiroType, Terceiro>();
            FieldGenericAsync<TermoResponsabilidadeType, TermoResponsabilidade>();
            FieldGenericAsync<TestemunhaType, Testemunha>();
            FieldGenericAsync<TipoAcompanhamentoType, TipoAcompanhamento>();
            FieldGenericAsync<TipoActividadeType, TipoActividade>();
            FieldGenericAsync<TipoAdesaoType, TipoAdesao>();
            FieldGenericAsync<TipoAgravamentoType, TipoAgravamento>();
            FieldGenericAsync<TipoApoliceType, TipoApolice>();
            FieldGenericAsync<TipoAprovacaoType, TipoAprovacao>();
            FieldGenericAsync<TipoAutoridadeType, TipoAutoridade>();
            FieldGenericAsync<TipoCaixaType, TipoCaixa>();
            FieldGenericAsync<TipoCartaConducaoType, TipoCartaConducao>();
            FieldGenericAsync<TipoCartaoPagamentoType, TipoCartaoPagamento>();
            FieldGenericAsync<TipoCasaType, TipoCasa>();
            FieldGenericAsync<TipoClasseContaType, TipoClasseConta>();
            FieldGenericAsync<TipoClassificacaoGrupoType, TipoClassificacaoGrupo>();
            FieldGenericAsync<TipoClassificacaoModalidadeCaeType, TipoClassificacaoModalidadeCae>();
            FieldGenericAsync<TipoClienteType, TipoCliente>();
            FieldGenericAsync<TipoCoberturaType, TipoCobertura>();
            FieldGenericAsync<TipoCofreType, TipoCofre>();
            FieldGenericAsync<TipoCombustivelType, TipoCombustivel>();
            FieldGenericAsync<TipoComissaoType, TipoComissao>();
            FieldGenericAsync<TipoComissionamentoResseguroType, TipoComissionamentoResseguro>();
            FieldGenericAsync<TipoCondicoesType, TipoCondicoes>();
            FieldGenericAsync<TipoConstrucaoPneusType, TipoConstrucaoPneus>();
            FieldGenericAsync<TipoConsultaType, TipoConsulta>();
            FieldGenericAsync<TipoContactoType, TipoContacto>();
            FieldGenericAsync<TipoContagemType, TipoContagem>();
            FieldGenericAsync<TipoContaType, TipoConta>();
            FieldGenericAsync<TipoContratacaoType, TipoContratacao>();
            FieldGenericAsync<TipoContratoEmpresaType, TipoContratoEmpresa>();
            FieldGenericAsync<TipoContratoType, TipoContrato>();
            FieldGenericAsync<TipoCorpoType, TipoCorpo>();
            FieldGenericAsync<TipoCosseguroType, TipoCosseguro>();
            FieldGenericAsync<TipoDanosType, TipoDanos>();
            FieldGenericAsync<TipoDeRecebimentoType, TipoDeRecebimento>();
            FieldGenericAsync<TipoDescontoType, TipoDesconto>();
            FieldGenericAsync<TipoDespesaType, TipoDespesa>();
            FieldGenericAsync<TipoDesvalorizacaoType, TipoDesvalorizacao>();
            FieldGenericAsync<TipoDocumentoIdentificacaoType, TipoDocumentoIdentificacao>();
            FieldGenericAsync<TipoDocumentosType, TipoDocumentos>();
            FieldGenericAsync<TipoEmbalagemType, TipoEmbalagem>();
            FieldGenericAsync<TipoEmbarcacaoType, TipoEmbarcacao>();
            FieldGenericAsync<TipoEmpresaType, TipoEmpresa>();
            FieldGenericAsync<TipoEncargoType, TipoEncargo>();
            FieldGenericAsync<TipoEnderecoType, TipoEndereco>();
            FieldGenericAsync<TipoEntidadePlanoType, TipoEntidadePlano>();
            FieldGenericAsync<TipoEntidadeType, TipoEntidade>();
            FieldGenericAsync<TipoEstabelecimentoComercioType, TipoEstabelecimentoComercio>();
            FieldGenericAsync<TipoExclusaoType, TipoExclusao>();
            FieldGenericAsync<TipoFacturacaoPlanoProdutoType, TipoFacturacaoPlanoProduto>();
            FieldGenericAsync<TipoFacturacaoType, TipoFacturacao>();
            FieldGenericAsync<TipoFacturamentoType, TipoFacturamento>();
            FieldGenericAsync<TipoFranquiaType, TipoFranquia>();
            FieldGenericAsync<TipoGaragemType, TipoGaragem>();
            FieldGenericAsync<TipoGrupoType, TipoGrupo>();
            FieldGenericAsync<TipoImagemProdutoType, TipoImagemProduto>();
            FieldGenericAsync<TipoImpostoType, TipoImposto>();
            FieldGenericAsync<TipoIncapacidadeType, TipoIncapacidade>();
            FieldGenericAsync<TipoInfracaoType, TipoInfracao>();
            FieldGenericAsync<TipoInstalacaoElectricaType, TipoInstalacaoElectrica>();
            FieldGenericAsync<TipoInstalacoesType, TipoInstalacoes>();
            FieldGenericAsync<TipoIntervencaoType, TipoIntervencao>();
            FieldGenericAsync<TipoJustificativoCativoType, TipoJustificativoCativo>();
            FieldGenericAsync<TipoLesaoType, TipoLesao>();
            FieldGenericAsync<TipoLevantamentoMedicamentoType, TipoLevantamentoMedicamento>();
            FieldGenericAsync<TipoLimiteResponsabilidadeType, TipoLimiteResponsabilidade>();
            FieldGenericAsync<TipoMargemType, TipoMargem>();
            FieldGenericAsync<TipoMaterialConstrucaoType, TipoMaterialConstrucao>();
            FieldGenericAsync<TipoMatriculaType, TipoMatricula>();
            FieldGenericAsync<TipoMotorType, TipoMotor>();
            FieldGenericAsync<TipoObjectivoComercialType, TipoObjectivoComercial>();
            FieldGenericAsync<TipoObjectivoEstrategicoType, TipoObjectivoEstrategico>();
            FieldGenericAsync<TipoObjectivoProdutoType, TipoObjectivoProduto>();
            FieldGenericAsync<TipoObjectoEnvolvidoType, TipoObjectoEnvolvido>();
            FieldGenericAsync<TipoObrigacoesType, TipoObrigacoes>();
            FieldGenericAsync<TipoOfertaType, TipoOferta>();
            FieldGenericAsync<TipoOperacaoProcessoLimiteCompetenciaType, TipoOperacaoProcessoLimiteCompetencia>();
            FieldGenericAsync<TipoOperacaoProcessoType, TipoOperacaoProcesso>();
            FieldGenericAsync<TipoOperacaoType, TipoOperacao>();
            FieldGenericAsync<TipoOrtesesProtesesType, TipoOrtesesProteses>();
            FieldGenericAsync<TipoOucupantesType, TipoOucupantes>();
            FieldGenericAsync<TipoPagamentoMovimentoType, TipoPagamentoMovimento>();
            FieldGenericAsync<TipoPagamentoType, TipoPagamento>();
            FieldGenericAsync<TipoPartoType, TipoParto>();
            FieldGenericAsync<TipoPerdaType, TipoPerda>();
            FieldGenericAsync<TipoPessoaPlanoType, TipoPessoaPlano>();
            FieldGenericAsync<TipoPessoaType, TipoPessoa>();
            FieldGenericAsync<TipoPinturaType, TipoPintura>();
            FieldGenericAsync<TipoPlanoObjectivoType, TipoPlanoObjectivo>();
            FieldGenericAsync<TipoPortfolioProdutoType, TipoPortfolioProduto>();
            FieldGenericAsync<TipoPremioFixoType, TipoPremioFixo>();
            FieldGenericAsync<TipoProdutorType, TipoProdutor>();
            FieldGenericAsync<TipoPropriedadeType, TipoPropriedade>();
            FieldGenericAsync<TipoProvisaoType, TipoProvisao>();
            FieldGenericAsync<TipoQuadroDanoType, TipoQuadroDano>();
            FieldGenericAsync<TipoQuestionarioType, TipoQuestionario>();
            FieldGenericAsync<TipoRamoSeguroType, TipoRamoSeguro>();
            FieldGenericAsync<TipoRecebimentoMovimentoType, TipoRecebimentoMovimento>();
            FieldGenericAsync<TipoRecebimentoType, TipoRecebimento>();
            FieldGenericAsync<TipoRedeSociaisType, TipoRedeSociais>();
            FieldGenericAsync<TipoRegimeType, TipoRegime>();
            FieldGenericAsync<TipoRelacaoSeguradoType, TipoRelacaoSegurado>();
            FieldGenericAsync<TipoRenovacaoType, TipoRenovacao>();
            FieldGenericAsync<TipoReseguroType, TipoReseguro>();
            FieldGenericAsync<TipoResseguroType, TipoResseguro>();
            FieldGenericAsync<TipoRiscoType, TipoRisco>();
            FieldGenericAsync<TipoSalaEspetaculoType, TipoSalaEspetaculo>();
            FieldGenericAsync<TipoRendimentoType, TipoRendimento>();
            FieldGenericAsync<TipoSanguineoType, TipoSanguineo>();
            FieldGenericAsync<TiposContratosResseguroInformacoesTiposContratosResseguroType, TiposContratosResseguroInformacoesTiposContratosResseguro>();
            FieldGenericAsync<TiposContratosResseguroType, TiposContratosResseguro>();
            FieldGenericAsync<TiposDocumentoProdutoType, TiposDocumentoProduto>();
            FieldGenericAsync<TipoSectorType, TipoSector>();
            FieldGenericAsync<TipoSegmentoComissionamentoType, TipoSegmentoComissionamento>();
            FieldGenericAsync<TipoSegmentoContratoType, TipoSegmentoContrato>();
            FieldGenericAsync<TipoSegmentoPlanoType, TipoSegmentoPlano>();
            FieldGenericAsync<TipoSegmentosComissionamentoType, TipoSegmentosComissionamento>();
            FieldGenericAsync<TipoSegmentoType, TipoSegmento>();
            FieldGenericAsync<TipoSeguroGrupoType, TipoSeguroGrupo>();
            FieldGenericAsync<TipoSeguroType, TipoSeguro>();
            FieldGenericAsync<TipoServicoType, TipoServico>();
            FieldGenericAsync<TipoSinistroType, TipoSinistro>();
            FieldGenericAsync<TipoSociedadeType, TipoSociedade>();
            FieldGenericAsync<TiposType, Tipos>();
            FieldGenericAsync<TipoSubDesembolsoType, TipoSubDesembolso>();
            FieldGenericAsync<TipoSubsidioSalarialType, TipoSubsidioSalarial>();
            FieldGenericAsync<TipoSubTratadoType, TipoSubTratado>();
            FieldGenericAsync<TipoSugestaoType, TipoSugestao>();
            FieldGenericAsync<TipoTarefaReparacaoType, TipoTarefaReparacao>();
            FieldGenericAsync<TipoTarefaType, TipoTarefa>();
            FieldGenericAsync<TipoTarifaPlanoProdutoType, TipoTarifaPlanoProduto>();
            FieldGenericAsync<TipoTarifasResponsabilidadeType, TipoTarifasResponsabilidade>();
            FieldGenericAsync<TipoTarifaType, TipoTarifa>();
            FieldGenericAsync<TipoTaxasType, TipoTaxas>();
            FieldGenericAsync<TipoTerminoType, TipoTermino>();
            FieldGenericAsync<TipoTransferenciaType, TipoTransferencia>();
            FieldGenericAsync<TipoTratadoReseguroType, TipoTratadoReseguro>();
            FieldGenericAsync<TipoUsoType, TipoUso>();
            FieldGenericAsync<TipoViaNotificacaoType, TipoViaNotificacao>();
            FieldGenericAsync<TitularidadeType, Titularidade>();
            FieldGenericAsync<TituloDesvalorizacaoInvalidezPermanenteType, TituloDesvalorizacaoInvalidezPermanente>();
            FieldGenericAsync<TituloType, Titulo>();
            FieldGenericAsync<TomadorType, Tomador>();
            FieldGenericAsync<TransferenciaSeguroType, TransferenciaSeguro>();
            FieldGenericAsync<TransferenciaType, Transferencia>();
            FieldGenericAsync<TransmissaoType, Transmissao>();
            FieldGenericAsync<UnidadeObjectoSeguradoType, UnidadeObjectoSegurado>();
            FieldGenericAsync<UnidadesTempoType, UnidadesTempo>();
            FieldGenericAsync<ValorCativoType, ValorCativo>();
            FieldGenericAsync<ValoresCapitalSeguroFamiliarType, ValoresCapitalSeguroFamiliar>();
            FieldGenericAsync<ValorCoberturaType, ValorCobertura>();
            FieldGenericAsync<ValoresTipoAntenaType, ValoresTipoAntena>();
            FieldGenericAsync<ValorPadraoType, ValorPadrao>();
            FieldGenericAsync<VantagemPlanoType, VantagemPlano>();
            FieldGenericAsync<VantagemProdutoType, VantagemProduto>();
            FieldGenericAsync<VelocidadeType, Velocidade>();
            FieldGenericAsync<ViagemType, Viagem>();
            FieldGenericAsync<ZonaPeriodoCoberturaType, ZonaPeriodoCobertura>();
            FieldGenericAsync<ZonaType, Zona>();
            FieldGenericAsync<GraphicType, GraphicViewModel>();


            #endregion

            #region GraphQL types Personalizados
            // --------------------- GraphQL types personalizadas ---------------------
            FieldAsync<UsuarioType, Usuario>(async (context) =>
            {
                return await repository.ExecuteAsync(async provider =>
               {
                   var userRepo = provider.GetService<IUsuarioRepository>();
                   return await userRepo.GetAllUsuarioAsync();
               });
            });

            FieldAsync<LoginType>("login",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LoginInputType>> { Name = "obj" }),
                 resolve: async context =>
                 {
                     var credenciais = context.GetArgument<LoginViewModel>("obj");

                     return await repository.ExecuteAsync(async provider =>
                    {
                        var userRepo = provider.GetService<IUsuarioRepository>();

                        return context.Resolve(await userRepo.LoginAsync(credenciais));
                    });
                 });

            FieldAsync<PessoaSingularType, Pessoa>(async (context) =>
            {
                return await repository.ExecuteQueryAsync(async ctx =>
               {
                   var pessoas = from pessoa in ctx.Pessoa
                                 join tipo in ctx.TipoPessoa on pessoa.TipoPessoaId equals tipo.IdTipoPessoa
                                 where tipo.CodTipoPessoa == "T000"
                                 select pessoa;

                   var consts = context.GetArgument<string>("consts");
                   var id = context.GetArgument<string>("id");
                   var search = context.GetArgument<bool?>("search");
                   var result = pessoas.ToList().Where(x => id == null ? true : ((search ?? false) ? x.ContainValue(id, consts) : x.HasValue(id, consts))).ToList();

                   return new RepoResponse<IEnumerable<Pessoa>> { Data = await Task.FromResult(result) };
               });
            });

            FieldAsync<PessoaColectivaType, Pessoa>(async (context) =>
            {
                return await repository.ExecuteQueryAsync(async ctx =>
               {
                   var pessoas = from pessoa in ctx.Pessoa
                                 join tipo in ctx.TipoPessoa on pessoa.TipoPessoaId equals tipo.IdTipoPessoa
                                 where tipo.CodTipoPessoa == "T001"
                                 select pessoa;

                   var consts = context.GetArgument<string>("consts");
                   var id = context.GetArgument<string>("id");
                   var search = context.GetArgument<bool?>("search");
                   var result = pessoas.ToList().Where(x => id == null ? true : ((search ?? false) ? x.ContainValue(id, consts) : x.HasValue(id, consts))).ToList();

                   return new RepoResponse<IEnumerable<Pessoa>> { Data = await Task.FromResult(result) };
               });
            });

            FieldAsync<ListGraphType<PessoaType>>("allProdutor",
                 arguments: new QueryArguments(
                        Arg<StringGraphType>("consts"),
                        Arg<StringGraphType>("id"),
                        Arg<BooleanGraphType>("search")),
                 resolve: async context =>
                 {
                     var id = context.GetArgument<string>("id");
                     var consts = context.GetArgument<string>("consts");

                     var result = await repository.ExecuteQueryAsync(async linqDb =>
                     {
                         var pessoas = from pessoa in linqDb.Pessoa
                                       join papel in linqDb.PapelPessoa
                                       on pessoa.IdPessoa equals papel.PessoaId
                                       join p in linqDb.Papel
                                       on papel.PapelId equals p.IdPapel
                                       where p.IsProdutor == true
                                       select pessoa;

                         return await Task.FromResult(pessoas.ToList());
                     });

                     return context.Resolve(new RepoResponse<IEnumerable<Pessoa>> { Data = await Task.FromResult(result) });
                 });

            FieldAsync<ListGraphType<RuaType>>("allLocal",
                 arguments: new QueryArguments(
                        Arg<StringGraphType>("consts"),
                        Arg<StringGraphType>("id")),
                 resolve: async context =>
                 {
                     var id = context.GetArgument<string>("id");
                     var consts = context.GetArgument<string>("consts");
                     var result = await repository.ExecuteQueryAsync(async linqDb =>
                    {
                        var ruas = from rua in linqDb.Rua
                                   join Bairro in linqDb.Bairro
                                    on rua.BairroId equals Bairro.IdBairro
                                   join Distrito in linqDb.Distrito
                                    on Bairro.DistritoId equals Distrito.IdDistrito
                                                                    join Municipio in linqDb.Municipio
                                    on Distrito.MunicipioId equals Municipio.IdMunicipio
                                                                    join Provincia in linqDb.Provincia
                                    on Municipio.ProvinciaId equals Provincia.IdProvincia
                                                                    join Pais in linqDb.Pais
                                    on Provincia.PaisId equals Pais.IdPais
                                                                    join Continente in linqDb.Continente
                                    on Pais.ContinenteId equals Continente.IdContinente
                                   select rua;
                        return await Task.FromResult(ruas.ToList());
                    });
                     return context.Resolve(new RepoResponse<IEnumerable<Rua>> { Data = await Task.FromResult(result) });

                 });

            FieldAsync<ListGraphType<SinistroGraphicoType>>("getsinistro",
            arguments: new QueryArguments(
                   Arg<StringGraphType>("consts"),
                   Arg<StringGraphType>("id")),
            resolve: async context =>
            {
                var id = context.GetArgument<string>("id");
                var consts = context.GetArgument<string>("consts");

                using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
                {
                    var sqlQuery = $"select COUNT(*) as QtdSinistro,LinhaProduto.Designacao as Produto from Sinistro,Pessoa,LinhaProduto,PlanoProduto where Sinistro.ParticipanteSinistroID=Pessoa.IdPessoa and Sinistro.PlanoProdutoId=PlanoProduto.IdPlano and PlanoProduto.LinhaProdutoID=LinhaProduto.IdLinhaProduto Group by LinhaProduto.Designacao";
                    var sinistrs = con.Query<Sinistrographico>(sqlQuery);
                    return context.Resolve(new RepoResponse<IEnumerable<Sinistrographico>> { Data = await Task.FromResult(sinistrs) });
                };
            });

            Field<StringGraphType>(
                "getfile",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "url" }),
                resolve: context =>
                {
                    var url = context.GetArgument<String>("url");
                    FileSystemManager Read = new FileSystemManager();
                    return Read.GetAllFtpFiles(url);
                });

            FieldAsync<ListGraphType<SinistroProvincia1Type>>("sinistroprovincialo",
                arguments: new QueryArguments(
                Arg<StringGraphType>("consts"),
                Arg<BooleanGraphType>("id")),
                   resolve: async context =>
                {
                    var id = context.GetArgument<bool>("id");
                    var consts = context.GetArgument<string>("consts");

                    using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
                    {
                        // var isPago =id ? 1 : 0;
                        var sqlQuery = $"select*from vwProvincia1";
                        var sinistrs = con.Query<Sinistrographico>(sqlQuery);
                        return context.Resolve(new RepoResponse<IEnumerable<Sinistrographico>> { Data = await Task.FromResult(sinistrs) });
                    };

                });

            FieldAsync<ListGraphType<SinistroPaisType>>("sinistroPais",
                arguments: new QueryArguments(
                Arg<StringGraphType>("consts"),
                Arg<StringGraphType>("id")),
                   resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");
                    var consts = context.GetArgument<string>("consts");

                    using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
                    {
                        var sqlQuery = $"select*from vwPais";
                        var sinistrs = con.Query<Sinistrographico>(sqlQuery);
                        return context.Resolve(new RepoResponse<IEnumerable<Sinistrographico>> { Data = await Task.FromResult(sinistrs) });
                    };

                });
            FieldAsync<ListGraphType<SinistroProvinciaType>>("sinistroProvincia",
                arguments: new QueryArguments(
                Arg<StringGraphType>("consts"),
                Arg<StringGraphType>("id")),
                    resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");
                    var consts = context.GetArgument<string>("consts");

                    using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
                    {
                        var sqlQuery = $"select*from vwProvincia";
                        var sinistrs = con.Query<Sinistrographico>(sqlQuery);
                        return context.Resolve(new RepoResponse<IEnumerable<Sinistrographico>> { Data = await Task.FromResult(sinistrs) });
                    };

                });
            FieldAsync<ListGraphType<SinistroMunicipioType>>("sinistroMunicipio",
                arguments: new QueryArguments(
                Arg<StringGraphType>("consts"),
                Arg<StringGraphType>("id")),
                    resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");
                    var consts = context.GetArgument<string>("consts");

                    using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
                    {
                        var sqlQuery = $"select*from vwMunicipio";
                        var sinistrs = con.Query<Sinistrographico>(sqlQuery);
                        return context.Resolve(new RepoResponse<IEnumerable<Sinistrographico>> { Data = await Task.FromResult(sinistrs) });
                    };

                });

            FieldAsync<ListGraphType<SinistroContinenteType>>("sinistroContinente",
                arguments: new QueryArguments(
                Arg<StringGraphType>("consts"),
                Arg<StringGraphType>("id")),
                    resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");
                    var consts = context.GetArgument<string>("consts");

                    using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
                    {
                        var sqlQuery = $"select*from vwContinente";
                        var sinistrs = con.Query<Sinistrographico>(sqlQuery);
                        return context.Resolve(new RepoResponse<IEnumerable<Sinistrographico>> { Data = await Task.FromResult(sinistrs) });
                    };

                });
            FieldAsync<ListGraphType<SinistroGraphicoType>>("sinistroPessoa",
               arguments: new QueryArguments(
               Arg<StringGraphType>("consts"),
               Arg<StringGraphType>("id")),
               resolve: async context =>
               {
                   var id = context.GetArgument<string>("id");
                   var consts = context.GetArgument<string>("consts");

                   using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
                   {
                       var sqlQuery = $"select COUNT(*) as QtdSinistro,LinhaProduto.Designacao as Produto  from Sinistro,Pessoa,LinhaProduto,PlanoProduto where Sinistro.ParticipanteSinistroID=Pessoa.IdPessoa and Sinistro.PlanoProdutoId=PlanoProduto.IdPlano and PlanoProduto.LinhaProdutoID=LinhaProduto.IdLinhaProduto and Pessoa.IdPessoa='{id}' group by LinhaProduto.Designacao";
                       var sinistrs = con.Query<Sinistrographico>(sqlQuery);
                       return context.Resolve(new RepoResponse<IEnumerable<Sinistrographico>> { Data = await Task.FromResult(sinistrs) });
                   };
               });

            //    FieldAsync<ListGraphType<SinistroGraphicoType>>("sinistroPessoa",
            //     arguments: new QueryArguments(
            //     Arg<StringGraphType>("tabela"),
            //     Arg<StringGraphType>("retorn   "),

            //     Arg<StringGraphType>("condicao")),
            //     resolve: async context =>
            // {
            //     var id = context.GetArgument<string>("id");
            //     var consts = context.GetArgument<string>("consts");

            //     using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
            //     {
            //         var sqlQuery = $"select COUNT(*) as QtdSinistro,LinhaProduto.Designacao as Produto  from Sinistro,Pessoa,LinhaProduto,PlanoProduto where Sinistro.ParticipanteSinistroID=Pessoa.IdPessoa and Sinistro.PlanoProdutoId=PlanoProduto.IdPlano and PlanoProduto.LinhaProdutoID=LinhaProduto.IdLinhaProduto and Pessoa.IdPessoa='{id}'";
            //         var sinistrs = con.Query<Sinistrographico>(sqlQuery);
            //         return context.Resolve(new RepoResponse<IEnumerable<Sinistrographico>> { Data = await Task.FromResult(sinistrs) });
            //     };
            //  });
            // Conversao de Cambio
            FieldAsync<CambioModelType>("calculoCambio",
                 arguments: new QueryArguments(Arg<NonNullGraphType<CambioModelInputType>>("obj")),
                 resolve: async context =>
                 {
                     var result = await repository.ExecuteAsync(async provider =>
                     {
                         return await Task.FromResult(new ConversaoMoedas(provider.GetService<DapperContext>()));
                     });

                     return result.Calcular(context.GetArgument<CambioModel>("obj"));
                 });

            // Calculo para cotação.
            FieldAsync<CalculoModelType>("calculoCotacao",
                 arguments: new QueryArguments(Arg<NonNullGraphType<CotacaoInputType>>("obj"), Arg<BooleanGraphType>("analise")),
                 resolve: async context =>
                 {
                     var result = await repository.ExecuteAsync(async provider => await Task.FromResult(new Calculos(provider.GetService<DapperContext>(), provider.GetService<IRepository>())));

                     return result.CalculoGeral(new CalculoModel { Cotacao = context.GetArgument<Cotacao>("obj") });
                 });

            

            // Calculo da simulação para proposta de seguro.
            FieldAsync<CalculoModelType>("calculoSimulacao",
                 arguments: new QueryArguments(Arg<NonNullGraphType<SimulacaoInputType>>("obj"), Arg<BooleanGraphType>("analise")),
                 resolve: async context =>
                 {
                     var result = await repository.ExecuteAsync(async provider => await Task.FromResult(new Calculos(provider.GetService<DapperContext>(), provider.GetService<IRepository>())));

                     return result.CalculoSimulacao(new CalculoModel { Simulacao = context.GetArgument<Simulacao>("obj") });
                 });

            Field<DataHoraType>("dataHora", resolve: (context) =>
            {
                return new DataHora
                {
                    Data = DateTime.Now.ToShortDateString().ToString(),
                    Hora = DateTime.Now.ToShortTimeString().ToString()
                };
            });

            FieldAsync<ListGraphType<MoedaType>>("allMoedasActivas",
                 arguments: new QueryArguments(
                        Arg<StringGraphType>("consts"),
                        Arg<StringGraphType>("id")),
                 resolve: async context =>
                 {
                     var id = context.GetArgument<string>("id");
                     var consts = context.GetArgument<string>("consts");

                     // Pegando os estados da base de dados
                     var estado = await Repo.GetAsync<Estado>("E002", nameof(Estado.CodEstado));

                     if (estado == null) return null;

                     // Pegando as moedas ativas
                     var moedas = context.Resolve(await Repo.GetAsync<Moeda>(l => l.Where(x => x.EstadoId == estado.IdEstado && (id == null ? true : l.HasValue(id, consts)))));

                     return moedas.ToList();
                 });
            #endregion
        }
    }
}