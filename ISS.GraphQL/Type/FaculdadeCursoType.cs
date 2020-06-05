using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FaculdadeCursoType : ObjectGraphType<FaculdadeCurso>
    {
        public FaculdadeCursoType()
        {
            // Defining the name of the object
            Name = "faculdadeCurso";

            Field(x => x.IdFaculdadeCurso, nullable: true);
            Field(x => x.FaculdadeId, nullable: true);
            Field(x => x.CursoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CursosType>("curso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cursos>(c.Source.CursoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FaculdadeType>("faculdade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Faculdade>(c.Source.FaculdadeId)));
            FieldAsync<ListGraphType<HabilitacoesLiterariasPessoaType>>("habilitacoesLiterariasPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HabilitacoesLiterariasPessoa>(x => x.Where(e => e.HasValue(c.Source.IdFaculdadeCurso)))));
            
        }
    }

    public class FaculdadeCursoInputType : InputObjectGraphType
	{
		public FaculdadeCursoInputType()
		{
			// Defining the name of the object
			Name = "faculdadeCursoInput";
			
            //Field<StringGraphType>("idFaculdadeCurso");
			Field<StringGraphType>("faculdadeId");
			Field<StringGraphType>("cursoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CursosInputType>("curso");
			Field<EstadoInputType>("estado");
			Field<FaculdadeInputType>("faculdade");
			Field<ListGraphType<HabilitacoesLiterariasPessoaInputType>>("habilitacoesLiterariasPessoa");
			
		}
	}
}