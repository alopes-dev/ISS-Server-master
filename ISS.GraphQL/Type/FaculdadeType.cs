using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FaculdadeType : ObjectGraphType<Faculdade>
    {
        public FaculdadeType()
        {
            // Defining the name of the object
            Name = "faculdade";

            Field(x => x.IdFaculdade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.InstitutoSuperiorId, nullable: true);
            Field(x => x.CodFaculdade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<InstitutoSuperiorType>("institutoSuperior", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InstitutoSuperior>(c.Source.InstitutoSuperiorId)));
            FieldAsync<ListGraphType<FaculdadeCursoType>>("faculdadeCurso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FaculdadeCurso>(x => x.Where(e => e.HasValue(c.Source.IdFaculdade)))));
            
        }
    }

    public class FaculdadeInputType : InputObjectGraphType
	{
		public FaculdadeInputType()
		{
			// Defining the name of the object
			Name = "faculdadeInput";
			
            //Field<StringGraphType>("idFaculdade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("institutoSuperiorId");
			Field<StringGraphType>("codFaculdade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<InstitutoSuperiorInputType>("institutoSuperior");
			Field<ListGraphType<FaculdadeCursoInputType>>("faculdadeCurso");
			
		}
	}
}