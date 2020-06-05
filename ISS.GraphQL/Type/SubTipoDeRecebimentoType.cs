using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubTipoDeRecebimentoType : ObjectGraphType<SubTipoDeRecebimento>
    {
        public SubTipoDeRecebimentoType()
        {
            // Defining the name of the object
            Name = "subTipoDeRecebimento";

            Field(x => x.IdSubTipoDeRecebimento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodigoSubTipoDeRecebimento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoDeRecebimentoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoDeRecebimentoType>("tipoDeRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDeRecebimento>(c.Source.TipoDeRecebimentoId)));
            
        }
    }

    public class SubTipoDeRecebimentoInputType : InputObjectGraphType
	{
		public SubTipoDeRecebimentoInputType()
		{
			// Defining the name of the object
			Name = "subTipoDeRecebimentoInput";
			
            //Field<StringGraphType>("idSubTipoDeRecebimento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codigoSubTipoDeRecebimento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoDeRecebimentoId");
			Field<EstadoInputType>("estado");
			Field<TipoDeRecebimentoInputType>("tipoDeRecebimento");
			
		}
	}
}