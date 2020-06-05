using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContinenteType : ObjectGraphType<Continente>
    {
        public ContinenteType()
        {
            // Defining the name of the object
            Name = "continente";

            Field(x => x.IdContinente, nullable: true);
            Field(x => x.NomeContinente, nullable: true);
            Field(x => x.CodContinente, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ContinentePlanoType>>("continentePlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContinentePlano>(x => x.Where(e => e.HasValue(c.Source.IdContinente)))));
            FieldAsync<ListGraphType<PaisType>>("pais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(x => x.Where(e => e.HasValue(c.Source.IdContinente)))));
            
        }
    }

    public class ContinenteInputType : InputObjectGraphType
	{
		public ContinenteInputType()
		{
			// Defining the name of the object
			Name = "continenteInput";
			
            //Field<StringGraphType>("idContinente");
			Field<StringGraphType>("nomeContinente");
			Field<StringGraphType>("codContinente");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ContinentePlanoInputType>>("continentePlano");
			Field<ListGraphType<PaisInputType>>("pais");
			
		}
	}
}