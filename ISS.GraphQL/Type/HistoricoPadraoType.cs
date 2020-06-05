using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoPadraoType : ObjectGraphType<HistoricoPadrao>
    {
        public HistoricoPadraoType()
        {
            // Defining the name of the object
            Name = "historicoPadrao";

            Field(x => x.IdHistoricoPadrao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<OperacoesRecebimentoType>>("operacoesRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesRecebimento>(x => x.Where(e => e.HasValue(c.Source.IdHistoricoPadrao)))));
            
        }
    }

    public class HistoricoPadraoInputType : InputObjectGraphType
	{
		public HistoricoPadraoInputType()
		{
			// Defining the name of the object
			Name = "historicoPadraoInput";
			
            //Field<StringGraphType>("idHistoricoPadrao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<OperacoesRecebimentoInputType>>("operacoesRecebimento");
			
		}
	}
}