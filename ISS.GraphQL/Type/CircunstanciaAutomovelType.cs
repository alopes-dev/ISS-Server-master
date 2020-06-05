using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CircunstanciaAutomovelType : ObjectGraphType<CircunstanciaAutomovel>
    {
        public CircunstanciaAutomovelType()
        {
            // Defining the name of the object
            Name = "circunstanciaAutomovel";

            Field(x => x.IdCircunstanciaAutomovel, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCircunstanciaAutomovel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CircunstanciaObjectoEnvolvidoType>>("circunstanciaObjectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CircunstanciaObjectoEnvolvido>(x => x.Where(e => e.HasValue(c.Source.IdCircunstanciaAutomovel)))));
            
        }
    }

    public class CircunstanciaAutomovelInputType : InputObjectGraphType
	{
		public CircunstanciaAutomovelInputType()
		{
			// Defining the name of the object
			Name = "circunstanciaAutomovelInput";
			
            //Field<StringGraphType>("idCircunstanciaAutomovel");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCircunstanciaAutomovel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CircunstanciaObjectoEnvolvidoInputType>>("circunstanciaObjectoEnvolvido");
			
		}
	}
}