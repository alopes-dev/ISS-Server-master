using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RiscoPlanoProdutoType : ObjectGraphType<RiscoPlanoProduto>
    {
        public RiscoPlanoProdutoType()
        {
            // Defining the name of the object
            Name = "riscoPlanoProduto";

            Field(x => x.IdRiscoPlanoProduto, nullable: true);
            Field(x => x.NivelRiscoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class RiscoPlanoProdutoInputType : InputObjectGraphType
	{
		public RiscoPlanoProdutoInputType()
		{
			// Defining the name of the object
			Name = "riscoPlanoProdutoInput";
			
            //Field<StringGraphType>("idRiscoPlanoProduto");
			Field<StringGraphType>("nivelRiscoId");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<NivelRiscoInputType>("nivelRisco");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}