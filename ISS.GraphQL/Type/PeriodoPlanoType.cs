using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PeriodoPlanoType : ObjectGraphType<PeriodoPlano>
    {
        public PeriodoPlanoType()
        {
            // Defining the name of the object
            Name = "periodoPlano";

            Field(x => x.IdPeriodo, nullable: true);
            Field(x => x.PeriodoMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PeriodoMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodPeriodoPlano, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.DuracaoTipoContratoId, nullable: true);
            FieldAsync<DuracaoTipoContratoType>("duracaoTipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DuracaoTipoContrato>(c.Source.DuracaoTipoContratoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdPeriodo)))));
            FieldAsync<ListGraphType<PeriodoPlanoPlanoType>>("periodoPlanoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PeriodoPlanoPlano>(x => x.Where(e => e.HasValue(c.Source.IdPeriodo)))));
            FieldAsync<ListGraphType<ViagemType>>("viagem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Viagem>(x => x.Where(e => e.HasValue(c.Source.IdPeriodo)))));
            
        }
    }

    public class PeriodoPlanoInputType : InputObjectGraphType
	{
		public PeriodoPlanoInputType()
		{
			// Defining the name of the object
			Name = "periodoPlanoInput";
			
            //Field<StringGraphType>("idPeriodo");
			Field<IntGraphType>("periodoMin");
			Field<StringGraphType>("designacao");
			Field<IntGraphType>("periodoMax");
			Field<StringGraphType>("codPeriodoPlano");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("duracaoTipoContratoId");
			Field<DuracaoTipoContratoInputType>("duracaoTipoContrato");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<PeriodoPlanoPlanoInputType>>("periodoPlanoPlano");
			Field<ListGraphType<ViagemInputType>>("viagem");
			
		}
	}
}