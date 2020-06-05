using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoFranquiaType : ObjectGraphType<HistoricoFranquia>
    {
        public HistoricoFranquiaType()
        {
            // Defining the name of the object
            Name = "historicoFranquia";

            Field(x => x.IdHistoricoFranquia, nullable: true);
            Field(x => x.IdFranquia, nullable: true);
            Field(x => x.TaxaMinFranquia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorFranquiaMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorFranquiaMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoFranquiaId, nullable: true);
            Field(x => x.CategoriaFranquiaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFranquia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TaxaMaxFranquia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Desconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CoberturaProdutoId, nullable: true);
            Field(x => x.CoberturasComplementaresId, nullable: true);
            Field(x => x.DiaMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DiaMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            
        }
    }

    public class HistoricoFranquiaInputType : InputObjectGraphType
	{
		public HistoricoFranquiaInputType()
		{
			// Defining the name of the object
			Name = "historicoFranquiaInput";
			
            //Field<StringGraphType>("idHistoricoFranquia");
			Field<StringGraphType>("idFranquia");
			Field<FloatGraphType>("taxaMinFranquia");
			Field<FloatGraphType>("valorFranquiaMin");
			Field<FloatGraphType>("valorFranquiaMax");
			Field<StringGraphType>("tipoFranquiaId");
			Field<StringGraphType>("categoriaFranquiaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFranquia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("taxaMaxFranquia");
			Field<FloatGraphType>("desconto");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("coberturaProdutoId");
			Field<StringGraphType>("coberturasComplementaresId");
			Field<IntGraphType>("diaMin");
			Field<IntGraphType>("diaMax");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("linhaProdutoId");
			
		}
	}
}