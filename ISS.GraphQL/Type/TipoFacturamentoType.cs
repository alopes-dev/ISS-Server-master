using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoFacturamentoType : ObjectGraphType<TipoFacturamento>
    {
        public TipoFacturamentoType()
        {
            // Defining the name of the object
            Name = "tipoFacturamento";

            Field(x => x.IdTipoFacturamento, nullable: true);
            Field(x => x.CodTipoFacturamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CanalType>>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(x => x.Where(e => e.HasValue(c.Source.IdTipoFacturamento)))));
            
        }
    }

    public class TipoFacturamentoInputType : InputObjectGraphType
	{
		public TipoFacturamentoInputType()
		{
			// Defining the name of the object
			Name = "tipoFacturamentoInput";
			
            //Field<StringGraphType>("idTipoFacturamento");
			Field<StringGraphType>("codTipoFacturamento");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CanalInputType>>("canal");
			
		}
	}
}