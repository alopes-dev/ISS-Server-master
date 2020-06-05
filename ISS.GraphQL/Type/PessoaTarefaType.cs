using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PessoaTarefaType : ObjectGraphType<PessoaTarefa>
    {
        public PessoaTarefaType()
        {
            // Defining the name of the object
            Name = "pessoaTarefa";

            Field(x => x.IdPessoaTarefa, nullable: true);
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataUltAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Metrica, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TarefaId, nullable: true);
            Field(x => x.ResponsavelId, nullable: true);
            Field(x => x.DepartamentoId, nullable: true);
            Field(x => x.SeccaoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodPessoaTarefa, nullable: true);
            FieldAsync<DepartamentoType>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(c.Source.DepartamentoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<PessoaType>("responsavel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ResponsavelId)));
            FieldAsync<SeccaoType>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(c.Source.SeccaoId)));
            FieldAsync<TarefaType>("tarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarefa>(c.Source.TarefaId)));
            
        }
    }

    public class PessoaTarefaInputType : InputObjectGraphType
	{
		public PessoaTarefaInputType()
		{
			// Defining the name of the object
			Name = "pessoaTarefaInput";
			
            //Field<StringGraphType>("idPessoaTarefa");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFim");
			Field<DateTimeGraphType>("dataUltAtualizacao");
			Field<FloatGraphType>("metrica");
			Field<StringGraphType>("tarefaId");
			Field<StringGraphType>("responsavelId");
			Field<StringGraphType>("departamentoId");
			Field<StringGraphType>("seccaoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("produtoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codPessoaTarefa");
			Field<DepartamentoInputType>("departamento");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			Field<PessoaInputType>("responsavel");
			Field<SeccaoInputType>("seccao");
			Field<TarefaInputType>("tarefa");
			
		}
	}
}