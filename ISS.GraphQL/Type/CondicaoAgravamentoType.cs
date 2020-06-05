using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CondicaoAgravamentoType : ObjectGraphType<CondicaoAgravamento>
    {
        public CondicaoAgravamentoType()
        {
            // Defining the name of the object
            Name = "condicaoAgravamento";

            Field(x => x.IdCondicaoAgravamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCondicaoAgravamento, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Franquia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CapitalSeguro, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CondicaoAplicacaoAgravamentoType>>("condicaoAplicacaoAgravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoAplicacaoAgravamento>(x => x.Where(e => e.HasValue(c.Source.IdCondicaoAgravamento)))));
            
        }
    }

    public class CondicaoAgravamentoInputType : InputObjectGraphType
	{
		public CondicaoAgravamentoInputType()
		{
			// Defining the name of the object
			Name = "condicaoAgravamentoInput";
			
            //Field<StringGraphType>("idCondicaoAgravamento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCondicaoAgravamento");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<FloatGraphType>("franquia");
			Field<FloatGraphType>("capitalSeguro");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CondicaoAplicacaoAgravamentoInputType>>("condicaoAplicacaoAgravamento");
			
		}
	}
}