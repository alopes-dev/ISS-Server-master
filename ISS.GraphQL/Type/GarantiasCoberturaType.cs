using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GarantiasCoberturaType : ObjectGraphType<GarantiasCobertura>
    {
        public GarantiasCoberturaType()
        {
            // Defining the name of the object
            Name = "garantiasCobertura";

            Field(x => x.IdGarantia, nullable: true);
            Field(x => x.NumGarantia, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CoberturaProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CoberturaType>("coberturaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaProdutoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<GarantiasAfetasDespesasMedicasType>>("garantiasAfetasDespesasMedicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GarantiasAfetasDespesasMedicas>(x => x.Where(e => e.HasValue(c.Source.IdGarantia)))));
            
        }
    }

    public class GarantiasCoberturaInputType : InputObjectGraphType
	{
		public GarantiasCoberturaInputType()
		{
			// Defining the name of the object
			Name = "garantiasCoberturaInput";
			
            //Field<StringGraphType>("idGarantia");
			Field<IntGraphType>("numGarantia");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("coberturaProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CoberturaInputType>("coberturaProduto");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<GarantiasAfetasDespesasMedicasInputType>>("garantiasAfetasDespesasMedicas");
			
		}
	}
}