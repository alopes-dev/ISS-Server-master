using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ComponenteSalarialPessoaType : ObjectGraphType<ComponenteSalarialPessoa>
    {
        public ComponenteSalarialPessoaType()
        {
            // Defining the name of the object
            Name = "componenteSalarialPessoa";

            Field(x => x.IdComponenteSalarialPessoa, nullable: true);
            Field(x => x.ValorSubsidio, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoSubsidioSalarialId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.IdSalarioPessoa, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<RendimentoPessoaType>("idSalarioPessoaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RendimentoPessoa>(c.Source.IdSalarioPessoa)));
            FieldAsync<TipoSubsidioSalarialType>("tipoSubsidioSalarial", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSubsidioSalarial>(c.Source.TipoSubsidioSalarialId)));
            
        }
    }

    public class ComponenteSalarialPessoaInputType : InputObjectGraphType
	{
		public ComponenteSalarialPessoaInputType()
		{
			// Defining the name of the object
			Name = "componenteSalarialPessoaInput";
			
            //Field<StringGraphType>("idComponenteSalarialPessoa");
			Field<FloatGraphType>("valorSubsidio");
			Field<StringGraphType>("tipoSubsidioSalarialId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("idSalarioPessoa");
			Field<EstadoInputType>("estado");
			Field<RendimentoPessoaInputType>("idSalarioPessoaNavigation");
			Field<TipoSubsidioSalarialInputType>("tipoSubsidioSalarial");
			
		}
	}
}