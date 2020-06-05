using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProcessoType : ObjectGraphType<Processo>
    {
        public ProcessoType()
        {
            // Defining the name of the object
            Name = "processo";

            Field(x => x.IdProcesso, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodProcesso, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ProcessoFuncionalidadeType>>("processoFuncionalidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProcessoFuncionalidade>(x => x.Where(e => e.HasValue(c.Source.IdProcesso)))));
            
        }
    }

    public class ProcessoInputType : InputObjectGraphType
	{
		public ProcessoInputType()
		{
			// Defining the name of the object
			Name = "processoInput";
			
            //Field<StringGraphType>("idProcesso");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codProcesso");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ProcessoFuncionalidadeInputType>>("processoFuncionalidade");
			
		}
	}
}