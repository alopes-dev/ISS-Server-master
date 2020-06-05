using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriaMetricaKpiType : ObjectGraphType<CategoriaMetricaKpi>
    {
        public CategoriaMetricaKpiType()
        {
            // Defining the name of the object
            Name = "categoriaMetricaKpi";

            Field(x => x.IdCategoriaMetricaKpi, nullable: true);
            Field(x => x.Pcfid, nullable: true);
            Field(x => x.HierarquiaId, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.IndiceDiferenca, nullable: true);
            Field(x => x.DetalheMudanca, nullable: true);
            Field(x => x.MetricaDisponivel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<MetricaKpiType>>("metricaKpi", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MetricaKpi>(x => x.Where(e => e.HasValue(c.Source.IdCategoriaMetricaKpi)))));
            
        }
    }

    public class CategoriaMetricaKpiInputType : InputObjectGraphType
	{
		public CategoriaMetricaKpiInputType()
		{
			// Defining the name of the object
			Name = "categoriaMetricaKpiInput";
			
            //Field<StringGraphType>("idCategoriaMetricaKpi");
			Field<StringGraphType>("pcfid");
			Field<StringGraphType>("hierarquiaId");
			Field<StringGraphType>("nome");
			Field<StringGraphType>("indiceDiferenca");
			Field<StringGraphType>("detalheMudanca");
			Field<StringGraphType>("metricaDisponivel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<MetricaKpiInputType>>("metricaKpi");
			
		}
	}
}