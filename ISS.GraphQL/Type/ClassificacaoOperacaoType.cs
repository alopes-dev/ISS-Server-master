using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoOperacaoType : ObjectGraphType<ClassificacaoOperacao>
    {
        public ClassificacaoOperacaoType()
        {
            // Defining the name of the object
            Name = "classificacaoOperacao";

            Field(x => x.IdClassificacaoOperacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.CodClassificacaoOperacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<OperacoesPagamentoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesPagamento>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<OperacaoType>>("operacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Operacao>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoOperacao)))));
            
        }
    }

    public class ClassificacaoOperacaoInputType : InputObjectGraphType
	{
		public ClassificacaoOperacaoInputType()
		{
			// Defining the name of the object
			Name = "classificacaoOperacaoInput";
			
            //Field<StringGraphType>("idClassificacaoOperacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoOperacaoId");
			Field<StringGraphType>("codClassificacaoOperacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<OperacoesPagamentoInputType>("tipoOperacao");
			Field<ListGraphType<OperacaoInputType>>("operacao");
			
		}
	}
}