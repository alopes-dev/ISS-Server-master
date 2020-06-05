using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoMotorType : ObjectGraphType<TipoMotor>
    {
        public TipoMotorType()
        {
            // Defining the name of the object
            Name = "tipoMotor";

            Field(x => x.IdTipoMotor, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdTipoMotor)))));
            
        }
    }

    public class TipoMotorInputType : InputObjectGraphType
	{
		public TipoMotorInputType()
		{
			// Defining the name of the object
			Name = "tipoMotorInput";
			
            //Field<StringGraphType>("idTipoMotor");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			
		}
	}
}