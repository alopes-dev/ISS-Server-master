using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CriterioComissionamentoType : ObjectGraphType<CriterioComissionamento>
    {
        public CriterioComissionamentoType()
        {
            // Defining the name of the object
            Name = "criterioComissionamento";

            Field(x => x.IdCriterioComissionamento, nullable: true);
            Field(x => x.ComissionamentoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.SegmentoPlanoId, nullable: true);
            Field(x => x.LimiteComissionamentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodCriterioComissionamento, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoSegmentoPlanoType>("segmentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoPlano>(c.Source.SegmentoPlanoId)));
            FieldAsync<ListGraphType<CanalComissionamentoType>>("canalComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdCriterioComissionamento)))));
            FieldAsync<ListGraphType<FidelizacaoComissionamentoType>>("fidelizacaoComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FidelizacaoComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdCriterioComissionamento)))));
            FieldAsync<ListGraphType<ProvinciaComissionamentoType>>("provinciaComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProvinciaComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdCriterioComissionamento)))));
            FieldAsync<ListGraphType<TipoSegmentoComissionamentoType>>("tipoSegmentoComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdCriterioComissionamento)))));
            
        }
    }

    public class CriterioComissionamentoInputType : InputObjectGraphType
	{
		public CriterioComissionamentoInputType()
		{
			// Defining the name of the object
			Name = "criterioComissionamentoInput";
			
            //Field<StringGraphType>("idCriterioComissionamento");
			Field<StringGraphType>("comissionamentoId");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("segmentoPlanoId");
			Field<StringGraphType>("limiteComissionamentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codCriterioComissionamento");
			Field<CanalInputType>("canal");
			Field<EstadoInputType>("estado");
			Field<TipoSegmentoPlanoInputType>("segmentoPlano");
			Field<ListGraphType<CanalComissionamentoInputType>>("canalComissionamento");
			Field<ListGraphType<FidelizacaoComissionamentoInputType>>("fidelizacaoComissionamento");
			Field<ListGraphType<ProvinciaComissionamentoInputType>>("provinciaComissionamento");
			Field<ListGraphType<TipoSegmentoComissionamentoInputType>>("tipoSegmentoComissionamento");
			
		}
	}
}