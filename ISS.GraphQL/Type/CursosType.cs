using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CursosType : ObjectGraphType<Cursos>
    {
        public CursosType()
        {
            // Defining the name of the object
            Name = "cursos";

            Field(x => x.IdCurso, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCursos, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<FaculdadeCursoType>>("faculdadeCurso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FaculdadeCurso>(x => x.Where(e => e.HasValue(c.Source.IdCurso)))));
            
        }
    }

    public class CursosInputType : InputObjectGraphType
	{
		public CursosInputType()
		{
			// Defining the name of the object
			Name = "cursosInput";
			
            //Field<StringGraphType>("idCurso");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCursos");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<FaculdadeCursoInputType>>("faculdadeCurso");
			
		}
	}
}