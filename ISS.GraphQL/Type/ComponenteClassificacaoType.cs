using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ComponenteClassificacaoType : ObjectGraphType<ComponenteClassificacao>
    {
        public ComponenteClassificacaoType()
        {
            // Defining the name of the object
            Name = "componenteClassificacao";

            Field(x => x.IdComponenteClassificacao, nullable: true);
            Field(x => x.ClassificacaoId, nullable: true);
            Field(x => x.ComponenteId, nullable: true);
            FieldAsync<ClassificacaoType>("classificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Classificacao>(c.Source.ClassificacaoId)));
            FieldAsync<ClassificacaoType>("componente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Classificacao>(c.Source.ComponenteId)));
            
        }
    }

    public class ComponenteClassificacaoInputType : InputObjectGraphType
	{
		public ComponenteClassificacaoInputType()
		{
			// Defining the name of the object
			Name = "componenteClassificacaoInput";
			
            //Field<StringGraphType>("idComponenteClassificacao");
			Field<StringGraphType>("classificacaoId");
			Field<StringGraphType>("componenteId");
			Field<ClassificacaoInputType>("classificacao");
			Field<ClassificacaoInputType>("componente");
			
		}
	}
}