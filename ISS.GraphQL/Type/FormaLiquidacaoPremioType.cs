using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FormaLiquidacaoPremioType : ObjectGraphType<FormaLiquidacaoPremio>
    {
        public FormaLiquidacaoPremioType()
        {
            // Defining the name of the object
            Name = "formaLiquidacaoPremio";

            Field(x => x.IdFormaLiquidacaoPremio, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFormaLiquidacaoPremio, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdFormaLiquidacaoPremio)))));
            FieldAsync<ListGraphType<FormaLiquidacaoPremioPlanoType>>("formaLiquidacaoPremioPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaLiquidacaoPremioPlano>(x => x.Where(e => e.HasValue(c.Source.IdFormaLiquidacaoPremio)))));
            FieldAsync<ListGraphType<FraccionamentoPlanoType>>("fraccionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FraccionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdFormaLiquidacaoPremio)))));
            FieldAsync<ListGraphType<HablitacoesLiterariasPlanoType>>("hablitacoesLiterariasPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HablitacoesLiterariasPlano>(x => x.Where(e => e.HasValue(c.Source.IdFormaLiquidacaoPremio)))));
            FieldAsync<ListGraphType<RendimentosPessoaType>>("rendimentosPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RendimentosPessoa>(x => x.Where(e => e.HasValue(c.Source.IdFormaLiquidacaoPremio)))));
            
        }
    }

    public class FormaLiquidacaoPremioInputType : InputObjectGraphType
	{
		public FormaLiquidacaoPremioInputType()
		{
			// Defining the name of the object
			Name = "formaLiquidacaoPremioInput";
			
            //Field<StringGraphType>("idFormaLiquidacaoPremio");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFormaLiquidacaoPremio");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<FormaLiquidacaoPremioPlanoInputType>>("formaLiquidacaoPremioPlano");
			Field<ListGraphType<FraccionamentoPlanoInputType>>("fraccionamentoPlano");
			Field<ListGraphType<HablitacoesLiterariasPlanoInputType>>("hablitacoesLiterariasPlano");
			Field<ListGraphType<RendimentosPessoaInputType>>("rendimentosPessoa");
			
		}
	}
}