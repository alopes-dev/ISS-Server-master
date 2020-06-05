using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoDescontoType : ObjectGraphType<HistoricoDesconto>
    {
        public HistoricoDescontoType()
        {
            // Defining the name of the object
            Name = "historicoDesconto";

            Field(x => x.IdHistoricoDesconto, nullable: true);
            Field(x => x.IdDesconto, nullable: true);
            Field(x => x.TaxaDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoDescontoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodDesconto, nullable: true);
            Field(x => x.ValorMinPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PapelId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TaxaMaxDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMinDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.PrecarioProdutoId, nullable: true);
            
        }
    }

    public class HistoricoDescontoInputType : InputObjectGraphType
	{
		public HistoricoDescontoInputType()
		{
			// Defining the name of the object
			Name = "historicoDescontoInput";
			
            //Field<StringGraphType>("idHistoricoDesconto");
			Field<StringGraphType>("idDesconto");
			Field<FloatGraphType>("taxaDesconto");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFim");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoDescontoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codDesconto");
			Field<FloatGraphType>("valorMinPremioSimples");
			Field<FloatGraphType>("valorMaxPremioSimples");
			Field<StringGraphType>("papelId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("taxaMaxDesconto");
			Field<FloatGraphType>("valorMinDesconto");
			Field<FloatGraphType>("valorMaxDesconto");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("precarioProdutoId");
			
		}
	}
}