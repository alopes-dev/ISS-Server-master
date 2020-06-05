using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoMovimentoType : ObjectGraphType<TipoMovimento>
    {
        public TipoMovimentoType()
        {
            // Defining the name of the object
            Name = "tipoMovimento";

            Field(x => x.IdTipoMovimento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoMovimento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoMovimentoInputType : InputObjectGraphType
	{
		public TipoMovimentoInputType()
		{
			// Defining the name of the object
			Name = "tipoMovimentoInput";
			
            //Field<StringGraphType>("idTipoMovimento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoMovimento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}