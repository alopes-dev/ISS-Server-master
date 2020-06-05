using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoMargemVendaProdutoType : ObjectGraphType<HistoricoMargemVendaProduto>
    {
        public HistoricoMargemVendaProdutoType()
        {
            // Defining the name of the object
            Name = "historicoMargemVendaProduto";

            Field(x => x.IdHistoricoMargemVendaProduto, nullable: true);
            Field(x => x.IdMargemVendaProduto, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMinPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Descricao, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.TipoMargemId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PrecarioProdutoId, nullable: true);
            
        }
    }

    public class HistoricoMargemVendaProdutoInputType : InputObjectGraphType
	{
		public HistoricoMargemVendaProdutoInputType()
		{
			// Defining the name of the object
			Name = "historicoMargemVendaProdutoInput";
			
            //Field<StringGraphType>("idHistoricoMargemVendaProduto");
			Field<StringGraphType>("idMargemVendaProduto");
			Field<FloatGraphType>("taxa");
			Field<FloatGraphType>("valorMinPremioSimples");
			Field<FloatGraphType>("valorMaxPremioSimples");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("tipoMargemId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("precarioProdutoId");
			
		}
	}
}