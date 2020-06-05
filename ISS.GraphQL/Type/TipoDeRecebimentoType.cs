using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoDeRecebimentoType : ObjectGraphType<TipoDeRecebimento>
    {
        public TipoDeRecebimentoType()
        {
            // Defining the name of the object
            Name = "tipoDeRecebimento";

            Field(x => x.IdTipoDeRecebimento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodigoTipoDeRecebimento, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<SubTipoDeRecebimentoType>>("subTipoDeRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTipoDeRecebimento>(x => x.Where(e => e.HasValue(c.Source.IdTipoDeRecebimento)))));
            
        }
    }

    public class TipoDeRecebimentoInputType : InputObjectGraphType
	{
		public TipoDeRecebimentoInputType()
		{
			// Defining the name of the object
			Name = "tipoDeRecebimentoInput";
			
            //Field<StringGraphType>("idTipoDeRecebimento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codigoTipoDeRecebimento");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<SubTipoDeRecebimentoInputType>>("subTipoDeRecebimento");
			
		}
	}
}