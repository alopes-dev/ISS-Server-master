using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoDespesaType : ObjectGraphType<HistoricoDespesa>
    {
        public HistoricoDespesaType()
        {
            // Defining the name of the object
            Name = "historicoDespesa";

            Field(x => x.IdHistoricoDespesa, nullable: true);
            Field(x => x.IdDespesa, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoDespesaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodDespesa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.PrecarioProdutoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            
        }
    }

    public class HistoricoDespesaInputType : InputObjectGraphType
	{
		public HistoricoDespesaInputType()
		{
			// Defining the name of the object
			Name = "historicoDespesaInput";
			
            //Field<StringGraphType>("idHistoricoDespesa");
			Field<StringGraphType>("idDespesa");
			Field<FloatGraphType>("valorMin");
			Field<StringGraphType>("tipoDespesaId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codDespesa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("valorMax");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("precarioProdutoId");
			Field<BooleanGraphType>("isTaxa");
			
		}
	}
}