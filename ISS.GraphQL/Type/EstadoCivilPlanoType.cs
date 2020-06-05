using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EstadoCivilPlanoType : ObjectGraphType<EstadoCivilPlano>
    {
        public EstadoCivilPlanoType()
        {
            // Defining the name of the object
            Name = "estadoCivilPlano";

            Field(x => x.IdEstadoCivilPlano, nullable: true);
            Field(x => x.CodEstadoCivilPlano, nullable: true);
            Field(x => x.EstadoCivilId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<EstadoCivilType>("estadoCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EstadoCivil>(c.Source.EstadoCivilId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class EstadoCivilPlanoInputType : InputObjectGraphType
	{
		public EstadoCivilPlanoInputType()
		{
			// Defining the name of the object
			Name = "estadoCivilPlanoInput";
			
            //Field<StringGraphType>("idEstadoCivilPlano");
			Field<StringGraphType>("codEstadoCivilPlano");
			Field<StringGraphType>("estadoCivilId");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<EstadoCivilInputType>("estadoCivil");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}