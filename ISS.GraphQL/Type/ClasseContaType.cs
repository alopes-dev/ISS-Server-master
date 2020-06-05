using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClasseContaType : ObjectGraphType<ClasseConta>
    {
        public ClasseContaType()
        {
            // Defining the name of the object
            Name = "classeConta";

            Field(x => x.IdClasse, nullable: true);
            Field(x => x.NumClasse, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PlanoContasType>>("planoContas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(x => x.Where(e => e.HasValue(c.Source.IdClasse)))));
            
        }
    }

    public class ClasseContaInputType : InputObjectGraphType
	{
		public ClasseContaInputType()
		{
			// Defining the name of the object
			Name = "classeContaInput";
			
            //Field<StringGraphType>("idClasse");
			Field<StringGraphType>("numClasse");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PlanoContasInputType>>("planoContas");
			
		}
	}
}