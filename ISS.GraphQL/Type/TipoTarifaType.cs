using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoTarifaType : ObjectGraphType<TipoTarifa>
    {
        public TipoTarifaType()
        {
            // Defining the name of the object
            Name = "tipoTarifa";

            Field(x => x.IdTipoTarifa, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoTarifa, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true);
            Field(x => x.DataActualizacao, nullable: true);
            Field(x => x.PrecarioProdutoId, nullable: true);
            Field(x => x.ClassificacaoAutomovelId, nullable: true);
            FieldAsync<ClassificacaoAutomovelType>("classificacaoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAutomovel>(c.Source.ClassificacaoAutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PrecarioProdutoType>("precarioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecarioProduto>(c.Source.PrecarioProdutoId)));
            FieldAsync<ListGraphType<TarifaType>>("tarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarifa>(x => x.Where(e => e.HasValue(c.Source.IdTipoTarifa)))));
            FieldAsync<ListGraphType<TipoTarifaPlanoProdutoType>>("tipoTarifaPlanoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTarifaPlanoProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipoTarifa)))));
            
        }
    }

    public class TipoTarifaInputType : InputObjectGraphType
	{
		public TipoTarifaInputType()
		{
			// Defining the name of the object
			Name = "tipoTarifaInput";
			
            //Field<StringGraphType>("idTipoTarifa");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoTarifa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("dataCriacao");
			Field<StringGraphType>("dataActualizacao");
			Field<StringGraphType>("precarioProdutoId");
			Field<StringGraphType>("classificacaoAutomovelId");
			Field<ClassificacaoAutomovelInputType>("classificacaoAutomovel");
			Field<EstadoInputType>("estado");
			Field<PrecarioProdutoInputType>("precarioProduto");
			Field<ListGraphType<TarifaInputType>>("tarifa");
			Field<ListGraphType<TipoTarifaPlanoProdutoInputType>>("tipoTarifaPlanoProduto");
			
		}
	}
}