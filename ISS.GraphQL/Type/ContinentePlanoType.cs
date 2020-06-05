using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContinentePlanoType : ObjectGraphType<ContinentePlano>
    {
        public ContinentePlanoType()
        {
            // Defining the name of the object
            Name = "continentePlano";

            Field(x => x.IdContinentePlano, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.ContinenteId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<ContinenteType>("continente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Continente>(c.Source.ContinenteId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class ContinentePlanoInputType : InputObjectGraphType
	{
		public ContinentePlanoInputType()
		{
			// Defining the name of the object
			Name = "continentePlanoInput";
			
            //Field<StringGraphType>("idContinentePlano");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("continenteId");
			Field<StringGraphType>("planoProdutoId");
			Field<ContinenteInputType>("continente");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}