using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoUsoType : ObjectGraphType<TipoUso>
    {
        public TipoUsoType()
        {
            // Defining the name of the object
            Name = "tipoUso";

            Field(x => x.IdTipoUso, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoUso, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdTipoUso)))));
            
        }
    }

    public class TipoUsoInputType : InputObjectGraphType
	{
		public TipoUsoInputType()
		{
			// Defining the name of the object
			Name = "tipoUsoInput";
			
            //Field<StringGraphType>("idTipoUso");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoUso");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			
		}
	}
}