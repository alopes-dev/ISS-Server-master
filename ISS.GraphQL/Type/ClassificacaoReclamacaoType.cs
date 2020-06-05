using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoReclamacaoType : ObjectGraphType<ClassificacaoReclamacao>
    {
        public ClassificacaoReclamacaoType()
        {
            // Defining the name of the object
            Name = "classificacaoReclamacao";

            Field(x => x.IdClassificacaoReclamacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodClassificacaoReclamacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ReclamacaoType>>("reclamacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Reclamacao>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoReclamacao)))));
            
        }
    }

    public class ClassificacaoReclamacaoInputType : InputObjectGraphType
	{
		public ClassificacaoReclamacaoInputType()
		{
			// Defining the name of the object
			Name = "classificacaoReclamacaoInput";
			
            //Field<StringGraphType>("idClassificacaoReclamacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codClassificacaoReclamacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ReclamacaoInputType>>("reclamacao");
			
		}
	}
}