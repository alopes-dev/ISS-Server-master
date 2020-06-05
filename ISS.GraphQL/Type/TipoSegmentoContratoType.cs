using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSegmentoContratoType : ObjectGraphType<TipoSegmentoContrato>
    {
        public TipoSegmentoContratoType()
        {
            // Defining the name of the object
            Name = "tipoSegmentoContrato";

            Field(x => x.IdTipoSegmentoContrato, nullable: true);
            Field(x => x.TipoSegmentoId, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.CodTipoSegmentoContrato, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            
        }
    }

    public class TipoSegmentoContratoInputType : InputObjectGraphType
	{
		public TipoSegmentoContratoInputType()
		{
			// Defining the name of the object
			Name = "tipoSegmentoContratoInput";
			
            //Field<StringGraphType>("idTipoSegmentoContrato");
			Field<StringGraphType>("tipoSegmentoId");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("codTipoSegmentoContrato");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ContratoInputType>("contrato");
			Field<TipoSegmentoInputType>("tipoSegmento");
			
		}
	}
}