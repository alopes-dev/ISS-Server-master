using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MediacaoComissaoType : ObjectGraphType<MediacaoComissao>
    {
        public MediacaoComissaoType()
        {
            // Defining the name of the object
            Name = "mediacaoComissao";

            Field(x => x.IdMediacaoComissao, nullable: true);
            Field(x => x.CodMediacaoComissao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Angariacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Cobranca, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Total, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.TipoContratoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoContratoType>("tipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContrato>(c.Source.TipoContratoId)));
            
        }
    }

    public class MediacaoComissaoInputType : InputObjectGraphType
	{
		public MediacaoComissaoInputType()
		{
			// Defining the name of the object
			Name = "mediacaoComissaoInput";
			
            //Field<StringGraphType>("idMediacaoComissao");
			Field<StringGraphType>("codMediacaoComissao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("angariacao");
			Field<FloatGraphType>("cobranca");
			Field<FloatGraphType>("total");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("tipoContratoId");
			Field<StringGraphType>("planoProdutoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoContratoInputType>("tipoContrato");
			
		}
	}
}