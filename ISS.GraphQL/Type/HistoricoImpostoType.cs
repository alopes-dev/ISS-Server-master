using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoImpostoType : ObjectGraphType<HistoricoImposto>
    {
        public HistoricoImpostoType()
        {
            // Defining the name of the object
            Name = "historicoImposto";

            Field(x => x.IdHistoricoImposto, nullable: true);
            Field(x => x.IdImposto, nullable: true);
            Field(x => x.TaxaImposto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoImpostoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodImposto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsIndirecto, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.PrecarioProdutoId, nullable: true);
            
        }
    }

    public class HistoricoImpostoInputType : InputObjectGraphType
	{
		public HistoricoImpostoInputType()
		{
			// Defining the name of the object
			Name = "historicoImpostoInput";
			
            //Field<StringGraphType>("idHistoricoImposto");
			Field<StringGraphType>("idImposto");
			Field<FloatGraphType>("taxaImposto");
			Field<StringGraphType>("tipoImpostoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codImposto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isIndirecto");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("precarioProdutoId");
			
		}
	}
}