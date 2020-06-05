using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriaLaboralType : ObjectGraphType<CategoriaLaboral>
    {
        public CategoriaLaboralType()
        {
            // Defining the name of the object
            Name = "categoriaLaboral";

            Field(x => x.IdCategoriaLaboral, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCategoriaLaboral, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<TarefaReparacaoType>>("tarefaReparacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefaReparacao>(x => x.Where(e => e.HasValue(c.Source.IdCategoriaLaboral)))));
            
        }
    }

    public class CategoriaLaboralInputType : InputObjectGraphType
	{
		public CategoriaLaboralInputType()
		{
			// Defining the name of the object
			Name = "categoriaLaboralInput";
			
            //Field<StringGraphType>("idCategoriaLaboral");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCategoriaLaboral");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<TarefaReparacaoInputType>>("tarefaReparacao");
			
		}
	}
}