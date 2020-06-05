using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPessoaPlanoType : ObjectGraphType<TipoPessoaPlano>
    {
        public TipoPessoaPlanoType()
        {
            // Defining the name of the object
            Name = "tipoPessoaPlano";

            Field(x => x.IdPlanoTipoPessoa, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.TipoPessoaId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoPessoaType>("tipoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPessoa>(c.Source.TipoPessoaId)));
            
        }
    }

    public class TipoPessoaPlanoInputType : InputObjectGraphType
	{
		public TipoPessoaPlanoInputType()
		{
			// Defining the name of the object
			Name = "tipoPessoaPlanoInput";
			
            //Field<StringGraphType>("idPlanoTipoPessoa");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("tipoPessoaId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoPessoaInputType>("tipoPessoa");
			
		}
	}
}