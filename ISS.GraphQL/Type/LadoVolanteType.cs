using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LadoVolanteType : ObjectGraphType<LadoVolante>
    {
        public LadoVolanteType()
        {
            // Defining the name of the object
            Name = "ladoVolante";

            Field(x => x.IdLadoVolante, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodLadoVolante, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdLadoVolante)))));
            
        }
    }

    public class LadoVolanteInputType : InputObjectGraphType
	{
		public LadoVolanteInputType()
		{
			// Defining the name of the object
			Name = "ladoVolanteInput";
			
            //Field<StringGraphType>("idLadoVolante");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codLadoVolante");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			
		}
	}
}