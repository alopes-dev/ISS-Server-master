using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FormaReparacaoType : ObjectGraphType<FormaReparacao>
    {
        public FormaReparacaoType()
        {
            // Defining the name of the object
            Name = "formaReparacao";

            Field(x => x.IdFormaReparacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFormaReparacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CoberturaType>>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(x => x.Where(e => e.HasValue(c.Source.IdFormaReparacao)))));
            
        }
    }

    public class FormaReparacaoInputType : InputObjectGraphType
	{
		public FormaReparacaoInputType()
		{
			// Defining the name of the object
			Name = "formaReparacaoInput";
			
            //Field<StringGraphType>("idFormaReparacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFormaReparacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CoberturaInputType>>("cobertura");
			
		}
	}
}