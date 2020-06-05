using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class VantagemPlanoType : ObjectGraphType<VantagemPlano>
    {
        public VantagemPlanoType()
        {
            // Defining the name of the object
            Name = "vantagemPlano";

            Field(x => x.IdVantagemPlano, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodVantagemPlano, nullable: true);
            Field(x => x.Descricao, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class VantagemPlanoInputType : InputObjectGraphType
	{
		public VantagemPlanoInputType()
		{
			// Defining the name of the object
			Name = "vantagemPlanoInput";
			
            //Field<StringGraphType>("idVantagemPlano");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codVantagemPlano");
			Field<StringGraphType>("descricao");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}