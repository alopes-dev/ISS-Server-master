using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class IdiomaPessoaType : ObjectGraphType<IdiomaPessoa>
    {
        public IdiomaPessoaType()
        {
            // Defining the name of the object
            Name = "idiomaPessoa";

            Field(x => x.IdIdiomaPessoa, nullable: true);
            Field(x => x.Principal, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.IdiomaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodIdiomaPessoa, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<IdiomasType>("idioma", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Idiomas>(c.Source.IdiomaId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class IdiomaPessoaInputType : InputObjectGraphType
	{
		public IdiomaPessoaInputType()
		{
			// Defining the name of the object
			Name = "idiomaPessoaInput";
			
            //Field<StringGraphType>("idIdiomaPessoa");
			Field<BooleanGraphType>("principal");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("idiomaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codIdiomaPessoa");
			Field<EstadoInputType>("estado");
			Field<IdiomasInputType>("idioma");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}