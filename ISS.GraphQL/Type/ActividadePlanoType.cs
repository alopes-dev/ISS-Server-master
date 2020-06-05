using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ActividadePlanoType : ObjectGraphType<ActividadePlano>
    {
        public ActividadePlanoType()
        {
            // Defining the name of the object
            Name = "actividadePlano";

            Field(x => x.IdActividadePlano, nullable: true);
            Field(x => x.ActividadeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<ActividadeType>("actividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Actividade>(c.Source.ActividadeId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class ActividadePlanoInputType : InputObjectGraphType
	{
		public ActividadePlanoInputType()
		{
			// Defining the name of the object
			Name = "actividadePlanoInput";
			
            //Field<StringGraphType>("idActividadePlano");
			Field<StringGraphType>("actividadeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("planoProdutoId");
			Field<ActividadeInputType>("actividade");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}