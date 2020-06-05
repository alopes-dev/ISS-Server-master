using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSubsidioSalarialType : ObjectGraphType<TipoSubsidioSalarial>
    {
        public TipoSubsidioSalarialType()
        {
            // Defining the name of the object
            Name = "tipoSubsidioSalarial";

            Field(x => x.IdTipoSubsidioSalarial, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodTipoSubsidioSalarial, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ComponenteSalarialPessoaType>>("componenteSalarialPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComponenteSalarialPessoa>(x => x.Where(e => e.HasValue(c.Source.IdTipoSubsidioSalarial)))));
            
        }
    }

    public class TipoSubsidioSalarialInputType : InputObjectGraphType
	{
		public TipoSubsidioSalarialInputType()
		{
			// Defining the name of the object
			Name = "tipoSubsidioSalarialInput";
			
            //Field<StringGraphType>("idTipoSubsidioSalarial");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codTipoSubsidioSalarial");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ComponenteSalarialPessoaInputType>>("componenteSalarialPessoa");
			
		}
	}
}