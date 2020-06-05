using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CondicaoAplicacaoAgravamentoType : ObjectGraphType<CondicaoAplicacaoAgravamento>
    {
        public CondicaoAplicacaoAgravamentoType()
        {
            // Defining the name of the object
            Name = "condicaoAplicacaoAgravamento";

            Field(x => x.IdCondicaoTarifa, nullable: true);
            Field(x => x.CondicaoAgravamentoId, nullable: true);
            Field(x => x.AgravamentoId, nullable: true);
            Field(x => x.Valor, nullable: true);
            Field(x => x.UnidadeId, nullable: true);
            Field(x => x.CodCondicaoTarifa, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<AgravamentoType>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(c.Source.AgravamentoId)));
            FieldAsync<CondicaoAgravamentoType>("condicaoAgravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoAgravamento>(c.Source.CondicaoAgravamentoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CondicaoAplicacaoAgravamentoInputType : InputObjectGraphType
	{
		public CondicaoAplicacaoAgravamentoInputType()
		{
			// Defining the name of the object
			Name = "condicaoAplicacaoAgravamentoInput";
			
            //Field<StringGraphType>("idCondicaoTarifa");
			Field<StringGraphType>("condicaoAgravamentoId");
			Field<StringGraphType>("agravamentoId");
			Field<StringGraphType>("valor");
			Field<StringGraphType>("unidadeId");
			Field<StringGraphType>("codCondicaoTarifa");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<AgravamentoInputType>("agravamento");
			Field<CondicaoAgravamentoInputType>("condicaoAgravamento");
			Field<EstadoInputType>("estado");
			
		}
	}
}