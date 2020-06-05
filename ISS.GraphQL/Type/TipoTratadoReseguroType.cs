using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoTratadoReseguroType : ObjectGraphType<TipoTratadoReseguro>
    {
        public TipoTratadoReseguroType()
        {
            // Defining the name of the object
            Name = "tipoTratadoReseguro";

            Field(x => x.IdTipoTratadoReseguro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoTratadoReseguro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoTratadoReseguroInputType : InputObjectGraphType
	{
		public TipoTratadoReseguroInputType()
		{
			// Defining the name of the object
			Name = "tipoTratadoReseguroInput";
			
            //Field<StringGraphType>("idTipoTratadoReseguro");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoTratadoReseguro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			
		}
	}
}