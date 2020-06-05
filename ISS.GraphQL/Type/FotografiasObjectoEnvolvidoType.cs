using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FotografiasObjectoEnvolvidoType : ObjectGraphType<FotografiasObjectoEnvolvido>
    {
        public FotografiasObjectoEnvolvidoType()
        {
            // Defining the name of the object
            Name = "fotografiasObjectoEnvolvido";

            Field(x => x.IdFotografia, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.ObjectoEnvolvidoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ObjectoEnvolvidoType>("objectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoEnvolvido>(c.Source.ObjectoEnvolvidoId)));
            
        }
    }

    public class FotografiasObjectoEnvolvidoInputType : InputObjectGraphType
	{
		public FotografiasObjectoEnvolvidoInputType()
		{
			// Defining the name of the object
			Name = "fotografiasObjectoEnvolvidoInput";
			
            //Field<StringGraphType>("idFotografia");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("objectoEnvolvidoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ObjectoEnvolvidoInputType>("objectoEnvolvido");
			
		}
	}
}