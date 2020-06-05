using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarifasPremioAutoAcidentesTrabalhoType : ObjectGraphType<TarifasPremioAutoAcidentesTrabalho>
    {
        public TarifasPremioAutoAcidentesTrabalhoType()
        {
            // Defining the name of the object
            Name = "tarifasPremioAutoAcidentesTrabalho";

            Field(x => x.IdTarifa, nullable: true);
            Field(x => x.Descricao, nullable: true);
            //FieldAsync<ByteType>("txDp", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Byte>(c.Source.IdTarifa)));
            Field(x => x.Ocupantes, nullable: true);
            Field(x => x.CapitalRc, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioFixo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.UcfUsd, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodTarifasPremioAutoAcidentesTrabalho, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodInformacoesAdicionaisProduto, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            
        }
    }

    public class TarifasPremioAutoAcidentesTrabalhoInputType : InputObjectGraphType
	{
		public TarifasPremioAutoAcidentesTrabalhoInputType()
		{
			// Defining the name of the object
			Name = "tarifasPremioAutoAcidentesTrabalhoInput";
			
            //Field<StringGraphType>("idTarifa");
			Field<StringGraphType>("descricao");
			//Field<ByteInputType>("txDp");
			Field<StringGraphType>("ocupantes");
			Field<FloatGraphType>("capitalRc");
			Field<FloatGraphType>("premioFixo");
			Field<FloatGraphType>("ucfUsd");
			Field<FloatGraphType>("premioSimples");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codTarifasPremioAutoAcidentesTrabalho");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("codInformacoesAdicionaisProduto");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<ProdutoInputType>("produto");
			Field<PlanoContasInputType>("subConta");
			
		}
	}
}