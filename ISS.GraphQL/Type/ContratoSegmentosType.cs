using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratoSegmentosType : ObjectGraphType<ContratoSegmentos>
    {
        public ContratoSegmentosType()
        {
            // Defining the name of the object
            Name = "contratoSegmentos";

            Field(x => x.IdContratoSegmento, nullable: true);
            Field(x => x.CodContratoSegmento, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.TipoSegmentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            
        }
    }

    public class ContratoSegmentosInputType : InputObjectGraphType
	{
		public ContratoSegmentosInputType()
		{
			// Defining the name of the object
			Name = "contratoSegmentosInput";
			
            //Field<StringGraphType>("idContratoSegmento");
			Field<StringGraphType>("codContratoSegmento");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("tipoSegmentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ContratoInputType>("contrato");
			Field<TipoSegmentoInputType>("tipoSegmento");
			
		}
	}
}