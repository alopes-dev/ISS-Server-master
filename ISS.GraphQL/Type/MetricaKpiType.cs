using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MetricaKpiType : ObjectGraphType<MetricaKpi>
    {
        public MetricaKpiType()
        {
            // Defining the name of the object
            Name = "metricaKpi";

            Field(x => x.IdMetricaKpi, nullable: true);
            Field(x => x.Pcfid, nullable: true);
            Field(x => x.HierarquiaId, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.IndiceDiferenca, nullable: true);
            Field(x => x.DetalheMudanca, nullable: true);
            Field(x => x.MetricaDisponivel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CategoriaMetricaKpid, nullable: true);
            FieldAsync<CategoriaMetricaKpiType>("categoriaMetricaKp", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaMetricaKpi>(c.Source.CategoriaMetricaKpid)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<MetricasProdutoType>>("metricasProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MetricasProduto>(x => x.Where(e => e.HasValue(c.Source.IdMetricaKpi)))));
            
        }
    }

    public class MetricaKpiInputType : InputObjectGraphType
	{
		public MetricaKpiInputType()
		{
			// Defining the name of the object
			Name = "metricaKpiInput";
			
            //Field<StringGraphType>("idMetricaKpi");
			Field<StringGraphType>("pcfid");
			Field<StringGraphType>("hierarquiaId");
			Field<StringGraphType>("nome");
			Field<StringGraphType>("indiceDiferenca");
			Field<StringGraphType>("detalheMudanca");
			Field<StringGraphType>("metricaDisponivel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("categoriaMetricaKpid");
			Field<CategoriaMetricaKpiInputType>("categoriaMetricaKp");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<MetricasProdutoInputType>>("metricasProduto");
			
		}
	}
}