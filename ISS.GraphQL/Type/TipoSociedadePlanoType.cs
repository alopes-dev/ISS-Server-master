using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSociedadePlanoType : ObjectGraphType<TipoSociedadePlano>
    {
        public TipoSociedadePlanoType()
        {
            // Defining the name of the object
            Name = "tipoSociedadePlano";

            Field(x => x.IdTipoSociedadePlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.TipoSociedadeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoSociedadeType>("tipoSociedade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSociedade>(c.Source.TipoSociedadeId)));
            
        }
    }

    public class TipoSociedadePlanoInputType : InputObjectGraphType
	{
		public TipoSociedadePlanoInputType()
		{
			// Defining the name of the object
			Name = "tipoSociedadePlanoInput";
			
            //Field<StringGraphType>("idTipoSociedadePlano");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("tipoSociedadeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoSociedadeInputType>("tipoSociedade");
			
		}
	}
}