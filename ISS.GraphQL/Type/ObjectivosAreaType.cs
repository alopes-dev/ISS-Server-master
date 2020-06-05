using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ObjectivosAreaType : ObjectGraphType<ObjectivosArea>
    {
        public ObjectivosAreaType()
        {
            // Defining the name of the object
            Name = "objectivosArea";

            Field(x => x.IdObjectivosArea, nullable: true);
            Field(x => x.NumObjectivo, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.AreaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<AreaType>("area", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Area>(c.Source.AreaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ObjectivosAreaInputType : InputObjectGraphType
	{
		public ObjectivosAreaInputType()
		{
			// Defining the name of the object
			Name = "objectivosAreaInput";
			
            //Field<StringGraphType>("idObjectivosArea");
			Field<IntGraphType>("numObjectivo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("areaId");
			Field<StringGraphType>("estadoId");
			Field<AreaInputType>("area");
			Field<EstadoInputType>("estado");
			
		}
	}
}