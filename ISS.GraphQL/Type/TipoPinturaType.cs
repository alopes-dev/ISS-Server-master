using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPinturaType : ObjectGraphType<TipoPintura>
    {
        public TipoPinturaType()
        {
            // Defining the name of the object
            Name = "tipoPintura";

            Field(x => x.IdTipoPintura, nullable: true);
            Field(x => x.TipoFinalizacao, nullable: true);
            Field(x => x.CodTipoPintura, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoPinturaInputType : InputObjectGraphType
	{
		public TipoPinturaInputType()
		{
			// Defining the name of the object
			Name = "tipoPinturaInput";
			
            //Field<StringGraphType>("idTipoPintura");
			Field<StringGraphType>("tipoFinalizacao");
			Field<StringGraphType>("codTipoPintura");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			
		}
	}
}