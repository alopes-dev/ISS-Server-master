using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GarantiaPlanoType : ObjectGraphType<GarantiaPlano>
    {
        public GarantiaPlanoType()
        {
            // Defining the name of the object
            Name = "garantiaPlano";

            Field(x => x.IdGarantiaPlano, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.CodGarantiaPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Indeminizacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Maximo, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class GarantiaPlanoInputType : InputObjectGraphType
	{
		public GarantiaPlanoInputType()
		{
			// Defining the name of the object
			Name = "garantiaPlanoInput";
			
            //Field<StringGraphType>("idGarantiaPlano");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("codGarantiaPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("indeminizacao");
			Field<StringGraphType>("maximo");
			Field<StringGraphType>("linhaProdutoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}