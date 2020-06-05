using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TitularidadeType : ObjectGraphType<Titularidade>
    {
        public TitularidadeType()
        {
            // Defining the name of the object
            Name = "titularidade";

            Field(x => x.IdTitularidade, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.Principal, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ContaFinanceiraId, nullable: true);
            FieldAsync<ContaFinanceiraType>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceiraId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class TitularidadeInputType : InputObjectGraphType
	{
		public TitularidadeInputType()
		{
			// Defining the name of the object
			Name = "titularidadeInput";
			
            //Field<StringGraphType>("idTitularidade");
			Field<StringGraphType>("pessoaId");
			Field<BooleanGraphType>("principal");
			Field<StringGraphType>("contaFinanceiraId");
			Field<ContaFinanceiraInputType>("contaFinanceira");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}