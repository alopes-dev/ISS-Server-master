using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarifasPremioAutoAt2Type : ObjectGraphType<TarifasPremioAutoAt2>
    {
        public TarifasPremioAutoAt2Type()
        {
            // Defining the name of the object
            Name = "tarifasPremioAutoAt2";

            Field(x => x.IdTarifa, nullable: true);
            Field(x => x.Classe, nullable: true, type: typeof(IntGraphType));
            Field(x => x.SubClasse, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Descricao, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodTarifasPremioAutoAt2, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            
        }
    }

    public class TarifasPremioAutoAt2InputType : InputObjectGraphType
	{
		public TarifasPremioAutoAt2InputType()
		{
			// Defining the name of the object
			Name = "tarifasPremioAutoAt2Input";
			
            //Field<StringGraphType>("idTarifa");
			Field<IntGraphType>("classe");
			Field<IntGraphType>("subClasse");
			Field<StringGraphType>("descricao");
			Field<FloatGraphType>("taxa");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codTarifasPremioAutoAt2");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<ProdutoInputType>("produto");
			Field<PlanoContasInputType>("subConta");
			
		}
	}
}