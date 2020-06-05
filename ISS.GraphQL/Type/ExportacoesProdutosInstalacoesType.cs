using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExportacoesProdutosInstalacoesType : ObjectGraphType<ExportacoesProdutosInstalacoes>
    {
        public ExportacoesProdutosInstalacoesType()
        {
            // Defining the name of the object
            Name = "exportacoesProdutosInstalacoes";

            Field(x => x.IdExportacaoProdutosInstalacoes, nullable: true);
            Field(x => x.ParaEuacanada, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstimativaAnual, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.PaisId, nullable: true);
            Field(x => x.ProdutoInstalacaoId, nullable: true);
            Field(x => x.CodExportacoesProdutosInstalacoes, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PaisType>("pais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisId)));
            FieldAsync<ProdutosInstalacoesType>("produtoInstalacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProdutosInstalacoes>(c.Source.ProdutoInstalacaoId)));
            
        }
    }

    public class ExportacoesProdutosInstalacoesInputType : InputObjectGraphType
	{
		public ExportacoesProdutosInstalacoesInputType()
		{
			// Defining the name of the object
			Name = "exportacoesProdutosInstalacoesInput";
			
            //Field<StringGraphType>("idExportacaoProdutosInstalacoes");
			Field<BooleanGraphType>("paraEuacanada");
			Field<FloatGraphType>("estimativaAnual");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("paisId");
			Field<StringGraphType>("produtoInstalacaoId");
			Field<StringGraphType>("codExportacoesProdutosInstalacoes");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<PaisInputType>("pais");
			Field<ProdutosInstalacoesInputType>("produtoInstalacao");
			
		}
	}
}