using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoTarifaPlanoProdutoType : ObjectGraphType<TipoTarifaPlanoProduto>
    {
        public TipoTarifaPlanoProdutoType()
        {
            // Defining the name of the object
            Name = "tipoTarifaPlanoProduto";

            Field(x => x.IdTipoTarifaPlanoProduto, nullable: true);
            Field(x => x.TipoTarifaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodTipoTarifaPlanoProduto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoTarifaType>("tipoTarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTarifa>(c.Source.TipoTarifaId)));
            
        }
    }

    public class TipoTarifaPlanoProdutoInputType : InputObjectGraphType
	{
		public TipoTarifaPlanoProdutoInputType()
		{
			// Defining the name of the object
			Name = "tipoTarifaPlanoProdutoInput";
			
            //Field<StringGraphType>("idTipoTarifaPlanoProduto");
			Field<StringGraphType>("tipoTarifaId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codTipoTarifaPlanoProduto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoTarifaInputType>("tipoTarifa");
			
		}
	}
}