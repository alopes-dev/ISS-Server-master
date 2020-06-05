using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoRecebimentoMovimentoType : ObjectGraphType<TipoRecebimentoMovimento>
    {
        public TipoRecebimentoMovimentoType()
        {
            // Defining the name of the object
            Name = "tipoRecebimentoMovimento";

            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ModificadoPor, nullable: true);
            Field(x => x.TipoRecebimentoId, nullable: true);
            Field(x => x.MovimentoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MovimentoType>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(c.Source.MovimentoId)));
            FieldAsync<TipoRecebimentoType>("tipoRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRecebimento>(c.Source.TipoRecebimentoId)));
            
        }
    }

    public class TipoRecebimentoMovimentoInputType : InputObjectGraphType
	{
		public TipoRecebimentoMovimentoInputType()
		{
			// Defining the name of the object
			Name = "tipoRecebimentoMovimentoInput";
			
            Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("modificadoPor");
			Field<StringGraphType>("tipoRecebimentoId");
			//Field<StringGraphType>("movimentoId");
			Field<EstadoInputType>("estado");
			Field<MovimentoInputType>("movimento");
			Field<TipoRecebimentoInputType>("tipoRecebimento");
			
		}
	}
}