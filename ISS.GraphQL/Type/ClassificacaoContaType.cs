using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoContaType : ObjectGraphType<ClassificacaoConta>
    {
        public ClassificacaoContaType()
        {
            // Defining the name of the object
            Name = "classificacaoConta";

            Field(x => x.IdClassificacaoConta, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodClassificacaoConta, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PlanoContasType>>("planoContas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoConta)))));
            
        }
    }

    public class ClassificacaoContaInputType : InputObjectGraphType
	{
		public ClassificacaoContaInputType()
		{
			// Defining the name of the object
			Name = "classificacaoContaInput";
			
            //Field<StringGraphType>("idClassificacaoConta");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codClassificacaoConta");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PlanoContasInputType>>("planoContas");
			
		}
	}
}