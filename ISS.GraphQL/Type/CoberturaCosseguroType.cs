using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoberturaCosseguroType : ObjectGraphType<CoberturaCosseguro>
    {
        public CoberturaCosseguroType()
        {
            // Defining the name of the object
            Name = "coberturaCosseguro";

            Field(x => x.IdCoberturaCosseguro, nullable: true);
            Field(x => x.CoberturaId, nullable: true);
            Field(x => x.CosseguroId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodCoberturaCosseguro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<CoberturaType>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaId)));
            FieldAsync<CoSeguroType>("cosseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoSeguro>(c.Source.CosseguroId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CoberturaCosseguroInputType : InputObjectGraphType
	{
		public CoberturaCosseguroInputType()
		{
			// Defining the name of the object
			Name = "coberturaCosseguroInput";
			
            //Field<StringGraphType>("idCoberturaCosseguro");
			Field<StringGraphType>("coberturaId");
			Field<StringGraphType>("cosseguroId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codCoberturaCosseguro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<CoberturaInputType>("cobertura");
			Field<CoSeguroInputType>("cosseguro");
			Field<EstadoInputType>("estado");
			
		}
	}
}