using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PeriodoCalculoType : ObjectGraphType<PeriodoCalculo>
    {
        public PeriodoCalculoType()
        {
            // Defining the name of the object
            Name = "periodoCalculo";

            Field(x => x.IdPeriodoCalculo, nullable: true);
            Field(x => x.Periodo, nullable: true, type: typeof(IntGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.MesesId, nullable: true);
            Field(x => x.DuracaoTipoContratoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodPeriodoCalculo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<DuracaoTipoContratoType>("duracaoTipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DuracaoTipoContrato>(c.Source.DuracaoTipoContratoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MesesType>("meses", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Meses>(c.Source.MesesId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class PeriodoCalculoInputType : InputObjectGraphType
	{
		public PeriodoCalculoInputType()
		{
			// Defining the name of the object
			Name = "periodoCalculoInput";
			
            //Field<StringGraphType>("idPeriodoCalculo");
			Field<IntGraphType>("periodo");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("mesesId");
			Field<StringGraphType>("duracaoTipoContratoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codPeriodoCalculo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DuracaoTipoContratoInputType>("duracaoTipoContrato");
			Field<EstadoInputType>("estado");
			Field<MesesInputType>("meses");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}