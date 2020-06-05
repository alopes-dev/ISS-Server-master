using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class IncapacidadeTemporariaType : ObjectGraphType<IncapacidadeTemporaria>
    {
        public IncapacidadeTemporariaType()
        {
            // Defining the name of the object
            Name = "incapacidadeTemporaria";

            Field(x => x.IdIncapacidadeTemporaria, nullable: true);
            Field(x => x.ParteCorpo, nullable: true);
            Field(x => x.PeriodoDia, nullable: true, type: typeof(IntGraphType));
            Field(x => x.TipoLesaoId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodIncapacidadeTemporaria, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<TipoLesaoType>("tipoLesao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoLesao>(c.Source.TipoLesaoId)));
            FieldAsync<ListGraphType<LesaoLesadoType>>("lesaoLesado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LesaoLesado>(x => x.Where(e => e.HasValue(c.Source.IdIncapacidadeTemporaria)))));
            
        }
    }

    public class IncapacidadeTemporariaInputType : InputObjectGraphType
	{
		public IncapacidadeTemporariaInputType()
		{
			// Defining the name of the object
			Name = "incapacidadeTemporariaInput";
			
            //Field<StringGraphType>("idIncapacidadeTemporaria");
			Field<StringGraphType>("parteCorpo");
			Field<IntGraphType>("periodoDia");
			Field<StringGraphType>("tipoLesaoId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codIncapacidadeTemporaria");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			Field<TipoLesaoInputType>("tipoLesao");
			Field<ListGraphType<LesaoLesadoInputType>>("lesaoLesado");
			
		}
	}
}