using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoOfertaType : ObjectGraphType<TipoOferta>
    {
        public TipoOfertaType()
        {
            // Defining the name of the object
            Name = "tipoOferta";

            Field(x => x.IdTipoOferta, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoOferta, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoOfertaInputType : InputObjectGraphType
	{
		public TipoOfertaInputType()
		{
			// Defining the name of the object
			Name = "tipoOfertaInput";
			
            //Field<StringGraphType>("idTipoOferta");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoOferta");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			
		}
	}
}