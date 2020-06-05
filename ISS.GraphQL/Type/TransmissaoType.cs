using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TransmissaoType : ObjectGraphType<Transmissao>
    {
        public TransmissaoType()
        {
            // Defining the name of the object
            Name = "transmissao";

            Field(x => x.IdTransmissao, nullable: true);
            Field(x => x.NumeroSerie, nullable: true);
            Field(x => x.CodTransmissao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TransmissaoInputType : InputObjectGraphType
	{
		public TransmissaoInputType()
		{
			// Defining the name of the object
			Name = "transmissaoInput";
			
            //Field<StringGraphType>("idTransmissao");
			Field<StringGraphType>("numeroSerie");
			Field<StringGraphType>("codTransmissao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			
		}
	}
}