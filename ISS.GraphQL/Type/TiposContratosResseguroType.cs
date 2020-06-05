using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TiposContratosResseguroType : ObjectGraphType<TiposContratosResseguro>
    {
        public TiposContratosResseguroType()
        {
            // Defining the name of the object
            Name = "tiposContratosResseguro";

            Field(x => x.IdTiposContratosResseguro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodTiposContratosResseguro, nullable: true);
            FieldAsync<ListGraphType<TiposContratosResseguroInformacoesTiposContratosResseguroType>>("tiposContratosResseguroInformacoesTiposContratosResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TiposContratosResseguroInformacoesTiposContratosResseguro>(x => x.Where(e => e.HasValue(c.Source.IdTiposContratosResseguro)))));
            
        }
    }

    public class TiposContratosResseguroInputType : InputObjectGraphType
	{
		public TiposContratosResseguroInputType()
		{
			// Defining the name of the object
			Name = "tiposContratosResseguroInput";
			
            //Field<StringGraphType>("idTiposContratosResseguro");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codTiposContratosResseguro");
			Field<ListGraphType<TiposContratosResseguroInformacoesTiposContratosResseguroInputType>>("tiposContratosResseguroInformacoesTiposContratosResseguro");
			
		}
	}
}