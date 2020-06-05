using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NotaType : ObjectGraphType<Nota>
    {
        public NotaType()
        {
            // Defining the name of the object
            Name = "nota";

            Field(x => x.IdNota, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PrioridadeId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.CategoriaId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodNota, nullable: true);
            FieldAsync<CategoriaTarefaType>("categoria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaTarefa>(c.Source.CategoriaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PrioridadeType>("prioridade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Prioridade>(c.Source.PrioridadeId)));
            FieldAsync<OperacoesPagamentoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesPagamento>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<SubscricaoCessaoRetencaoType>>("subscricaoCessaoRetencao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubscricaoCessaoRetencao>(x => x.Where(e => e.HasValue(c.Source.IdNota)))));
            
        }
    }

    public class NotaInputType : InputObjectGraphType
	{
		public NotaInputType()
		{
			// Defining the name of the object
			Name = "notaInput";
			
            //Field<StringGraphType>("idNota");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("prioridadeId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<StringGraphType>("categoriaId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codNota");
			Field<CategoriaTarefaInputType>("categoria");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<PrioridadeInputType>("prioridade");
			Field<OperacoesPagamentoInputType>("tipoOperacao");
			Field<ListGraphType<SubscricaoCessaoRetencaoInputType>>("subscricaoCessaoRetencao");
			
		}
	}
}