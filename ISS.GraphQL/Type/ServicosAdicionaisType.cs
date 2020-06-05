using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ServicosAdicionaisType : ObjectGraphType<ServicosAdicionais>
    {
        public ServicosAdicionaisType()
        {
            // Defining the name of the object
            Name = "servicosAdicionais";

            Field(x => x.IdServicosAdicionais, nullable: true);
            Field(x => x.Obs, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CodServicosAdicionais, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ServicoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CoberturaProdutoId, nullable: true);
            Field(x => x.Preco, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            FieldAsync<CoberturaType>("coberturaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaProdutoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ServicoType>("servico", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Servico>(c.Source.ServicoId)));
            
        }
    }

    public class ServicosAdicionaisInputType : InputObjectGraphType
	{
		public ServicosAdicionaisInputType()
		{
			// Defining the name of the object
			Name = "servicosAdicionaisInput";
			
            //Field<StringGraphType>("idServicosAdicionais");
			Field<StringGraphType>("obs");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("codServicosAdicionais");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("servicoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("coberturaProdutoId");
			Field<FloatGraphType>("preco");
			Field<StringGraphType>("moedaId");
			Field<CoberturaInputType>("coberturaProduto");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ServicoInputType>("servico");
			
		}
	}
}