using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoRecebimentoType : ObjectGraphType<TipoRecebimento>
    {
        public TipoRecebimentoType()
        {
            // Defining the name of the object
            Name = "tipoRecebimento";

            Field(x => x.IdTipoRecebimento, nullable: true);
            Field(x => x.Codigo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AgravamentoType>>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoRecebimento)))));
            FieldAsync<ListGraphType<BonusType>>("bonus", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Bonus>(x => x.Where(e => e.HasValue(c.Source.IdTipoRecebimento)))));
            FieldAsync<ListGraphType<CaixaType>>("caixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Caixa>(x => x.Where(e => e.HasValue(c.Source.IdTipoRecebimento)))));
            FieldAsync<ListGraphType<ComissaoPlanoType>>("comissaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdTipoRecebimento)))));
            FieldAsync<ListGraphType<DespesaType>>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(x => x.Where(e => e.HasValue(c.Source.IdTipoRecebimento)))));
            FieldAsync<ListGraphType<MargemVendaProdutoType>>("margemVendaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MargemVendaProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipoRecebimento)))));
            FieldAsync<ListGraphType<TarifaType>>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(x => x.Where(e => e.HasValue(c.Source.IdTipoRecebimento)))));
            FieldAsync<ListGraphType<TipoRecebimentoMovimentoType>>("tipoRecebimentoMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRecebimentoMovimento>(x => x.Where(e => e.HasValue(c.Source.IdTipoRecebimento)))));
            
        }
    }

    public class TipoRecebimentoInputType : InputObjectGraphType
	{
		public TipoRecebimentoInputType()
		{
			// Defining the name of the object
			Name = "tipoRecebimentoInput";
			
            //Field<StringGraphType>("idTipoRecebimento");
			Field<StringGraphType>("codigo");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AgravamentoInputType>>("agravamento");
			Field<ListGraphType<BonusInputType>>("bonus");
			Field<ListGraphType<CaixaInputType>>("caixa");
			Field<ListGraphType<ComissaoPlanoInputType>>("comissaoPlano");
			Field<ListGraphType<DespesaInputType>>("despesa");
			Field<ListGraphType<MargemVendaProdutoInputType>>("margemVendaProduto");
			Field<ListGraphType<TarifaInputType>>("tarifa");
			Field<ListGraphType<TipoRecebimentoMovimentoInputType>>("tipoRecebimentoMovimento");
			
		}
	}
}