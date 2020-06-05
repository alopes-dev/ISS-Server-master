using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AutoridadeSupervisaoType : ObjectGraphType<AutoridadeSupervisao>
    {
        public AutoridadeSupervisaoType()
        {
            // Defining the name of the object
            Name = "autoridadeSupervisao";

            Field(x => x.IdAutoridadeSupervisao, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CaeType>>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(x => x.Where(e => e.HasValue(c.Source.IdAutoridadeSupervisao)))));
            
        }
    }

    public class AutoridadeSupervisaoInputType : InputObjectGraphType
	{
		public AutoridadeSupervisaoInputType()
		{
			// Defining the name of the object
			Name = "autoridadeSupervisaoInput";
			
            //Field<StringGraphType>("idAutoridadeSupervisao");
			Field<StringGraphType>("nome");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CaeInputType>>("cae");
			
		}
	}
}