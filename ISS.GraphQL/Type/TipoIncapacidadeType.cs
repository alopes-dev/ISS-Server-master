using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoIncapacidadeType : ObjectGraphType<TipoIncapacidade>
    {
        public TipoIncapacidadeType()
        {
            // Defining the name of the object
            Name = "tipoIncapacidade";

            Field(x => x.IdTipoIncapacidade, nullable: true);
            Field(x => x.CodTipoIncapacidade, nullable: true);
            Field(x => x.NaturezaIncapacidade, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<IncapacidadePessoaType>>("incapacidadePessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<IncapacidadePessoa>(x => x.Where(e => e.HasValue(c.Source.IdTipoIncapacidade)))));
            
        }
    }

    public class TipoIncapacidadeInputType : InputObjectGraphType
	{
		public TipoIncapacidadeInputType()
		{
			// Defining the name of the object
			Name = "tipoIncapacidadeInput";
			
            //Field<StringGraphType>("idTipoIncapacidade");
			Field<StringGraphType>("codTipoIncapacidade");
			Field<StringGraphType>("naturezaIncapacidade");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<IncapacidadePessoaInputType>>("incapacidadePessoa");
			
		}
	}
}