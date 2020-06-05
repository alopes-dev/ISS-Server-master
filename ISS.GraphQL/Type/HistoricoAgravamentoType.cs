using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoAgravamentoType : ObjectGraphType<HistoricoAgravamento>
    {
        public HistoricoAgravamentoType()
        {
            // Defining the name of the object
            Name = "historicoAgravamento";

            Field(x => x.IdHistoricoAgravamento, nullable: true);
            Field(x => x.IdAgravamento, nullable: true);
            Field(x => x.TaxaAgravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorAgravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoAgravamentoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PrecarioProdutoId, nullable: true);
            
        }
    }

    public class HistoricoAgravamentoInputType : InputObjectGraphType
	{
		public HistoricoAgravamentoInputType()
		{
			// Defining the name of the object
			Name = "historicoAgravamentoInput";
			
            //Field<StringGraphType>("idHistoricoAgravamento");
			Field<StringGraphType>("idAgravamento");
			Field<FloatGraphType>("taxaAgravamento");
			Field<FloatGraphType>("valorAgravamento");
			Field<StringGraphType>("tipoAgravamentoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("produtoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("precarioProdutoId");
			
		}
	}
}