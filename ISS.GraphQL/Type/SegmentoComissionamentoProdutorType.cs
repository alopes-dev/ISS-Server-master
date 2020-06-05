using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SegmentoComissionamentoProdutorType : ObjectGraphType<SegmentoComissionamentoProdutor>
    {
        public SegmentoComissionamentoProdutorType()
        {
            // Defining the name of the object
            Name = "segmentoComissionamentoProdutor";

            Field(x => x.IdSegmentoComissionamentoProdutor, nullable: true);
            Field(x => x.TipoSegmentoId, nullable: true);
            Field(x => x.AgenteProdutorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<PessoaType>("agenteProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.AgenteProdutorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            
        }
    }

    public class SegmentoComissionamentoProdutorInputType : InputObjectGraphType
	{
		public SegmentoComissionamentoProdutorInputType()
		{
			// Defining the name of the object
			Name = "segmentoComissionamentoProdutorInput";
			
            //Field<StringGraphType>("idSegmentoComissionamentoProdutor");
			Field<StringGraphType>("tipoSegmentoId");
			Field<StringGraphType>("agenteProdutorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<PessoaInputType>("agenteProdutor");
			Field<EstadoInputType>("estado");
			Field<TipoSegmentoInputType>("tipoSegmento");
			
		}
	}
}