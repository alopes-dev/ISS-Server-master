using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoOperacaoProcessoLimiteCompetenciaType : ObjectGraphType<TipoOperacaoProcessoLimiteCompetencia>
    {
        public TipoOperacaoProcessoLimiteCompetenciaType()
        {
            // Defining the name of the object
            Name = "tipoOperacaoProcessoLimiteCompetencia";

            Field(x => x.IdTipoOperacaoProcessoLimiteCompetencia, nullable: true);
            Field(x => x.LimiteCompetenciaId, nullable: true);
            Field(x => x.CodTipoOperacaoProcessoLimiteCompetencia, nullable: true);
            Field(x => x.TipoOperacaoProcessoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LimiteCompetenciaType>("limiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteCompetencia>(c.Source.LimiteCompetenciaId)));
            FieldAsync<TipoOperacaoProcessoType>("tipoOperacaoProcesso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacaoProcesso>(c.Source.TipoOperacaoProcessoId)));
            
        }
    }

    public class TipoOperacaoProcessoLimiteCompetenciaInputType : InputObjectGraphType
	{
		public TipoOperacaoProcessoLimiteCompetenciaInputType()
		{
			// Defining the name of the object
			Name = "tipoOperacaoProcessoLimiteCompetenciaInput";
			
            //Field<StringGraphType>("idTipoOperacaoProcessoLimiteCompetencia");
			Field<StringGraphType>("limiteCompetenciaId");
			Field<StringGraphType>("codTipoOperacaoProcessoLimiteCompetencia");
			Field<StringGraphType>("tipoOperacaoProcessoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LimiteCompetenciaInputType>("limiteCompetencia");
			Field<TipoOperacaoProcessoInputType>("tipoOperacaoProcesso");
			
		}
	}
}