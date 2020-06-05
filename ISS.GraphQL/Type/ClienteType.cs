using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClienteType : ObjectGraphType<Cliente>
    {
        public ClienteType()
        {
            // Defining the name of the object
            Name = "cliente";

            Field(x => x.IdCliente, nullable: true);
            Field(x => x.Preferencias, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.TipoClienteId, nullable: true);
            Field(x => x.FidelizacaoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.NumOrdemCliente, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodCliente, nullable: true);
            Field(x => x.Conta, nullable: true);
            Field(x => x.TipoContaId, nullable: true);
            Field(x => x.SubClasseId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FidelizacaoType>("fidelizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fidelizacao>(c.Source.FidelizacaoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoContasType>("subClasse", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubClasseId)));
            FieldAsync<TipoClienteType>("tipoCliente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCliente>(c.Source.TipoClienteId)));
            FieldAsync<TipoContaType>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(c.Source.TipoContaId)));
            FieldAsync<ListGraphType<ApoliceType>>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(x => x.Where(e => e.HasValue(c.Source.IdCliente)))));
            
        }
    }

    public class ClienteInputType : InputObjectGraphType
	{
		public ClienteInputType()
		{
			// Defining the name of the object
			Name = "clienteInput";
			
            //Field<StringGraphType>("idCliente");
			Field<BooleanGraphType>("preferencias");
			Field<StringGraphType>("tipoClienteId");
			Field<StringGraphType>("fidelizacaoId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<IntGraphType>("numOrdemCliente");
			Field<StringGraphType>("codCliente");
			Field<StringGraphType>("conta");
			Field<StringGraphType>("tipoContaId");
			Field<StringGraphType>("subClasseId");
			Field<EstadoInputType>("estado");
			Field<FidelizacaoInputType>("fidelizacao");
			Field<PessoaInputType>("pessoa");
			Field<PlanoContasInputType>("subClasse");
			Field<TipoClienteInputType>("tipoCliente");
			Field<TipoContaInputType>("tipoConta");
			Field<ListGraphType<ApoliceInputType>>("apolice");
			
		}
	}
}