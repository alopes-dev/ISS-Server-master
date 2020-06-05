using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SexoPlanoType : ObjectGraphType<SexoPlano>
    {
        public SexoPlanoType()
        {
            // Defining the name of the object
            Name = "sexoPlano";

            Field(x => x.IdSexoPlano, nullable: true);
            Field(x => x.SexoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<SexoType>("sexo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sexo>(c.Source.SexoId)));
            
        }
    }

    public class SexoPlanoInputType : InputObjectGraphType
	{
		public SexoPlanoInputType()
		{
			// Defining the name of the object
			Name = "sexoPlanoInput";
			
            //Field<StringGraphType>("idSexoPlano");
			Field<StringGraphType>("sexoId");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<SexoInputType>("sexo");
			
		}
	}
}