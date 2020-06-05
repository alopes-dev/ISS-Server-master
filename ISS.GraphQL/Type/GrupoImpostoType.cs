using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GrupoImpostoType : ObjectGraphType<GrupoImposto>
    {
        public GrupoImpostoType()
        {
            // Defining the name of the object
            Name = "grupoImposto";

            Field(x => x.IdGrupoImposto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PeriodoAnualImpostoType>>("periodoAnualImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PeriodoAnualImposto>(x => x.Where(e => e.HasValue(c.Source.IdGrupoImposto)))));
            
        }
    }

    public class GrupoImpostoInputType : InputObjectGraphType
	{
		public GrupoImpostoInputType()
		{
			// Defining the name of the object
			Name = "grupoImpostoInput";
			
            //Field<StringGraphType>("idGrupoImposto");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PeriodoAnualImpostoInputType>>("periodoAnualImposto");
			
		}
	}
}