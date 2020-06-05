using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrestacoesFraccionamentoType : ObjectGraphType<PrestacoesFraccionamento>
    {
        public PrestacoesFraccionamentoType()
        {
            // Defining the name of the object
            Name = "prestacoesFraccionamento";

            Field(x => x.IdPrestacao, nullable: true);
            Field(x => x.NumPrestacao, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Percentagem, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodPrestacoesFraccionamento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.FraccionamentoProdutoId, nullable: true);
            Field(x => x.PremioMinimoAnual, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class PrestacoesFraccionamentoInputType : InputObjectGraphType
	{
		public PrestacoesFraccionamentoInputType()
		{
			// Defining the name of the object
			Name = "prestacoesFraccionamentoInput";
			
            //Field<StringGraphType>("idPrestacao");
			Field<IntGraphType>("numPrestacao");
			Field<FloatGraphType>("percentagem");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codPrestacoesFraccionamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("fraccionamentoProdutoId");
			Field<FloatGraphType>("premioMinimoAnual");
			Field<EstadoInputType>("estado");
			
		}
	}
}