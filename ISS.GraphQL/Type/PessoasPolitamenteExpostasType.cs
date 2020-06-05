using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PessoasPolitamenteExpostasType : ObjectGraphType<PessoasPolitamenteExpostas>
    {
        public PessoasPolitamenteExpostasType()
        {
            // Defining the name of the object
            Name = "pessoasPolitamenteExpostas";

            Field(x => x.IdPpe, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodPessoasPolitamenteExpostas, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class PessoasPolitamenteExpostasInputType : InputObjectGraphType
	{
		public PessoasPolitamenteExpostasInputType()
		{
			// Defining the name of the object
			Name = "pessoasPolitamenteExpostasInput";
			
            //Field<StringGraphType>("idPpe");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codPessoasPolitamenteExpostas");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}