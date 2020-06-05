using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSegmentosComissionamentoType : ObjectGraphType<TipoSegmentosComissionamento>
    {
        public TipoSegmentosComissionamentoType()
        {
            // Defining the name of the object
            Name = "tipoSegmentosComissionamento";

            Field(x => x.IdTipoSegmentosComissionamento, nullable: true);
            Field(x => x.CodLimiteComissionamento, nullable: true);
            Field(x => x.TipoSegmentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ComissionamentoId, nullable: true);
            FieldAsync<ComissionamentoType>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(c.Source.ComissionamentoId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            
        }
    }

    public class TipoSegmentosComissionamentoInputType : InputObjectGraphType
	{
		public TipoSegmentosComissionamentoInputType()
		{
			// Defining the name of the object
			Name = "tipoSegmentosComissionamentoInput";
			
            //Field<StringGraphType>("idTipoSegmentosComissionamento");
			Field<StringGraphType>("codLimiteComissionamento");
			Field<StringGraphType>("tipoSegmentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("comissionamentoId");
			Field<ComissionamentoInputType>("comissionamento");
			Field<TipoSegmentoInputType>("tipoSegmento");
			
		}
	}
}