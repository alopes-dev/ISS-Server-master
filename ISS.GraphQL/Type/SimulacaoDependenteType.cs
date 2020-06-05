using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SimulacaoDependenteType : ObjectGraphType<SimulacaoDependente>
    {
        public SimulacaoDependenteType()
        {
            // Defining the name of the object
            Name = "simulacaoDependente";

            Field(x => x.IdSimulacaoDependente, nullable: true);
            Field(x => x.NumOrdem, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodSimulacaoDependente, nullable: true);
            Field(x => x.SimulacaoId, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SimulacaoType>("simulacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Simulacao>(c.Source.SimulacaoId)));
            
        }
    }

    public class SimulacaoDependenteInputType : InputObjectGraphType
	{
		public SimulacaoDependenteInputType()
		{
			// Defining the name of the object
			Name = "simulacaoDependenteInput";
			
            //Field<StringGraphType>("idSimulacaoDependente");
			Field<IntGraphType>("numOrdem");
			Field<StringGraphType>("codSimulacaoDependente");
			Field<StringGraphType>("simulacaoId");
			Field<StringGraphType>("cotacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CotacaoInputType>("cotacao");
			Field<EstadoInputType>("estado");
			Field<SimulacaoInputType>("simulacao");
			
		}
	}
}