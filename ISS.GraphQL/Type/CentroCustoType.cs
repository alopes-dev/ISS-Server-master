using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CentroCustoType : ObjectGraphType<CentroCusto>
    {
        public CentroCustoType()
        {
            // Defining the name of the object
            Name = "centroCusto";

            Field(x => x.IdCentroCusto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.DepartamentoId, nullable: true);
            Field(x => x.SeccaoId, nullable: true);
            Field(x => x.SectorId, nullable: true);
            Field(x => x.AreaId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodCentroCusto, nullable: true);
            FieldAsync<AreaType>("area", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Area>(c.Source.AreaId)));
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SeccaoType>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(c.Source.SeccaoId)));
            FieldAsync<SectorType>("sector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sector>(c.Source.SectorId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<AgravamentoType>>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(x => x.Where(e => e.HasValue(c.Source.IdCentroCusto)))));
            FieldAsync<ListGraphType<ApoliceType>>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(x => x.Where(e => e.HasValue(c.Source.IdCentroCusto)))));
            FieldAsync<ListGraphType<BonusType>>("bonus", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Bonus>(x => x.Where(e => e.HasValue(c.Source.IdCentroCusto)))));
            FieldAsync<ListGraphType<ComissaoPlanoType>>("comissaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdCentroCusto)))));
            FieldAsync<ListGraphType<ContratoType>>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdCentroCusto)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdCentroCusto)))));
            FieldAsync<ListGraphType<DespesaType>>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(x => x.Where(e => e.HasValue(c.Source.IdCentroCusto)))));
            FieldAsync<ListGraphType<MargemVendaProdutoType>>("margemVendaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MargemVendaProduto>(x => x.Where(e => e.HasValue(c.Source.IdCentroCusto)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdCentroCusto)))));
            FieldAsync<ListGraphType<TarifaType>>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(x => x.Where(e => e.HasValue(c.Source.IdCentroCusto)))));
            
        }
    }

    public class CentroCustoInputType : InputObjectGraphType
	{
		public CentroCustoInputType()
		{
			// Defining the name of the object
			Name = "centroCustoInput";
			
            //Field<StringGraphType>("idCentroCusto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("departamentoId");
			Field<StringGraphType>("seccaoId");
			Field<StringGraphType>("sectorId");
			Field<StringGraphType>("areaId");
			Field<StringGraphType>("subContaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("codCentroCusto");
			Field<AreaInputType>("area");
			Field<DireccaoInputType>("direccao");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<SeccaoInputType>("seccao");
			Field<SectorInputType>("sector");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<AgravamentoInputType>>("agravamento");
			Field<ListGraphType<ApoliceInputType>>("apolice");
			Field<ListGraphType<BonusInputType>>("bonus");
			Field<ListGraphType<ComissaoPlanoInputType>>("comissaoPlano");
			Field<ListGraphType<ContratoInputType>>("contrato");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<DespesaInputType>>("despesa");
			Field<ListGraphType<MargemVendaProdutoInputType>>("margemVendaProduto");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<TarifaInputType>>("tarifa");
			
		}
	}
}