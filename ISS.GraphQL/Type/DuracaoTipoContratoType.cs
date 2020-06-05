using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DuracaoTipoContratoType : ObjectGraphType<DuracaoTipoContrato>
    {
        public DuracaoTipoContratoType()
        {
            // Defining the name of the object
            Name = "duracaoTipoContrato";

            Field(x => x.IdDuracaoTipoContrato, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodDuracaoTipoContrato, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ContratoType>>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdDuracaoTipoContrato)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdDuracaoTipoContrato)))));
            FieldAsync<ListGraphType<DuracaoTipoContratoPlanoType>>("duracaoTipoContratoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DuracaoTipoContratoPlano>(x => x.Where(e => e.HasValue(c.Source.IdDuracaoTipoContrato)))));
            FieldAsync<ListGraphType<FraccionamentoType>>("fraccionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fraccionamento>(x => x.Where(e => e.HasValue(c.Source.IdDuracaoTipoContrato)))));
            FieldAsync<ListGraphType<PeriodoCalculoType>>("periodoCalculo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PeriodoCalculo>(x => x.Where(e => e.HasValue(c.Source.IdDuracaoTipoContrato)))));
            FieldAsync<ListGraphType<PeriodoPlanoType>>("periodoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PeriodoPlano>(x => x.Where(e => e.HasValue(c.Source.IdDuracaoTipoContrato)))));
            FieldAsync<ListGraphType<PrazosCurtosType>>("prazosCurtos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrazosCurtos>(x => x.Where(e => e.HasValue(c.Source.IdDuracaoTipoContrato)))));
            
        }
    }

    public class DuracaoTipoContratoInputType : InputObjectGraphType
	{
		public DuracaoTipoContratoInputType()
		{
			// Defining the name of the object
			Name = "duracaoTipoContratoInput";
			
            //Field<StringGraphType>("idDuracaoTipoContrato");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codDuracaoTipoContrato");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ContratoInputType>>("contrato");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<DuracaoTipoContratoPlanoInputType>>("duracaoTipoContratoPlano");
			Field<ListGraphType<FraccionamentoInputType>>("fraccionamento");
			Field<ListGraphType<PeriodoCalculoInputType>>("periodoCalculo");
			Field<ListGraphType<PeriodoPlanoInputType>>("periodoPlano");
			Field<ListGraphType<PrazosCurtosInputType>>("prazosCurtos");
			
		}
	}
}