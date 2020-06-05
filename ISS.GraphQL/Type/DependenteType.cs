using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DependenteType : ObjectGraphType<Dependente>
    {
        public DependenteType()
        {
            // Defining the name of the object
            Name = "dependente";

            Field(x => x.IdDependente, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.PessoaDependenteId, nullable: true);
            Field(x => x.GrauParentescoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodDependente, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<GrauParentescoType>("grauParentesco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GrauParentesco>(c.Source.GrauParentescoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PessoaType>("pessoaDependente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaDependenteId)));
            
        }
    }

    public class DependenteInputType : InputObjectGraphType
	{
		public DependenteInputType()
		{
			// Defining the name of the object
			Name = "dependenteInput";
			
            //Field<StringGraphType>("idDependente");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("pessoaDependenteId");
			Field<StringGraphType>("grauParentescoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codDependente");
			Field<EstadoInputType>("estado");
			Field<GrauParentescoInputType>("grauParentesco");
			Field<PessoaInputType>("pessoa");
			Field<PessoaInputType>("pessoaDependente");
			
		}
	}
}