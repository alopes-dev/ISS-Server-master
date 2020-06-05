using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FaixaEtariaType : ObjectGraphType<FaixaEtaria>
    {
        public FaixaEtariaType()
        {
            // Defining the name of the object
            Name = "faixaEtaria";

            Field(x => x.IdFaixaEtaria, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.IdadeMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.IdadeMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdFaixaEtaria)))));
            
        }
    }

    public class FaixaEtariaInputType : InputObjectGraphType
	{
		public FaixaEtariaInputType()
		{
			// Defining the name of the object
			Name = "faixaEtariaInput";
			
            //Field<StringGraphType>("idFaixaEtaria");
			Field<StringGraphType>("designacao");
			Field<IntGraphType>("idadeMin");
			Field<IntGraphType>("idadeMax");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PessoaInputType>>("pessoa");
			
		}
	}
}