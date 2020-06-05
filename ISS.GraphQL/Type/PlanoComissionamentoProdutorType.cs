using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PlanoComissionamentoProdutorType : ObjectGraphType<PlanoComissionamentoProdutor>
    {
        public PlanoComissionamentoProdutorType()
        {
            // Defining the name of the object
            Name = "planoComissionamentoProdutor";

            Field(x => x.IdPlanoComissionamentoProdutor, nullable: true);
            Field(x => x.PlanoContasId, nullable: true);
            Field(x => x.AgenteProdutorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<PessoaType>("agenteProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.AgenteProdutorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoContasType>("planoContas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.PlanoContasId)));
            
        }
    }

    public class PlanoComissionamentoProdutorInputType : InputObjectGraphType
	{
		public PlanoComissionamentoProdutorInputType()
		{
			// Defining the name of the object
			Name = "planoComissionamentoProdutorInput";
			
            //Field<StringGraphType>("idPlanoComissionamentoProdutor");
			Field<StringGraphType>("planoContasId");
			Field<StringGraphType>("agenteProdutorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<PessoaInputType>("agenteProdutor");
			Field<EstadoInputType>("estado");
			Field<PlanoContasInputType>("planoContas");
			
		}
	}
}