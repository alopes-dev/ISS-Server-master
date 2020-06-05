using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SegmentoOfertaType : ObjectGraphType<SegmentoOferta>
    {
        public SegmentoOfertaType()
        {
            // Defining the name of the object
            Name = "segmentoOferta";

            Field(x => x.IdSegmentoOferta, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.OfertaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<OperacaoPlanoType>("oferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacaoPlano>(c.Source.OfertaId)));
            
        }
    }

    public class SegmentoOfertaInputType : InputObjectGraphType
	{
		public SegmentoOfertaInputType()
		{
			// Defining the name of the object
			Name = "segmentoOfertaInput";
			
            //Field<StringGraphType>("idSegmentoOferta");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("ofertaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CanalInputType>("canal");
			Field<EstadoInputType>("estado");
			Field<OperacaoPlanoInputType>("oferta");
			
		}
	}
}