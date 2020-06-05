using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrazosCurtosType : ObjectGraphType<PrazosCurtos>
    {
        public PrazosCurtosType()
        {
            // Defining the name of the object
            Name = "prazosCurtos";

            Field(x => x.IdPrazo, nullable: true);
            Field(x => x.DiasMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DiasMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Porcentagem, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescricaoPrazo, nullable: true);
            Field(x => x.CodPrazosCurtos, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.DuracaoTipoContratoId, nullable: true);
            FieldAsync<DuracaoTipoContratoType>("duracaoTipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DuracaoTipoContrato>(c.Source.DuracaoTipoContratoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdPrazo)))));
            FieldAsync<ListGraphType<PlanoProdutoType>>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(x => x.Where(e => e.HasValue(c.Source.IdPrazo)))));
            
        }
    }

    public class PrazosCurtosInputType : InputObjectGraphType
	{
		public PrazosCurtosInputType()
		{
			// Defining the name of the object
			Name = "prazosCurtosInput";
			
            //Field<StringGraphType>("idPrazo");
			Field<IntGraphType>("diasMin");
			Field<IntGraphType>("diasMax");
			Field<FloatGraphType>("porcentagem");
			Field<StringGraphType>("descricaoPrazo");
			Field<StringGraphType>("codPrazosCurtos");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("duracaoTipoContratoId");
			Field<DuracaoTipoContratoInputType>("duracaoTipoContrato");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<PlanoProdutoInputType>>("planoProduto");
			
		}
	}
}