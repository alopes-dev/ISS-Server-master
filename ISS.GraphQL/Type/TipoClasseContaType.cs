using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoClasseContaType : ObjectGraphType<TipoClasseConta>
    {
        public TipoClasseContaType()
        {
            // Defining the name of the object
            Name = "tipoClasseConta";

            Field(x => x.IdTipoClasseConta, nullable: true);
            Field(x => x.CodTipoClasseConta, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PlanoContasType>>("planoContas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(x => x.Where(e => e.HasValue(c.Source.IdTipoClasseConta)))));
            
        }
    }

    public class TipoClasseContaInputType : InputObjectGraphType
	{
		public TipoClasseContaInputType()
		{
			// Defining the name of the object
			Name = "tipoClasseContaInput";
			
            //Field<StringGraphType>("idTipoClasseConta");
			Field<StringGraphType>("codTipoClasseConta");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PlanoContasInputType>>("planoContas");
			
		}
	}
}