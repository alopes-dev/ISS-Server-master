using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CarenciaType : ObjectGraphType<Carencia>
    {
        public CarenciaType()
        {
            // Defining the name of the object
            Name = "carencia";

            Field(x => x.IdCarencia, nullable: true);
            Field(x => x.NumDias, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PlanoId, nullable: true);
            FieldAsync<PlanoProdutoType>("plano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoId)));
            FieldAsync<ListGraphType<ModalidadeAssegurarType>>("modalidadeAssegurar", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadeAssegurar>(x => x.Where(e => e.HasValue(c.Source.IdCarencia)))));
            
        }
    }

    public class CarenciaInputType : InputObjectGraphType
	{
		public CarenciaInputType()
		{
			// Defining the name of the object
			Name = "carenciaInput";
			
            //Field<StringGraphType>("idCarencia");
			Field<IntGraphType>("numDias");
			Field<FloatGraphType>("taxa");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("planoId");
			Field<PlanoProdutoInputType>("plano");
			Field<ListGraphType<ModalidadeAssegurarInputType>>("modalidadeAssegurar");
			
		}
	}
}