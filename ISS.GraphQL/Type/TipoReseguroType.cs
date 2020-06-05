using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoReseguroType : ObjectGraphType<TipoReseguro>
    {
        public TipoReseguroType()
        {
            // Defining the name of the object
            Name = "tipoReseguro";

            Field(x => x.IdTipoReseguro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoReseguro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoReseguroInputType : InputObjectGraphType
	{
		public TipoReseguroInputType()
		{
			// Defining the name of the object
			Name = "tipoReseguroInput";
			
            //Field<StringGraphType>("idTipoReseguro");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoReseguro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			
		}
	}
}