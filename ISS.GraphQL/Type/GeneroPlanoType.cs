using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GeneroPlanoType : ObjectGraphType<GeneroPlano>
    {
        public GeneroPlanoType()
        {
            // Defining the name of the object
            Name = "generoPlano";

            Field(x => x.IdGeneroPlano, nullable: true);
            Field(x => x.GeneroId, nullable: true);
            Field(x => x.CodGeneroPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<SexoType>("genero", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sexo>(c.Source.GeneroId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class GeneroPlanoInputType : InputObjectGraphType
	{
		public GeneroPlanoInputType()
		{
			// Defining the name of the object
			Name = "generoPlanoInput";
			
            //Field<StringGraphType>("idGeneroPlano");
			Field<StringGraphType>("generoId");
			Field<StringGraphType>("codGeneroPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<SexoInputType>("genero");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}