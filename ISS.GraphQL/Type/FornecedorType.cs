using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FornecedorType : ObjectGraphType<Fornecedor>
    {
        public FornecedorType()
        {
            // Defining the name of the object
            Name = "fornecedor";

            Field(x => x.IdFornecedor, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodFornecedor, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class FornecedorInputType : InputObjectGraphType
	{
		public FornecedorInputType()
		{
			// Defining the name of the object
			Name = "fornecedorInput";
			
            //Field<StringGraphType>("idFornecedor");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codFornecedor");
			Field<StringGraphType>("sinistroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("apoliceId");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}