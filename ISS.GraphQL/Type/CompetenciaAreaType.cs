using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CompetenciaAreaType : ObjectGraphType<CompetenciaArea>
    {
        public CompetenciaAreaType()
        {
            // Defining the name of the object
            Name = "competenciaArea";

            Field(x => x.IdCompetenciaArea, nullable: true);
            Field(x => x.NumCompetencia, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.AreaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<AreaType>("area", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Area>(c.Source.AreaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CompetenciaAreaInputType : InputObjectGraphType
	{
		public CompetenciaAreaInputType()
		{
			// Defining the name of the object
			Name = "competenciaAreaInput";
			
            //Field<StringGraphType>("idCompetenciaArea");
			Field<IntGraphType>("numCompetencia");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("areaId");
			Field<StringGraphType>("estadoId");
			Field<AreaInputType>("area");
			Field<EstadoInputType>("estado");
			
		}
	}
}