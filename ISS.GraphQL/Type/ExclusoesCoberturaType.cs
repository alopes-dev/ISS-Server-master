using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExclusoesCoberturaType : ObjectGraphType<ExclusoesCobertura>
    {
        public ExclusoesCoberturaType()
        {
            // Defining the name of the object
            Name = "exclusoesCobertura";

            Field(x => x.IdExclusoesCobertura, nullable: true);
            Field(x => x.CodExclusoesCobertura, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CoberturaId, nullable: true);
            Field(x => x.ExclusaoId, nullable: true);
            FieldAsync<CoberturaType>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaId)));
            FieldAsync<ExclusoesType>("exclusao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exclusoes>(c.Source.ExclusaoId)));
            
        }
    }

    public class ExclusoesCoberturaInputType : InputObjectGraphType
	{
		public ExclusoesCoberturaInputType()
		{
			// Defining the name of the object
			Name = "exclusoesCoberturaInput";
			
            //Field<StringGraphType>("idExclusoesCobertura");
			Field<StringGraphType>("codExclusoesCobertura");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("coberturaId");
			Field<StringGraphType>("exclusaoId");
			Field<CoberturaInputType>("cobertura");
			Field<ExclusoesInputType>("exclusao");
			
		}
	}
}