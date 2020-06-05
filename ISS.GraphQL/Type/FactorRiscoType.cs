using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FactorRiscoType : ObjectGraphType<FactorRisco>
    {
        public FactorRiscoType()
        {
            // Defining the name of the object
            Name = "factorRisco";

            Field(x => x.IdFactorRisco, nullable: true);
            Field(x => x.CodFactorRisco, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class FactorRiscoInputType : InputObjectGraphType
	{
		public FactorRiscoInputType()
		{
			// Defining the name of the object
			Name = "factorRiscoInput";
			
            //Field<StringGraphType>("idFactorRisco");
			Field<StringGraphType>("codFactorRisco");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("linhaProdutoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}