using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoApoliceGrupoType : ObjectGraphType<DescontoApoliceGrupo>
    {
        public DescontoApoliceGrupoType()
        {
            // Defining the name of the object
            Name = "descontoApoliceGrupo";

            Field(x => x.IdDescontoApoliceGrupo, nullable: true);
            Field(x => x.NumMaxPessoas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumMinPessoas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodDescontoApoliceGrupo, nullable: true);
            Field(x => x.DescontoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Obs, nullable: true);
            FieldAsync<DescontoType>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(c.Source.DescontoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<DescontoApoliceGrupoPlanoType>>("descontoApoliceGrupoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoApoliceGrupoPlano>(x => x.Where(e => e.HasValue(c.Source.IdDescontoApoliceGrupo)))));
            
        }
    }

    public class DescontoApoliceGrupoInputType : InputObjectGraphType
	{
		public DescontoApoliceGrupoInputType()
		{
			// Defining the name of the object
			Name = "descontoApoliceGrupoInput";
			
            //Field<StringGraphType>("idDescontoApoliceGrupo");
			Field<IntGraphType>("numMaxPessoas");
			Field<IntGraphType>("numMinPessoas");
			Field<StringGraphType>("codDescontoApoliceGrupo");
			Field<StringGraphType>("descontoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("obs");
			Field<DescontoInputType>("desconto");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<DescontoApoliceGrupoPlanoInputType>>("descontoApoliceGrupoPlano");
			
		}
	}
}