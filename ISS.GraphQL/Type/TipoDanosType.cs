using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoDanosType : ObjectGraphType<TipoDanos>
    {
        public TipoDanosType()
        {
            // Defining the name of the object
            Name = "tipoDanos";

            Field(x => x.IdTipo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoDanos, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<LesadoType>>("lesado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Lesado>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            
        }
    }

    public class TipoDanosInputType : InputObjectGraphType
	{
		public TipoDanosInputType()
		{
			// Defining the name of the object
			Name = "tipoDanosInput";
			
            //Field<StringGraphType>("idTipo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoDanos");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<LesadoInputType>>("lesado");
			
		}
	}
}