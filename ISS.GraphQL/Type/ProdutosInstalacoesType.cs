using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProdutosInstalacoesType : ObjectGraphType<ProdutosInstalacoes>
    {
        public ProdutosInstalacoesType()
        {
            // Defining the name of the object
            Name = "produtosInstalacoes";

            Field(x => x.IdProdutoInstalacao, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.EstimativaVendaAnuais, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.PaisFornecedorId, nullable: true);
            Field(x => x.CategoriaProdutoInstalacaoId, nullable: true);
            Field(x => x.InstalacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CategoriasProdutosInstalacoesType>("categoriaProdutoInstalacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriasProdutosInstalacoes>(c.Source.CategoriaProdutoInstalacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<InstalacoesType>("instalacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Instalacoes>(c.Source.InstalacaoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PaisType>("paisFornecedor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisFornecedorId)));
            FieldAsync<ListGraphType<ExportacoesProdutosInstalacoesType>>("exportacoesProdutosInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExportacoesProdutosInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdProdutoInstalacao)))));
            
        }
    }

    public class ProdutosInstalacoesInputType : InputObjectGraphType
	{
		public ProdutosInstalacoesInputType()
		{
			// Defining the name of the object
			Name = "produtosInstalacoesInput";
			
            //Field<StringGraphType>("idProdutoInstalacao");
			Field<StringGraphType>("nome");
			Field<FloatGraphType>("estimativaVendaAnuais");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("paisFornecedorId");
			Field<StringGraphType>("categoriaProdutoInstalacaoId");
			Field<StringGraphType>("instalacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CategoriasProdutosInstalacoesInputType>("categoriaProdutoInstalacao");
			Field<EstadoInputType>("estado");
			Field<InstalacoesInputType>("instalacao");
			Field<MoedaInputType>("moeda");
			Field<PaisInputType>("paisFornecedor");
			Field<ListGraphType<ExportacoesProdutosInstalacoesInputType>>("exportacoesProdutosInstalacoes");
			
		}
	}
}