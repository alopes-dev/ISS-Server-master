using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoResseguroType : ObjectGraphType<TipoResseguro>
    {
        public TipoResseguroType()
        {
            // Defining the name of the object
            Name = "tipoResseguro";

            Field(x => x.IdTipoResseguro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoResseguro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ClassificacaoContratoResseguroType>>("classificacaoContratoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoContratoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdTipoResseguro)))));
            FieldAsync<ListGraphType<FormaResseguroType>>("formaResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaResseguro>(x => x.Where(e => e.HasValue(c.Source.IdTipoResseguro)))));
            
        }
    }

    public class TipoResseguroInputType : InputObjectGraphType
	{
		public TipoResseguroInputType()
		{
			// Defining the name of the object
			Name = "tipoResseguroInput";
			
            //Field<StringGraphType>("idTipoResseguro");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoResseguro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ClassificacaoContratoResseguroInputType>>("classificacaoContratoResseguro");
			Field<ListGraphType<FormaResseguroInputType>>("formaResseguro");
			
		}
	}
}