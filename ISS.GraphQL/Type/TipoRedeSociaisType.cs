using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoRedeSociaisType : ObjectGraphType<TipoRedeSociais>
    {
        public TipoRedeSociaisType()
        {
            // Defining the name of the object
            Name = "tipoRedeSociais";

            Field(x => x.IdTipoRedeSociais, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoRedeSociais, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.CorId, nullable: true);
            FieldAsync<CorType>("cor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cor>(c.Source.CorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<RedeSociaisType>>("redeSociais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RedeSociais>(x => x.Where(e => e.HasValue(c.Source.IdTipoRedeSociais)))));
            
        }
    }

    public class TipoRedeSociaisInputType : InputObjectGraphType
	{
		public TipoRedeSociaisInputType()
		{
			// Defining the name of the object
			Name = "tipoRedeSociaisInput";
			
            //Field<StringGraphType>("idTipoRedeSociais");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoRedeSociais");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("corId");
			Field<CorInputType>("cor");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<RedeSociaisInputType>>("redeSociais");
			
		}
	}
}