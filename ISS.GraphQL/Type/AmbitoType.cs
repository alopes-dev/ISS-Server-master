using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AmbitoType : ObjectGraphType<Ambito>
    {
        public AmbitoType()
        {
            // Defining the name of the object
            Name = "ambito";

            Field(x => x.IdAmbito, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodAmbito, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NumOrdem, nullable: true, type: typeof(IntGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<SubPontoAmbitoType>>("subPontoAmbito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubPontoAmbito>(x => x.Where(e => e.HasValue(c.Source.IdAmbito)))));
            
        }
    }

    public class AmbitoInputType : InputObjectGraphType
	{
		public AmbitoInputType()
		{
			// Defining the name of the object
			Name = "ambitoInput";
			
            //Field<StringGraphType>("idAmbito");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codAmbito");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<IntGraphType>("numOrdem");
			Field<StringGraphType>("planoProdutoId");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<SubPontoAmbitoInputType>>("subPontoAmbito");
			
		}
	}
}