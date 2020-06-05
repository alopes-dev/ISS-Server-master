using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoObjectoEnvolvidoType : ObjectGraphType<TipoObjectoEnvolvido>
    {
        public TipoObjectoEnvolvidoType()
        {
            // Defining the name of the object
            Name = "tipoObjectoEnvolvido";

            Field(x => x.IdTipoObjectoEnvolvido, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoObjectoEnvolvido, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ObjectoEnvolvidoType>>("objectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoEnvolvido>(x => x.Where(e => e.HasValue(c.Source.IdTipoObjectoEnvolvido)))));
            
        }
    }

    public class TipoObjectoEnvolvidoInputType : InputObjectGraphType
	{
		public TipoObjectoEnvolvidoInputType()
		{
			// Defining the name of the object
			Name = "tipoObjectoEnvolvidoInput";
			
            //Field<StringGraphType>("idTipoObjectoEnvolvido");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoObjectoEnvolvido");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ObjectoEnvolvidoInputType>>("objectoEnvolvido");
			
		}
	}
}