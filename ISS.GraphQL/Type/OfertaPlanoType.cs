using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OfertaPlanoType : ObjectGraphType<OfertaPlano>
    {
        public OfertaPlanoType()
        {
            // Defining the name of the object
            Name = "ofertaPlano";

            Field(x => x.IdOfertaPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.HistoricoOfertaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodOfertaPlano, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<HistoricoOfertaType>("historicoOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HistoricoOferta>(c.Source.HistoricoOfertaId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class OfertaPlanoInputType : InputObjectGraphType
	{
		public OfertaPlanoInputType()
		{
			// Defining the name of the object
			Name = "ofertaPlanoInput";
			
            //Field<StringGraphType>("idOfertaPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("historicoOfertaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codOfertaPlano");
			Field<StringGraphType>("moedaId");
			Field<EstadoInputType>("estado");
			Field<HistoricoOfertaInputType>("historicoOferta");
			Field<MoedaInputType>("moeda");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}