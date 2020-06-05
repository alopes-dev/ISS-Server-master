using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PeriodoCoberturaProdutoType : ObjectGraphType<PeriodoCoberturaProduto>
    {
        public PeriodoCoberturaProdutoType()
        {
            // Defining the name of the object
            Name = "periodoCoberturaProduto";

            Field(x => x.IdPeriodoCoberturaProduto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodPeriodoCoberturaProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class PeriodoCoberturaProdutoInputType : InputObjectGraphType
	{
		public PeriodoCoberturaProdutoInputType()
		{
			// Defining the name of the object
			Name = "periodoCoberturaProdutoInput";
			
            //Field<StringGraphType>("idPeriodoCoberturaProduto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codPeriodoCoberturaProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}