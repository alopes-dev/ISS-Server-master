using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SegmentoFranquiaType : ObjectGraphType<SegmentoFranquia>
    {
        public SegmentoFranquiaType()
        {
            // Defining the name of the object
            Name = "segmentoFranquia";

            Field(x => x.IdSegmentoFranquia, nullable: true);
            Field(x => x.SegmentoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CaeId, nullable: true);
            Field(x => x.FranquiaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.CaeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FranquiaType>("franquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Franquia>(c.Source.FranquiaId)));
            FieldAsync<TipoSegmentoType>("segmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.SegmentoId)));
            
        }
    }

    public class SegmentoFranquiaInputType : InputObjectGraphType
	{
		public SegmentoFranquiaInputType()
		{
			// Defining the name of the object
			Name = "segmentoFranquiaInput";
			
            //Field<StringGraphType>("idSegmentoFranquia");
			Field<StringGraphType>("segmentoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("caeId");
			Field<StringGraphType>("franquiaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CaeInputType>("cae");
			Field<EstadoInputType>("estado");
			Field<FranquiaInputType>("franquia");
			Field<TipoSegmentoInputType>("segmento");
			
		}
	}
}