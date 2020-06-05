using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PlanoContasType : ObjectGraphType<PlanoContas>
    {
        public PlanoContasType()
        {
            // Defining the name of the object
            Name = "planoContas";

            Field(x => x.IdSubClasse, nullable: true);
            Field(x => x.NumSubClasse, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.SubClasseContaId, nullable: true);
            Field(x => x.ClasseId, nullable: true);
            Field(x => x.ClassificacaoContaId, nullable: true);
            Field(x => x.TipoClasseContaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Grau, nullable: true, type: typeof(IntGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Saldo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorDebitoAnterior, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorCreditoAnterior, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SaldoAnterior, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ConceitoConta, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Conta, nullable: true);
            Field(x => x.Risco, nullable: true);
            Field(x => x.Auxiliar, nullable: true);
            Field(x => x.CodPlanoContas, nullable: true);
            FieldAsync<ClasseContaType>("classe", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClasseConta>(c.Source.ClasseId)));
            FieldAsync<ClassificacaoContaType>("classificacaoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoConta>(c.Source.ClassificacaoContaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoContasType>("subClasseConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubClasseContaId)));
            FieldAsync<TipoClasseContaType>("tipoClasseConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoClasseConta>(c.Source.TipoClasseContaId)));
            FieldAsync<ListGraphType<AreaType>>("area", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Area>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<CanalType>>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<CentroCustoType>>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<CentroResponsabilidadeType>>("centroResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<ClassificacaoCaixaType>>("classificacaoCaixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoCaixa>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<ClienteType>>("cliente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cliente>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<CoberturaType>>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<ComiteType>>("comite", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comite>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<DepartamentoType>>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<DireccaoType>>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<PlanoContasType>>("inverseSubClasseConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<LinhaProdutoType>>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<MapaType>>("mapa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Mapa>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<MoedaType>>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<OperacaoType>>("operacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Operacao>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<OperacoesPagamentoType>>("operacoesPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesPagamento>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<PapelType>>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<PerdaType>>("perda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perda>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<PlanoComissionamentoProdutorType>>("planoComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<PlanoProdutoType>>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<PortfolioProdutoType>>("portfolioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PortfolioProduto>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<PremiosType>>("premios", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Premios>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<ProdutoType>>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<SeccaoType>>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<SectorType>>("sector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sector>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<SegmentoProdutoType>>("segmentoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoProduto>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<TarifaType>>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<TarifasAutomovelType>>("tarifasAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<TarifasDanosPropriosType>>("tarifasDanosProprios", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasDanosProprios>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<TarifasPremioAutoAcidentesTrabalhoType>>("tarifasPremioAutoAcidentesTrabalho", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasPremioAutoAcidentesTrabalho>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<TarifasPremioAutoAt2Type>>("tarifasPremioAutoAt2", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasPremioAutoAt2>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<TarifasResponsabilidadeCivilType>>("tarifasResponsabilidadeCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasResponsabilidadeCivil>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<TipoComissaoType>>("tipoComissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoComissao>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<TipoContaType>>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<TipoOperacaoType>>("tipoOperacaoSubContaCredito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            FieldAsync<ListGraphType<TipoOperacaoType>>("tipoOperacaoSubContaDebito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(x => x.Where(e => e.HasValue(c.Source.IdSubClasse)))));
            
        }
    }

    public class PlanoContasInputType : InputObjectGraphType
	{
		public PlanoContasInputType()
		{
			// Defining the name of the object
			Name = "planoContasInput";
			
            //Field<StringGraphType>("idSubClasse");
			Field<StringGraphType>("numSubClasse");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("subClasseContaId");
			Field<StringGraphType>("classeId");
			Field<StringGraphType>("classificacaoContaId");
			Field<StringGraphType>("tipoClasseContaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<IntGraphType>("grau");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("saldo");
			Field<FloatGraphType>("valorDebitoAnterior");
			Field<FloatGraphType>("valorCreditoAnterior");
			Field<FloatGraphType>("saldoAnterior");
			Field<StringGraphType>("conceitoConta");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("conta");
			Field<StringGraphType>("risco");
			Field<StringGraphType>("auxiliar");
			Field<StringGraphType>("codPlanoContas");
			Field<ClasseContaInputType>("classe");
			Field<ClassificacaoContaInputType>("classificacaoConta");
			Field<EstadoInputType>("estado");
			Field<PlanoContasInputType>("subClasseConta");
			Field<TipoClasseContaInputType>("tipoClasseConta");
			Field<ListGraphType<AreaInputType>>("area");
			Field<ListGraphType<CanalInputType>>("canal");
			Field<ListGraphType<CentroCustoInputType>>("centroCusto");
			Field<ListGraphType<CentroResponsabilidadeInputType>>("centroResponsabilidade");
			Field<ListGraphType<ClassificacaoCaixaInputType>>("classificacaoCaixa");
			Field<ListGraphType<ClienteInputType>>("cliente");
			Field<ListGraphType<CoberturaInputType>>("cobertura");
			Field<ListGraphType<ComiteInputType>>("comite");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceira");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			Field<ListGraphType<DepartamentoInputType>>("departamento");
			Field<ListGraphType<DireccaoInputType>>("direccao");
			Field<ListGraphType<PlanoContasInputType>>("inverseSubClasseConta");
			Field<ListGraphType<LinhaProdutoInputType>>("linhaProduto");
			Field<ListGraphType<MapaInputType>>("mapa");
			Field<ListGraphType<MoedaInputType>>("moeda");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<OperacaoInputType>>("operacao");
			Field<ListGraphType<OperacoesPagamentoInputType>>("operacoesPagamento");
			Field<ListGraphType<PapelInputType>>("papel");
			Field<ListGraphType<PerdaInputType>>("perda");
			Field<ListGraphType<PlanoComissionamentoProdutorInputType>>("planoComissionamentoProdutor");
			Field<ListGraphType<PlanoProdutoInputType>>("planoProduto");
			Field<ListGraphType<PortfolioProdutoInputType>>("portfolioProduto");
			Field<ListGraphType<PremiosInputType>>("premios");
			Field<ListGraphType<ProdutoInputType>>("produto");
			Field<ListGraphType<SeccaoInputType>>("seccao");
			Field<ListGraphType<SectorInputType>>("sector");
			Field<ListGraphType<SegmentoProdutoInputType>>("segmentoProduto");
			Field<ListGraphType<TarifaInputType>>("tarifa");
			Field<ListGraphType<TarifasAutomovelInputType>>("tarifasAutomovel");
			Field<ListGraphType<TarifasDanosPropriosInputType>>("tarifasDanosProprios");
			Field<ListGraphType<TarifasPremioAutoAcidentesTrabalhoInputType>>("tarifasPremioAutoAcidentesTrabalho");
			Field<ListGraphType<TarifasPremioAutoAt2InputType>>("tarifasPremioAutoAt2");
			Field<ListGraphType<TarifasResponsabilidadeCivilInputType>>("tarifasResponsabilidadeCivil");
			Field<ListGraphType<TipoComissaoInputType>>("tipoComissao");
			Field<ListGraphType<TipoContaInputType>>("tipoConta");
			Field<ListGraphType<TipoOperacaoInputType>>("tipoOperacaoSubContaCredito");
			Field<ListGraphType<TipoOperacaoInputType>>("tipoOperacaoSubContaDebito");
			
		}
	}
}