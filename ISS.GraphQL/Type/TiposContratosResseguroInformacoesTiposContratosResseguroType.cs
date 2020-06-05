using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TiposContratosResseguroInformacoesTiposContratosResseguroType : ObjectGraphType<TiposContratosResseguroInformacoesTiposContratosResseguro>
    {
        public TiposContratosResseguroInformacoesTiposContratosResseguroType()
        {
            // Defining the name of the object
            Name = "tiposContratosResseguroInformacoesTiposContratosResseguro";

            Field(x => x.IdTiposContratosResseguroInformacoesTiposContratosResseguro, nullable: true);
            Field(x => x.TiposContratosResseguroId, nullable: true);
            Field(x => x.InformacoesTiposContratosResseguroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodTiposContratosResseguroInformacoesTiposContratosResseguro, nullable: true);
            FieldAsync<SubFormaResseguroInformacaoType>("informacoesTiposContratosResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubFormaResseguroInformacao>(c.Source.InformacoesTiposContratosResseguroId)));
            FieldAsync<TiposContratosResseguroType>("tiposContratosResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TiposContratosResseguro>(c.Source.TiposContratosResseguroId)));
            
        }
    }

    public class TiposContratosResseguroInformacoesTiposContratosResseguroInputType : InputObjectGraphType
	{
		public TiposContratosResseguroInformacoesTiposContratosResseguroInputType()
		{
			// Defining the name of the object
			Name = "tiposContratosResseguroInformacoesTiposContratosResseguroInput";
			
            //Field<StringGraphType>("idTiposContratosResseguroInformacoesTiposContratosResseguro");
			Field<StringGraphType>("tiposContratosResseguroId");
			Field<StringGraphType>("informacoesTiposContratosResseguroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codTiposContratosResseguroInformacoesTiposContratosResseguro");
			Field<SubFormaResseguroInformacaoInputType>("informacoesTiposContratosResseguro");
			Field<TiposContratosResseguroInputType>("tiposContratosResseguro");
			
		}
	}
}