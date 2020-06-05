using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoTransferenciaType : ObjectGraphType<TipoTransferencia>
    {
        public TipoTransferenciaType()
        {
            // Defining the name of the object
            Name = "tipoTransferencia";

            Field(x => x.IdTipoTransferencia, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoTransferencia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<TransferenciaType>>("transferencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Transferencia>(x => x.Where(e => e.HasValue(c.Source.IdTipoTransferencia)))));
            
        }
    }

    public class TipoTransferenciaInputType : InputObjectGraphType
	{
		public TipoTransferenciaInputType()
		{
			// Defining the name of the object
			Name = "tipoTransferenciaInput";
			
            //Field<StringGraphType>("idTipoTransferencia");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoTransferencia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<TransferenciaInputType>>("transferencia");
			
		}
	}
}