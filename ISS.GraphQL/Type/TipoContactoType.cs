using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoContactoType : ObjectGraphType<TipoContacto>
    {
        public TipoContactoType()
        {
            // Defining the name of the object
            Name = "tipoContacto";

            Field(x => x.IdTipoContacto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoContacto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ContactoType>>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(x => x.Where(e => e.HasValue(c.Source.IdTipoContacto)))));
            
        }
    }

    public class TipoContactoInputType : InputObjectGraphType
	{
		public TipoContactoInputType()
		{
			// Defining the name of the object
			Name = "tipoContactoInput";
			
            //Field<StringGraphType>("idTipoContacto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoContacto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ContactoInputType>>("contacto");
			
		}
	}
}