using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FidelizacaoPlanoType : ObjectGraphType<FidelizacaoPlano>
    {
        public FidelizacaoPlanoType()
        {
            // Defining the name of the object
            Name = "fidelizacaoPlano";

            Field(x => x.IdFidelizacaoPlano, nullable: true);
            Field(x => x.FidelizacaoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FidelizacaoType>("fidelizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fidelizacao>(c.Source.FidelizacaoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<LimiteComissionamentoPlanoType>>("limiteComissionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdFidelizacaoPlano)))));
            FieldAsync<ListGraphType<LimiteComissionamentoProdutorType>>("limiteComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdFidelizacaoPlano)))));
            
        }
    }

    public class FidelizacaoPlanoInputType : InputObjectGraphType
	{
		public FidelizacaoPlanoInputType()
		{
			// Defining the name of the object
			Name = "fidelizacaoPlanoInput";
			
            //Field<StringGraphType>("idFidelizacaoPlano");
			Field<StringGraphType>("fidelizacaoId");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<EstadoInputType>("estado");
			Field<FidelizacaoInputType>("fidelizacao");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<LimiteComissionamentoPlanoInputType>>("limiteComissionamentoPlano");
			Field<ListGraphType<LimiteComissionamentoProdutorInputType>>("limiteComissionamentoProdutor");
			
		}
	}
}