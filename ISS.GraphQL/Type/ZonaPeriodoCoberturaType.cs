using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ZonaPeriodoCoberturaType : ObjectGraphType<ZonaPeriodoCobertura>
    {
        public ZonaPeriodoCoberturaType()
        {
            // Defining the name of the object
            Name = "zonaPeriodoCobertura";

            Field(x => x.IdZonaPeriodoCobertura, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodZonaPeriodoCobertura, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ZonaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.DiasPeriodoCobertura, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Plreuro, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ZonaType>("zona", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Zona>(c.Source.ZonaId)));
            
        }
    }

    public class ZonaPeriodoCoberturaInputType : InputObjectGraphType
	{
		public ZonaPeriodoCoberturaInputType()
		{
			// Defining the name of the object
			Name = "zonaPeriodoCoberturaInput";
			
            //Field<StringGraphType>("idZonaPeriodoCobertura");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codZonaPeriodoCobertura");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("zonaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("linhaProdutoId");
			Field<IntGraphType>("diasPeriodoCobertura");
			Field<FloatGraphType>("plreuro");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ZonaInputType>("zona");
			
		}
	}
}