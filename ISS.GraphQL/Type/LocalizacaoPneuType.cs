using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LocalizacaoPneuType : ObjectGraphType<LocalizacaoPneu>
    {
        public LocalizacaoPneuType()
        {
            // Defining the name of the object
            Name = "localizacaoPneu";

            Field(x => x.IdLocalizacaoPneu, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodLocalizacaoPneu, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PneuType>>("pneu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pneu>(x => x.Where(e => e.HasValue(c.Source.IdLocalizacaoPneu)))));
            
        }
    }

    public class LocalizacaoPneuInputType : InputObjectGraphType
	{
		public LocalizacaoPneuInputType()
		{
			// Defining the name of the object
			Name = "localizacaoPneuInput";
			
            //Field<StringGraphType>("idLocalizacaoPneu");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codLocalizacaoPneu");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PneuInputType>>("pneu");
			
		}
	}
}