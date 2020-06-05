using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoConsultaType : ObjectGraphType<TipoConsulta>
    {
        public TipoConsultaType()
        {
            // Defining the name of the object
            Name = "tipoConsulta";

            Field(x => x.IdTipoConsulta, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoConsulta, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AtosMedicosType>>("atosMedicos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AtosMedicos>(x => x.Where(e => e.HasValue(c.Source.IdTipoConsulta)))));
            FieldAsync<ListGraphType<LocalConsultaType>>("localConsulta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalConsulta>(x => x.Where(e => e.HasValue(c.Source.IdTipoConsulta)))));
            
        }
    }

    public class TipoConsultaInputType : InputObjectGraphType
	{
		public TipoConsultaInputType()
		{
			// Defining the name of the object
			Name = "tipoConsultaInput";
			
            //Field<StringGraphType>("idTipoConsulta");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoConsulta");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AtosMedicosInputType>>("atosMedicos");
			Field<ListGraphType<LocalConsultaInputType>>("localConsulta");
			
		}
	}
}