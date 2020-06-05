using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class QualidadeProponenteType : ObjectGraphType<QualidadeProponente>
    {
        public QualidadeProponenteType()
        {
            // Defining the name of the object
            Name = "qualidadeProponente";

            Field(x => x.IdQualidadeProponente, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodQualidadeProponente, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<InstalacoesType>>("instalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Instalacoes>(x => x.Where(e => e.HasValue(c.Source.IdQualidadeProponente)))));
            
        }
    }

    public class QualidadeProponenteInputType : InputObjectGraphType
	{
		public QualidadeProponenteInputType()
		{
			// Defining the name of the object
			Name = "qualidadeProponenteInput";
			
            //Field<StringGraphType>("idQualidadeProponente");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codQualidadeProponente");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<InstalacoesInputType>>("instalacoes");
			
		}
	}
}