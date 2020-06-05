using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AnexosAutomovelType : ObjectGraphType<AnexosAutomovel>
    {
        public AnexosAutomovelType()
        {
            // Defining the name of the object
            Name = "anexosAutomovel";

            Field(x => x.IdAnexosAutomovel, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.AutomovelId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class AnexosAutomovelInputType : InputObjectGraphType
	{
		public AnexosAutomovelInputType()
		{
			// Defining the name of the object
			Name = "anexosAutomovelInput";
			
            //Field<StringGraphType>("idAnexosAutomovel");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("automovelId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<AutomovelInputType>("automovel");
			Field<EstadoInputType>("estado");
			
		}
	}
}