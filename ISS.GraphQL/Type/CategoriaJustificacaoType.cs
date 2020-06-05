using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriaJustificacaoType : ObjectGraphType<CategoriaJustificacao>
    {
        public CategoriaJustificacaoType()
        {
            // Defining the name of the object
            Name = "categoriaJustificacao";

            Field(x => x.IdCategoriaJustificacao, nullable: true);
            Field(x => x.Categoria, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<JustificacaoType>>("justificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Justificacao>(x => x.Where(e => e.HasValue(c.Source.IdCategoriaJustificacao)))));
            
        }
    }

    public class CategoriaJustificacaoInputType : InputObjectGraphType
	{
		public CategoriaJustificacaoInputType()
		{
			// Defining the name of the object
			Name = "categoriaJustificacaoInput";
			
            //Field<StringGraphType>("idCategoriaJustificacao");
			Field<StringGraphType>("categoria");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<JustificacaoInputType>>("justificacao");
			
		}
	}
}