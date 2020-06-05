using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BoletimAdesaoSaudeType : ObjectGraphType<BoletimAdesaoSaude>
    {
        public BoletimAdesaoSaudeType()
        {
            // Defining the name of the object
            Name = "boletimAdesaoSaude";

            Field(x => x.IdBoletimAdesaoSaude, nullable: true);
            Field(x => x.DataInclusao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataExclusao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAnulacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Proponente, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.OutrosSegurosId, nullable: true);
            Field(x => x.ObservacoesBoletimAdesao, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodBoletimAdesaoSaude, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ObservacoesBoletimAdesaoType>("observacoesBoletimAdesaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObservacoesBoletimAdesao>(c.Source.ObservacoesBoletimAdesao)));
            FieldAsync<OutrosSegurosType>("outrosSeguros", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OutrosSeguros>(c.Source.OutrosSegurosId)));
            
        }
    }

    public class BoletimAdesaoSaudeInputType : InputObjectGraphType
	{
		public BoletimAdesaoSaudeInputType()
		{
			// Defining the name of the object
			Name = "boletimAdesaoSaudeInput";
			
            //Field<StringGraphType>("idBoletimAdesaoSaude");
			Field<DateTimeGraphType>("dataInclusao");
			Field<DateTimeGraphType>("dataExclusao");
			Field<DateTimeGraphType>("dataAnulacao");
			Field<StringGraphType>("proponente");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("outrosSegurosId");
			Field<StringGraphType>("observacoesBoletimAdesao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codBoletimAdesaoSaude");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			Field<ObservacoesBoletimAdesaoInputType>("observacoesBoletimAdesaoNavigation");
			Field<OutrosSegurosInputType>("outrosSeguros");
			
		}
	}
}