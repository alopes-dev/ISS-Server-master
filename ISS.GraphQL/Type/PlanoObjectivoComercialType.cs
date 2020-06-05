using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PlanoObjectivoComercialType : ObjectGraphType<PlanoObjectivoComercial>
    {
        public PlanoObjectivoComercialType()
        {
            // Defining the name of the object
            Name = "planoObjectivoComercial";

            Field(x => x.IdPlanoObjectivoComercial, nullable: true);
            Field(x => x.CodHierarquia, nullable: true);
            Field(x => x.ValorPlaneado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorProposto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Quantidade, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DataPlanoInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataPlanoFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Ano, nullable: true, type: typeof(IntGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoObjectivoPlanoId, nullable: true);
            Field(x => x.PlanoObjectivoComercialId, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.PrecoMedio, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<PlanoObjectivoComercialType>("planoObjectivoComercialNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoObjectivoComercial>(c.Source.PlanoObjectivoComercialId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoObjectivoEstrategicoType>("tipoObjectivoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoObjectivoEstrategico>(c.Source.TipoObjectivoPlanoId)));
            FieldAsync<ListGraphType<BalcaoPlanoType>>("balcaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BalcaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdPlanoObjectivoComercial)))));
            FieldAsync<ListGraphType<PlanoObjectivoComercialType>>("inversePlanoObjectivoComercialNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoObjectivoComercial>(x => x.Where(e => e.HasValue(c.Source.IdPlanoObjectivoComercial)))));
            
        }
    }

    public class PlanoObjectivoComercialInputType : InputObjectGraphType
	{
		public PlanoObjectivoComercialInputType()
		{
			// Defining the name of the object
			Name = "planoObjectivoComercialInput";
			
            //Field<StringGraphType>("idPlanoObjectivoComercial");
			Field<StringGraphType>("codHierarquia");
			Field<FloatGraphType>("valorPlaneado");
			Field<FloatGraphType>("valorProposto");
			Field<IntGraphType>("quantidade");
			Field<DateTimeGraphType>("dataPlanoInicio");
			Field<DateTimeGraphType>("dataPlanoFim");
			Field<IntGraphType>("ano");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoObjectivoPlanoId");
			Field<StringGraphType>("planoObjectivoComercialId");
			Field<FloatGraphType>("taxa");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("planoProdutoId");
			Field<FloatGraphType>("precoMedio");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<PlanoObjectivoComercialInputType>("planoObjectivoComercialNavigation");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoObjectivoEstrategicoInputType>("tipoObjectivoPlano");
			Field<ListGraphType<BalcaoPlanoInputType>>("balcaoPlano");
			Field<ListGraphType<PlanoObjectivoComercialInputType>>("inversePlanoObjectivoComercialNavigation");
			
		}
	}
}