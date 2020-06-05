using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CanalComissionamentoProdutorType : ObjectGraphType<CanalComissionamentoProdutor>
    {
        public CanalComissionamentoProdutorType()
        {
            // Defining the name of the object
            Name = "canalComissionamentoProdutor";

            Field(x => x.IdCanalComissionamentoProdutor, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.AgenteProdutorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<PessoaType>("agenteProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.AgenteProdutorId)));
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CanalComissionamentoProdutorInputType : InputObjectGraphType
	{
		public CanalComissionamentoProdutorInputType()
		{
			// Defining the name of the object
			Name = "canalComissionamentoProdutorInput";
			
            //Field<StringGraphType>("idCanalComissionamentoProdutor");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("agenteProdutorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<PessoaInputType>("agenteProdutor");
			Field<CanalInputType>("canal");
			Field<EstadoInputType>("estado");
			
		}
	}
}