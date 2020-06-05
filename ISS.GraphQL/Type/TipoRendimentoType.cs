using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoRendimentoType : ObjectGraphType<TipoRendimento>
    {
        public TipoRendimentoType()
        {
            // Defining the name of the object
            Name = "tipoRendimento";

            Field(x => x.IdTipoRendimento, nullable: true);
            Field(x => x.CodTipoRendimento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<RendimentoPessoaType>>("rendimentoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RendimentoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdTipoRendimento)))));
            
        }
    }

    public class TipoRendimentoInputType : InputObjectGraphType
	{
		public TipoRendimentoInputType()
		{
			// Defining the name of the object
			Name = "tipoRendimentoInput";
			
            //Field<StringGraphType>("idTipoRendimento");
			Field<StringGraphType>("codTipoRendimento");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<RendimentoPessoaInputType>>("rendimentoPessoa");
			
		}
	}
}