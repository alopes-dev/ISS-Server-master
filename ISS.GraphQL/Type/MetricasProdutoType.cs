using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MetricasProdutoType : ObjectGraphType<MetricasProduto>
    {
        public MetricasProdutoType()
        {
            // Defining the name of the object
            Name = "metricasProduto";

            Field(x => x.IdMetricasProduto, nullable: true);
            Field(x => x.MetricaKpiId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodMetricasProduto, nullable: true);
            FieldAsync<MetricaKpiType>("metricaKpi", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MetricaKpi>(c.Source.MetricaKpiId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            
        }
    }

    public class MetricasProdutoInputType : InputObjectGraphType
	{
		public MetricasProdutoInputType()
		{
			// Defining the name of the object
			Name = "metricasProdutoInput";
			
            //Field<StringGraphType>("idMetricasProduto");
			Field<StringGraphType>("metricaKpiId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codMetricasProduto");
			Field<MetricaKpiInputType>("metricaKpi");
			Field<ProdutoInputType>("produto");
			
		}
	}
}