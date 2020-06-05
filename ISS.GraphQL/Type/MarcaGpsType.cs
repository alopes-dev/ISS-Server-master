using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MarcaGpsType : ObjectGraphType<MarcaGps>
    {
        public MarcaGpsType()
        {
            // Defining the name of the object
            Name = "marcaGps";

            Field(x => x.IdMarcaGps, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodMarcaGps, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ModeloGpsType>>("modeloGps", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModeloGps>(x => x.Where(e => e.HasValue(c.Source.IdMarcaGps)))));
            
        }
    }

    public class MarcaGpsInputType : InputObjectGraphType
	{
		public MarcaGpsInputType()
		{
			// Defining the name of the object
			Name = "marcaGpsInput";
			
            //Field<StringGraphType>("idMarcaGps");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codMarcaGps");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ModeloGpsInputType>>("modeloGps");
			
		}
	}
}