using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class InfraccoesType : ObjectGraphType<Infraccoes>
    {
        public InfraccoesType()
        {
            // Defining the name of the object
            Name = "infraccoes";

            Field(x => x.IdInfraccao, nullable: true);
            Field(x => x.DataOcorrencia, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LocalidadeOcorrenciaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoInfracaoId, nullable: true);
            Field(x => x.CondutorId, nullable: true);
            Field(x => x.InformacaoPolicial, nullable: true);
            Field(x => x.AgentePolicialId, nullable: true);
            FieldAsync<PessoaType>("agentePolicial", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.AgentePolicialId)));
            FieldAsync<PessoaType>("condutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.CondutorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<EnderecoType>("localidadeOcorrencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.LocalidadeOcorrenciaId)));
            FieldAsync<TipoInfracaoType>("tipoInfracao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoInfracao>(c.Source.TipoInfracaoId)));
            
        }
    }

    public class InfraccoesInputType : InputObjectGraphType
	{
		public InfraccoesInputType()
		{
			// Defining the name of the object
			Name = "infraccoesInput";
			
            //Field<StringGraphType>("idInfraccao");
			Field<DateTimeGraphType>("dataOcorrencia");
			Field<StringGraphType>("localidadeOcorrenciaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoInfracaoId");
			Field<StringGraphType>("condutorId");
			Field<StringGraphType>("informacaoPolicial");
			Field<StringGraphType>("agentePolicialId");
			Field<PessoaInputType>("agentePolicial");
			Field<PessoaInputType>("condutor");
			Field<EstadoInputType>("estado");
			Field<EnderecoInputType>("localidadeOcorrencia");
			Field<TipoInfracaoInputType>("tipoInfracao");
			
		}
	}
}