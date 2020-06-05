using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CompanhiaViagemType : ObjectGraphType<CompanhiaViagem>
    {
        public CompanhiaViagemType()
        {
            // Defining the name of the object
            Name = "companhiaViagem";

            Field(x => x.IdCompanhiaViagem, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCompanhiaViagem, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ViagemType>>("viagem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Viagem>(x => x.Where(e => e.HasValue(c.Source.IdCompanhiaViagem)))));
            
        }
    }

    public class CompanhiaViagemInputType : InputObjectGraphType
	{
		public CompanhiaViagemInputType()
		{
			// Defining the name of the object
			Name = "companhiaViagemInput";
			
            //Field<StringGraphType>("idCompanhiaViagem");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCompanhiaViagem");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ViagemInputType>>("viagem");
			
		}
	}
}