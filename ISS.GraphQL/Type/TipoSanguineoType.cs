using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSanguineoType : ObjectGraphType<TipoSanguineo>
    {
        public TipoSanguineoType()
        {
            // Defining the name of the object
            Name = "tipoSanguineo";

            Field(x => x.IdTipoSanguineo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodTipoSanguineo, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdTipoSanguineo)))));
            
        }
    }

    public class TipoSanguineoInputType : InputObjectGraphType
	{
		public TipoSanguineoInputType()
		{
			// Defining the name of the object
			Name = "tipoSanguineoInput";
			
            //Field<StringGraphType>("idTipoSanguineo");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codTipoSanguineo");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PessoaInputType>>("pessoa");
			
		}
	}
}