using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoComissaoType : ObjectGraphType<HistoricoComissao>
    {
        public HistoricoComissaoType()
        {
            // Defining the name of the object
            Name = "historicoComissao";

            Field(x => x.IdHistoricoComissao, nullable: true);
            Field(x => x.IdComissao, nullable: true);
            Field(x => x.TaxaMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoComissaoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodComissao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PapelId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.IsRetencao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PercentagemRetencao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.DataCancelamento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataEstorno, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAnulacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PrecarioProdutoId, nullable: true);
            
        }
    }

    public class HistoricoComissaoInputType : InputObjectGraphType
	{
		public HistoricoComissaoInputType()
		{
			// Defining the name of the object
			Name = "historicoComissaoInput";
			
            //Field<StringGraphType>("idHistoricoComissao");
			Field<StringGraphType>("idComissao");
			Field<FloatGraphType>("taxaMin");
			Field<FloatGraphType>("taxaMax");
			Field<StringGraphType>("tipoComissaoId");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codComissao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("papelId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("linhaProdutoId");
			Field<BooleanGraphType>("isRetencao");
			Field<FloatGraphType>("percentagemRetencao");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<DateTimeGraphType>("dataCancelamento");
			Field<DateTimeGraphType>("dataEstorno");
			Field<DateTimeGraphType>("dataAnulacao");
			Field<StringGraphType>("precarioProdutoId");
			
		}
	}
}