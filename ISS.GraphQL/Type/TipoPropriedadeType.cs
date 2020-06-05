using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPropriedadeType : ObjectGraphType<TipoPropriedade>
    {
        public TipoPropriedadeType()
        {
            // Defining the name of the object
            Name = "tipoPropriedade";

            Field(x => x.IdTipoPropriedade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoPropriedade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ConstrucaoType>>("construcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Construcao>(x => x.Where(e => e.HasValue(c.Source.IdTipoPropriedade)))));
            
        }
    }

    public class TipoPropriedadeInputType : InputObjectGraphType
	{
		public TipoPropriedadeInputType()
		{
			// Defining the name of the object
			Name = "tipoPropriedadeInput";
			
            //Field<StringGraphType>("idTipoPropriedade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoPropriedade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ConstrucaoInputType>>("construcao");
			
		}
	}
}