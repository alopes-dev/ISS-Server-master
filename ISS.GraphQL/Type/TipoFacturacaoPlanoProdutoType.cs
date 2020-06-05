using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoFacturacaoPlanoProdutoType : ObjectGraphType<TipoFacturacaoPlanoProduto>
    {
        public TipoFacturacaoPlanoProdutoType()
        {
            // Defining the name of the object
            Name = "tipoFacturacaoPlanoProduto";

            Field(x => x.IdTipoFacturacao, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.TipoFacturacaoId, nullable: true);
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoFacturacaoType>("tipoFacturacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoFacturacao>(c.Source.TipoFacturacaoId)));
            
        }
    }

    public class TipoFacturacaoPlanoProdutoInputType : InputObjectGraphType
	{
		public TipoFacturacaoPlanoProdutoInputType()
		{
			// Defining the name of the object
			Name = "tipoFacturacaoPlanoProdutoInput";
			
            //Field<StringGraphType>("idTipoFacturacao");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("tipoFacturacaoId");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoFacturacaoInputType>("tipoFacturacao");
			
		}
	}
}