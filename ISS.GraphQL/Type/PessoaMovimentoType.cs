using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PessoaMovimentoType : ObjectGraphType<PessoaMovimento>
    {
        public PessoaMovimentoType()
        {
            // Defining the name of the object
            Name = "pessoaMovimento";

            Field(x => x.IdPessoaMovimento, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodPessoaMovimento, nullable: true);
            Field(x => x.MovimentoId, nullable: true);
            FieldAsync<PessoaType>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.MovimentoId)));
            
        }
    }

    public class PessoaMovimentoInputType : InputObjectGraphType
	{
		public PessoaMovimentoInputType()
		{
			// Defining the name of the object
			Name = "pessoaMovimentoInput";
			
            //Field<StringGraphType>("idPessoaMovimento");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codPessoaMovimento");
			Field<StringGraphType>("movimentoId");
			Field<PessoaInputType>("movimento");
			
		}
	}
}