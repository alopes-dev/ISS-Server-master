using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoOperacaoProcessoType : ObjectGraphType<TipoOperacaoProcesso>
    {
        public TipoOperacaoProcessoType()
        {
            // Defining the name of the object
            Name = "tipoOperacaoProcesso";

            Field(x => x.IdTipoOperacaoProcesso, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.CodTipoOperacaoProcesso, nullable: true);
            Field(x => x.ProcessoFuncionalidadeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ProcessoFuncionalidadeType>("processoFuncionalidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProcessoFuncionalidade>(c.Source.ProcessoFuncionalidadeId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<TipoOperacaoProcessoLimiteCompetenciaType>>("tipoOperacaoProcessoLimiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacaoProcessoLimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdTipoOperacaoProcesso)))));
            
        }
    }

    public class TipoOperacaoProcessoInputType : InputObjectGraphType
	{
		public TipoOperacaoProcessoInputType()
		{
			// Defining the name of the object
			Name = "tipoOperacaoProcessoInput";
			
            //Field<StringGraphType>("idTipoOperacaoProcesso");
			Field<StringGraphType>("tipoOperacaoId");
			Field<StringGraphType>("codTipoOperacaoProcesso");
			Field<StringGraphType>("processoFuncionalidadeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ProcessoFuncionalidadeInputType>("processoFuncionalidade");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<ListGraphType<TipoOperacaoProcessoLimiteCompetenciaInputType>>("tipoOperacaoProcessoLimiteCompetencia");
			
		}
	}
}