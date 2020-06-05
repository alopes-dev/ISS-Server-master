using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPremioFixoType : ObjectGraphType<TipoPremioFixo>
    {
        public TipoPremioFixoType()
        {
            // Defining the name of the object
            Name = "tipoPremioFixo";

            Field(x => x.IdTipoPremioFixo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoPremioFixo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoPremioFixoInputType : InputObjectGraphType
	{
		public TipoPremioFixoInputType()
		{
			// Defining the name of the object
			Name = "tipoPremioFixoInput";
			
            //Field<StringGraphType>("idTipoPremioFixo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoPremioFixo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}