using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoEncargoType : ObjectGraphType<HistoricoEncargo>
    {
        public HistoricoEncargoType()
        {
            // Defining the name of the object
            Name = "historicoEncargo";

            Field(x => x.IdHistoricoEncargo, nullable: true);
            Field(x => x.IdEncargo, nullable: true);
            Field(x => x.TaxaMinEncargo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoEncargoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodEncargo, nullable: true);
            Field(x => x.ValorMinPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxPremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TaxaMaxEncargo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMinEncargo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMaxEncargo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.PrecarioProdutoId, nullable: true);
            
        }
    }

    public class HistoricoEncargoInputType : InputObjectGraphType
	{
		public HistoricoEncargoInputType()
		{
			// Defining the name of the object
			Name = "historicoEncargoInput";
			
            //Field<StringGraphType>("idHistoricoEncargo");
			Field<StringGraphType>("idEncargo");
			Field<FloatGraphType>("taxaMinEncargo");
			Field<StringGraphType>("tipoEncargoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codEncargo");
			Field<FloatGraphType>("valorMinPremioSimples");
			Field<FloatGraphType>("valorMaxPremioSimples");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("taxaMaxEncargo");
			Field<FloatGraphType>("valorMinEncargo");
			Field<FloatGraphType>("valorMaxEncargo");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("precarioProdutoId");
			
		}
	}
}