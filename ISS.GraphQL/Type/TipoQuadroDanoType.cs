using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoQuadroDanoType : ObjectGraphType<TipoQuadroDano>
    {
        public TipoQuadroDanoType()
        {
            // Defining the name of the object
            Name = "tipoQuadroDano";

            Field(x => x.IdTipoQuadroDano, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoQuadroDano, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.Obs, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<QuadroDanosType>>("quadroDanos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<QuadroDanos>(x => x.Where(e => e.HasValue(c.Source.IdTipoQuadroDano)))));
            
        }
    }

    public class TipoQuadroDanoInputType : InputObjectGraphType
	{
		public TipoQuadroDanoInputType()
		{
			// Defining the name of the object
			Name = "tipoQuadroDanoInput";
			
            //Field<StringGraphType>("idTipoQuadroDano");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoQuadroDano");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("obs");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<QuadroDanosInputType>>("quadroDanos");
			
		}
	}
}