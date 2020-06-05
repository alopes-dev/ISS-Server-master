using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoContaType : ObjectGraphType<TipoConta>
    {
        public TipoContaType()
        {
            // Defining the name of the object
            Name = "tipoConta";

            Field(x => x.IdTipoConta, nullable: true);
            Field(x => x.CodTipoConta, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhProdutoId, nullable: true);
            Field(x => x.PapelId, nullable: true);
            Field(x => x.SubTipoContaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhProdutoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<SubTipoContaType>("subTipoContaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTipoConta>(c.Source.SubTipoContaId)));
            FieldAsync<ListGraphType<ClienteType>>("cliente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cliente>(x => x.Where(e => e.HasValue(c.Source.IdTipoConta)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdTipoConta)))));
            FieldAsync<ListGraphType<DescontoTipoContaType>>("descontoTipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoTipoConta>(x => x.Where(e => e.HasValue(c.Source.IdTipoConta)))));
            FieldAsync<ListGraphType<DespesasTipoContaType>>("despesasTipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DespesasTipoConta>(x => x.Where(e => e.HasValue(c.Source.IdTipoConta)))));
            FieldAsync<ListGraphType<EncargosTipoContaType>>("encargosTipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EncargosTipoConta>(x => x.Where(e => e.HasValue(c.Source.IdTipoConta)))));
            FieldAsync<ListGraphType<ImpostoTipoContaType>>("impostoTipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ImpostoTipoConta>(x => x.Where(e => e.HasValue(c.Source.IdTipoConta)))));
            FieldAsync<ListGraphType<SubTipoContaType>>("subTipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTipoConta>(x => x.Where(e => e.HasValue(c.Source.IdTipoConta)))));
            FieldAsync<ListGraphType<ValorCativoType>>("valorCativo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValorCativo>(x => x.Where(e => e.HasValue(c.Source.IdTipoConta)))));
            
        }
    }

    public class TipoContaInputType : InputObjectGraphType
	{
		public TipoContaInputType()
		{
			// Defining the name of the object
			Name = "tipoContaInput";
			
            //Field<StringGraphType>("idTipoConta");
			Field<StringGraphType>("codTipoConta");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("linhProdutoId");
			Field<StringGraphType>("papelId");
			Field<StringGraphType>("subTipoContaId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhProduto");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PapelInputType>("papel");
			Field<PlanoContasInputType>("subConta");
			Field<SubTipoContaInputType>("subTipoContaNavigation");
			Field<ListGraphType<ClienteInputType>>("cliente");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceira");
			Field<ListGraphType<DescontoTipoContaInputType>>("descontoTipoConta");
			Field<ListGraphType<DespesasTipoContaInputType>>("despesasTipoConta");
			Field<ListGraphType<EncargosTipoContaInputType>>("encargosTipoConta");
			Field<ListGraphType<ImpostoTipoContaInputType>>("impostoTipoConta");
			Field<ListGraphType<SubTipoContaInputType>>("subTipoConta");
			Field<ListGraphType<ValorCativoInputType>>("valorCativo");
			
		}
	}
}