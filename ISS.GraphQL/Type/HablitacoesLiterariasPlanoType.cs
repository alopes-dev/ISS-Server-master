using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HablitacoesLiterariasPlanoType : ObjectGraphType<HablitacoesLiterariasPlano>
    {
        public HablitacoesLiterariasPlanoType()
        {
            // Defining the name of the object
            Name = "hablitacoesLiterariasPlano";

            Field(x => x.IdHablitacoesLiterariasPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.FormaLiquidacaoPremioId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaLiquidacaoPremioType>("formaLiquidacaoPremio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaLiquidacaoPremio>(c.Source.FormaLiquidacaoPremioId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class HablitacoesLiterariasPlanoInputType : InputObjectGraphType
	{
		public HablitacoesLiterariasPlanoInputType()
		{
			// Defining the name of the object
			Name = "hablitacoesLiterariasPlanoInput";
			
            //Field<StringGraphType>("idHablitacoesLiterariasPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("formaLiquidacaoPremioId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<FormaLiquidacaoPremioInputType>("formaLiquidacaoPremio");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}