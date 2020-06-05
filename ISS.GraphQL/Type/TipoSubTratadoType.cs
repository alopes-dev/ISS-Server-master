using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSubTratadoType : ObjectGraphType<TipoSubTratado>
    {
        public TipoSubTratadoType()
        {
            // Defining the name of the object
            Name = "tipoSubTratado";

            Field(x => x.IdTipoSubTratado, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoResseguroId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodTipoSubTratado, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ExcessoPerdaType>>("excessoPerda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExcessoPerda>(x => x.Where(e => e.HasValue(c.Source.IdTipoSubTratado)))));
            
        }
    }

    public class TipoSubTratadoInputType : InputObjectGraphType
	{
		public TipoSubTratadoInputType()
		{
			// Defining the name of the object
			Name = "tipoSubTratadoInput";
			
            //Field<StringGraphType>("idTipoSubTratado");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoResseguroId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codTipoSubTratado");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ExcessoPerdaInputType>>("excessoPerda");
			
		}
	}
}