using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoMatriculaType : ObjectGraphType<TipoMatricula>
    {
        public TipoMatriculaType()
        {
            // Defining the name of the object
            Name = "tipoMatricula";

            Field(x => x.IdTipoMatricula, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoMatricula, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdTipoMatricula)))));
            
        }
    }

    public class TipoMatriculaInputType : InputObjectGraphType
	{
		public TipoMatriculaInputType()
		{
			// Defining the name of the object
			Name = "tipoMatriculaInput";
			
            //Field<StringGraphType>("idTipoMatricula");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoMatricula");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			
		}
	}
}