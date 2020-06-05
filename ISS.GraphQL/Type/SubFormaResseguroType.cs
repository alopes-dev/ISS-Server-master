using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubFormaResseguroType : ObjectGraphType<SubFormaResseguro>
    {
        public SubFormaResseguroType()
        {
            // Defining the name of the object
            Name = "subFormaResseguro";

            Field(x => x.IdSubFormaResseguro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.FormaResseguroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodSubFormaResseguro, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaResseguroType>("formaResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaResseguro>(c.Source.FormaResseguroId)));
            
        }
    }

    public class SubFormaResseguroInputType : InputObjectGraphType
	{
		public SubFormaResseguroInputType()
		{
			// Defining the name of the object
			Name = "subFormaResseguroInput";
			
            //Field<StringGraphType>("idSubFormaResseguro");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("formaResseguroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codSubFormaResseguro");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<FormaResseguroInputType>("formaResseguro");
			
		}
	}
}