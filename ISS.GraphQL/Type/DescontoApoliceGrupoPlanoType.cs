using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoApoliceGrupoPlanoType : ObjectGraphType<DescontoApoliceGrupoPlano>
    {
        public DescontoApoliceGrupoPlanoType()
        {
            // Defining the name of the object
            Name = "descontoApoliceGrupoPlano";

            Field(x => x.IdDescontoApoliceGrupoPlano, nullable: true);
            Field(x => x.CodDescontoApoliceGrupoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DescontoApoliceGrupoId, nullable: true);
            FieldAsync<DescontoApoliceGrupoType>("descontoApoliceGrupo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoApoliceGrupo>(c.Source.DescontoApoliceGrupoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DescontoApoliceGrupoPlanoInputType : InputObjectGraphType
	{
		public DescontoApoliceGrupoPlanoInputType()
		{
			// Defining the name of the object
			Name = "descontoApoliceGrupoPlanoInput";
			
            //Field<StringGraphType>("idDescontoApoliceGrupoPlano");
			Field<StringGraphType>("codDescontoApoliceGrupoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("descontoApoliceGrupoId");
			Field<DescontoApoliceGrupoInputType>("descontoApoliceGrupo");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}