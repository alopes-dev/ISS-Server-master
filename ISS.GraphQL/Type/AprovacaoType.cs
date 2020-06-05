using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AprovacaoType : ObjectGraphType<Aprovacao>
    {
        public AprovacaoType()
        {
            // Defining the name of the object
            Name = "aprovacao";

            Field(x => x.IdAprovacao, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataAprovacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataSubscricao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.AprovadorId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.NumeroAprovacao, nullable: true, type: typeof(IntGraphType));
            Field(x => x.PreponenteId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodAprovacao, nullable: true);
            FieldAsync<PessoaType>("aprovador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.AprovadorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("preponente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PreponenteId)));
            FieldAsync<OperacoesPagamentoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesPagamento>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<ClassificacaoAprovacaoType>>("classificacaoAprovacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAprovacao>(x => x.Where(e => e.HasValue(c.Source.IdAprovacao)))));
            
        }
    }

    public class AprovacaoInputType : InputObjectGraphType
	{
		public AprovacaoInputType()
		{
			// Defining the name of the object
			Name = "aprovacaoInput";
			
            //Field<StringGraphType>("idAprovacao");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataAprovacao");
			Field<DateTimeGraphType>("dataSubscricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("aprovadorId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<IntGraphType>("numeroAprovacao");
			Field<StringGraphType>("preponenteId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codAprovacao");
			Field<PessoaInputType>("aprovador");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("preponente");
			Field<OperacoesPagamentoInputType>("tipoOperacao");
			Field<ListGraphType<ClassificacaoAprovacaoInputType>>("classificacaoAprovacao");
			
		}
	}
}