using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoActividadeType : ObjectGraphType<TipoActividade>
    {
        public TipoActividadeType()
        {
            // Defining the name of the object
            Name = "tipoActividade";

            Field(x => x.IdTipoActividade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoActividade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ActividadeType>>("actividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Actividade>(x => x.Where(e => e.HasValue(c.Source.IdTipoActividade)))));
            
        }
    }

    public class TipoActividadeInputType : InputObjectGraphType
	{
		public TipoActividadeInputType()
		{
			// Defining the name of the object
			Name = "tipoActividadeInput";
			
            //Field<StringGraphType>("idTipoActividade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoActividade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ActividadeInputType>>("actividade");
			
		}
	}
}