using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarifasAutomovelType : ObjectGraphType<TarifasAutomovel>
    {
        public TarifasAutomovelType()
        {
            // Defining the name of the object
            Name = "tarifasAutomovel";

            Field(x => x.IdTarifa, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(IntGraphType));
            Field(x => x.AnosId, nullable: true);
            Field(x => x.MesesId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.CodTarifasAutomovel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodInformacoesAdicionaisProduto, nullable: true);
            FieldAsync<AnosType>("anos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Anos>(c.Source.AnosId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<MesesType>("meses", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Meses>(c.Source.MesesId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            
        }
    }

    public class TarifasAutomovelInputType : InputObjectGraphType
	{
		public TarifasAutomovelInputType()
		{
			// Defining the name of the object
			Name = "tarifasAutomovelInput";
			
            //Field<StringGraphType>("idTarifa");
			Field<IntGraphType>("valor");
			Field<StringGraphType>("anosId");
			Field<StringGraphType>("mesesId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("codTarifasAutomovel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("codInformacoesAdicionaisProduto");
			Field<AnosInputType>("anos");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<MesesInputType>("meses");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<ProdutoInputType>("produto");
			Field<PlanoContasInputType>("subConta");
			
		}
	}
}