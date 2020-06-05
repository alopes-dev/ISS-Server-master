using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPerdaType : ObjectGraphType<TipoPerda>
    {
        public TipoPerdaType()
        {
            // Defining the name of the object
            Name = "tipoPerda";

            Field(x => x.IdTipoPerda, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoPerda, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PerdaType>>("perda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perda>(x => x.Where(e => e.HasValue(c.Source.IdTipoPerda)))));
            
        }
    }

    public class TipoPerdaInputType : InputObjectGraphType
	{
		public TipoPerdaInputType()
		{
			// Defining the name of the object
			Name = "tipoPerdaInput";
			
            //Field<StringGraphType>("idTipoPerda");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoPerda");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PerdaInputType>>("perda");
			
		}
	}
}