using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LocalConsultaType : ObjectGraphType<LocalConsulta>
    {
        public LocalConsultaType()
        {
            // Defining the name of the object
            Name = "localConsulta";

            Field(x => x.IdLocalConsulta, nullable: true);
            Field(x => x.CodLocalConsulta, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActaulizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoConsultaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoConsultaType>("tipoConsulta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConsulta>(c.Source.TipoConsultaId)));
            
        }
    }

    public class LocalConsultaInputType : InputObjectGraphType
	{
		public LocalConsultaInputType()
		{
			// Defining the name of the object
			Name = "localConsultaInput";
			
            //Field<StringGraphType>("idLocalConsulta");
			Field<StringGraphType>("codLocalConsulta");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActaulizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoConsultaId");
			Field<EstadoInputType>("estado");
			Field<TipoConsultaInputType>("tipoConsulta");
			
		}
	}
}