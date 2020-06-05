using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FranquiaSeleccionadoType : ObjectGraphType<FranquiaSeleccionado>
    {
        public FranquiaSeleccionadoType()
        {
            // Defining the name of the object
            Name = "franquiaSeleccionado";

            Field(x => x.IdFranquiaSeleccionado, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.FranquiaId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FranquiaType>("franquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Franquia>(c.Source.FranquiaId)));
            
        }
    }

    public class FranquiaSeleccionadoInputType : InputObjectGraphType
	{
		public FranquiaSeleccionadoInputType()
		{
			// Defining the name of the object
			Name = "franquiaSeleccionadoInput";
			
            //Field<StringGraphType>("idFranquiaSeleccionado");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("cotacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("franquiaId");
			Field<ApoliceInputType>("apolice");
			Field<CotacaoInputType>("cotacao");
			Field<EstadoInputType>("estado");
			Field<FranquiaInputType>("franquia");
			
		}
	}
}