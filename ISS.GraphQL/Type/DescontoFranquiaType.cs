using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoFranquiaType : ObjectGraphType<DescontoFranquia>
    {
        public DescontoFranquiaType()
        {
            // Defining the name of the object
            Name = "descontoFranquia";

            Field(x => x.IdDescontoFranquia, nullable: true);
            Field(x => x.ValorFranquia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            
        }
    }

    public class DescontoFranquiaInputType : InputObjectGraphType
	{
		public DescontoFranquiaInputType()
		{
			// Defining the name of the object
			Name = "descontoFranquiaInput";
			
            //Field<StringGraphType>("idDescontoFranquia");
			Field<FloatGraphType>("valorFranquia");
			Field<FloatGraphType>("valorDesconto");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoCoberturaId");
			Field<EstadoInputType>("estado");
			Field<TipoCoberturaInputType>("tipoCobertura");
			
		}
	}
}