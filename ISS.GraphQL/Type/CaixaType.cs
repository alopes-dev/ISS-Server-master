using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CaixaType : ObjectGraphType<Caixa>
    {
        public CaixaType()
        {
            // Defining the name of the object
            Name = "caixa";

            Field(x => x.IdCaixa, nullable: true);
            Field(x => x.CodCaixa, nullable: true);
            Field(x => x.ClassificacaoCaixaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoRecebimentoId, nullable: true);
            Field(x => x.FuncionarioId, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.FormaPagamentoId, nullable: true);
            FieldAsync<ClassificacaoCaixaType>("classificacaoCaixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoCaixa>(c.Source.ClassificacaoCaixaId)));
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            FieldAsync<FuncionarioType>("funcionario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.FuncionarioId)));
            FieldAsync<TipoRecebimentoType>("tipoRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRecebimento>(c.Source.TipoRecebimentoId)));
            FieldAsync<ListGraphType<ComissionamentoType>>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(x => x.Where(e => e.HasValue(c.Source.IdCaixa)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdCaixa)))));
            
        }
    }

    public class CaixaInputType : InputObjectGraphType
	{
		public CaixaInputType()
		{
			// Defining the name of the object
			Name = "caixaInput";
			
            //Field<StringGraphType>("idCaixa");
			Field<StringGraphType>("codCaixa");
			Field<StringGraphType>("classificacaoCaixaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoRecebimentoId");
			Field<StringGraphType>("funcionarioId");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("formaPagamentoId");
			Field<ClassificacaoCaixaInputType>("classificacaoCaixa");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoInputType>("formaPagamento");
			Field<FuncionarioInputType>("funcionario");
			Field<TipoRecebimentoInputType>("tipoRecebimento");
			Field<ListGraphType<ComissionamentoInputType>>("comissionamento");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			
		}
	}
}