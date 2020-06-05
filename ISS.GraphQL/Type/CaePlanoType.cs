using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CaePlanoType : ObjectGraphType<CaePlano>
    {
        public CaePlanoType()
        {
            // Defining the name of the object
            Name = "caePlano";

            Field(x => x.IdCaePlano, nullable: true);
            Field(x => x.CaeId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodCaePlano, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.CaeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class CaePlanoInputType : InputObjectGraphType
	{
		public CaePlanoInputType()
		{
			// Defining the name of the object
			Name = "caePlanoInput";
			
            //Field<StringGraphType>("idCaePlano");
			Field<StringGraphType>("caeId");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codCaePlano");
			Field<StringGraphType>("estadoId");
			Field<CaeInputType>("cae");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}