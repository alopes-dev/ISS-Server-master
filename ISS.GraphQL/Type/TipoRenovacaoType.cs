using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoRenovacaoType : ObjectGraphType<TipoRenovacao>
    {
        public TipoRenovacaoType()
        {
            // Defining the name of the object
            Name = "tipoRenovacao";

            Field(x => x.IdTipoRenovacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoRenovacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<RenovacaoApoliceType>>("renovacaoApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RenovacaoApolice>(x => x.Where(e => e.HasValue(c.Source.IdTipoRenovacao)))));
            
        }
    }

    public class TipoRenovacaoInputType : InputObjectGraphType
	{
		public TipoRenovacaoInputType()
		{
			// Defining the name of the object
			Name = "tipoRenovacaoInput";
			
            //Field<StringGraphType>("idTipoRenovacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoRenovacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<RenovacaoApoliceInputType>>("renovacaoApolice");
			
		}
	}
}