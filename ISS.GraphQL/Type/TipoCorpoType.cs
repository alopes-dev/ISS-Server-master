using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCorpoType : ObjectGraphType<TipoCorpo>
    {
        public TipoCorpoType()
        {
            // Defining the name of the object
            Name = "tipoCorpo";

            Field(x => x.IdTipoCorpo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdTipoCorpo)))));
            
        }
    }

    public class TipoCorpoInputType : InputObjectGraphType
	{
		public TipoCorpoInputType()
		{
			// Defining the name of the object
			Name = "tipoCorpoInput";
			
            //Field<StringGraphType>("idTipoCorpo");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			
		}
	}
}