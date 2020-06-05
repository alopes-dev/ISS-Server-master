using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModalidadeAssegurarType : ObjectGraphType<ModalidadeAssegurar>
    {
        public ModalidadeAssegurarType()
        {
            // Defining the name of the object
            Name = "modalidadeAssegurar";

            Field(x => x.IdModalidadeAssegurar, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodModalidadeAssegurar, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CarenciaId, nullable: true);
            FieldAsync<CarenciaType>("carencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Carencia>(c.Source.CarenciaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ModalidadeAssegurarInputType : InputObjectGraphType
	{
		public ModalidadeAssegurarInputType()
		{
			// Defining the name of the object
			Name = "modalidadeAssegurarInput";
			
            //Field<StringGraphType>("idModalidadeAssegurar");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codModalidadeAssegurar");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("carenciaId");
			Field<CarenciaInputType>("carencia");
			Field<EstadoInputType>("estado");
			
		}
	}
}