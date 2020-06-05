using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DetalhePlanoType : ObjectGraphType<DetalhePlano>
    {
        public DetalhePlanoType()
        {
            // Defining the name of the object
            Name = "detalhePlano";

            Field(x => x.IdDetalhePlano, nullable: true);
            Field(x => x.Titulo, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DetalhePlanoInputType : InputObjectGraphType
	{
		public DetalhePlanoInputType()
		{
			// Defining the name of the object
			Name = "detalhePlanoInput";
			
            //Field<StringGraphType>("idDetalhePlano");
			Field<StringGraphType>("titulo");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}