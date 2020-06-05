using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ReducoesAutorizadasType : ObjectGraphType<ReducoesAutorizadas>
    {
        public ReducoesAutorizadasType()
        {
            // Defining the name of the object
            Name = "reducoesAutorizadas";

            Field(x => x.IdReducoesAutoridas, nullable: true);
            Field(x => x.CodReducoesAutoridas, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TaxaTarifa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaReduzida, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class ReducoesAutorizadasInputType : InputObjectGraphType
	{
		public ReducoesAutorizadasInputType()
		{
			// Defining the name of the object
			Name = "reducoesAutorizadasInput";
			
            //Field<StringGraphType>("idReducoesAutoridas");
			Field<StringGraphType>("codReducoesAutoridas");
			Field<DateTimeGraphType>("dataCriacao");
			Field<FloatGraphType>("taxaTarifa");
			Field<FloatGraphType>("taxaReduzida");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}