using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PremiosMinimosType : ObjectGraphType<PremiosMinimos>
    {
        public PremiosMinimosType()
        {
            // Defining the name of the object
            Name = "premiosMinimos";

            Field(x => x.IdPremiosMinimos, nullable: true);
            Field(x => x.Duracao, nullable: true, type: typeof(IntGraphType));
            Field(x => x.PremioMinimo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescricaoPremio, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodPremiosMinimos, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            
        }
    }

    public class PremiosMinimosInputType : InputObjectGraphType
	{
		public PremiosMinimosInputType()
		{
			// Defining the name of the object
			Name = "premiosMinimosInput";
			
            //Field<StringGraphType>("idPremiosMinimos");
			Field<IntGraphType>("duracao");
			Field<FloatGraphType>("premioMinimo");
			Field<StringGraphType>("descricaoPremio");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codPremiosMinimos");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<MoedaInputType>("moeda");
			Field<ProdutoInputType>("produto");
			
		}
	}
}