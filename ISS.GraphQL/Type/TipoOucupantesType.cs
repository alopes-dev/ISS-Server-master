using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoOucupantesType : ObjectGraphType<TipoOucupantes>
    {
        public TipoOucupantesType()
        {
            // Defining the name of the object
            Name = "tipoOucupantes";

            Field(x => x.IdTipoOucupante, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoOucupante, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CaracteristicaAtutomovelType>>("caracteristicaAtutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicaAtutomovel>(x => x.Where(e => e.HasValue(c.Source.IdTipoOucupante)))));
            
        }
    }

    public class TipoOucupantesInputType : InputObjectGraphType
	{
		public TipoOucupantesInputType()
		{
			// Defining the name of the object
			Name = "tipoOucupantesInput";
			
            //Field<StringGraphType>("idTipoOucupante");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoOucupante");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CaracteristicaAtutomovelInputType>>("caracteristicaAtutomovel");
			
		}
	}
}