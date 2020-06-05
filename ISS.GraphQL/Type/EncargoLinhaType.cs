using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EncargoLinhaType : ObjectGraphType<EncargoLinha>
    {
        public EncargoLinhaType()
        {
            // Defining the name of the object
            Name = "encargoLinha";

            Field(x => x.IdEncargoLinha, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EncargoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodEncargoPlano, nullable: true);
            FieldAsync<EncargosType>("encargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Encargos>(c.Source.EncargoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class EncargoLinhaInputType : InputObjectGraphType
	{
		public EncargoLinhaInputType()
		{
			// Defining the name of the object
			Name = "encargoLinhaInput";
			
            //Field<StringGraphType>("idEncargoLinha");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("encargoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codEncargoPlano");
			Field<EncargosInputType>("encargo");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}