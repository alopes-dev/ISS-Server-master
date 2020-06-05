using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescaraterizacaoEventualType : ObjectGraphType<DescaraterizacaoEventual>
    {
        public DescaraterizacaoEventualType()
        {
            // Defining the name of the object
            Name = "descaraterizacaoEventual";

            Field(x => x.IdDescaraterizacaoEventual, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodDescaraterizacaoEventual, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NumOrdem, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DescaraterizacaoEventualInputType : InputObjectGraphType
	{
		public DescaraterizacaoEventualInputType()
		{
			// Defining the name of the object
			Name = "descaraterizacaoEventualInput";
			
            //Field<StringGraphType>("idDescaraterizacaoEventual");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codDescaraterizacaoEventual");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("numOrdem");
			Field<StringGraphType>("planoProdutoId");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}