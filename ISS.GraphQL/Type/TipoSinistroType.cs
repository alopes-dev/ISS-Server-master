using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSinistroType : ObjectGraphType<TipoSinistro>
    {
        public TipoSinistroType()
        {
            // Defining the name of the object
            Name = "tipoSinistro";

            Field(x => x.IdTipoSinistro, nullable: true);
            Field(x => x.Tipo, nullable: true);
            Field(x => x.CodTipoSinistro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<SinistroType>>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(x => x.Where(e => e.HasValue(c.Source.IdTipoSinistro)))));
            
        }
    }

    public class TipoSinistroInputType : InputObjectGraphType
	{
		public TipoSinistroInputType()
		{
			// Defining the name of the object
			Name = "tipoSinistroInput";
			
            //Field<StringGraphType>("idTipoSinistro");
			Field<StringGraphType>("tipo");
			Field<StringGraphType>("codTipoSinistro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<SinistroInputType>>("sinistro");
			
		}
	}
}