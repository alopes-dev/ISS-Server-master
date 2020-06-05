using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoberturaResseguroType : ObjectGraphType<CoberturaResseguro>
    {
        public CoberturaResseguroType()
        {
            // Defining the name of the object
            Name = "coberturaResseguro";

            Field(x => x.IdCobertura, nullable: true);
            Field(x => x.CoberturaId, nullable: true);
            Field(x => x.ResseguroId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodExcessoPerda, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<CoberturaType>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ResseguroType>("resseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Resseguro>(c.Source.ResseguroId)));
            
        }
    }

    public class CoberturaResseguroInputType : InputObjectGraphType
	{
		public CoberturaResseguroInputType()
		{
			// Defining the name of the object
			Name = "coberturaResseguroInput";
			
            //Field<StringGraphType>("idCobertura");
			Field<StringGraphType>("coberturaId");
			Field<StringGraphType>("resseguroId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codExcessoPerda");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<CoberturaInputType>("cobertura");
			Field<EstadoInputType>("estado");
			Field<ResseguroInputType>("resseguro");
			
		}
	}
}