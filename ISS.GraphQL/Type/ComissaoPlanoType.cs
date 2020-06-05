using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ComissaoPlanoType : ObjectGraphType<ComissaoPlano>
    {
        public ComissaoPlanoType()
        {
            // Defining the name of the object
            Name = "comissaoPlano";

            Field(x => x.IdComissao, nullable: true);
            Field(x => x.TaxaMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoComissaoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodComissao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PapelId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.DataCancelamento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAnulacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PremioSimple, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoRecebimentoId, nullable: true);
            Field(x => x.CentroCustoId, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.OperacaoId, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<CentroCustoType>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(c.Source.CentroCustoId)));
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<OperacaoType>("operacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Operacao>(c.Source.OperacaoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoComissaoType>("tipoComissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoComissao>(c.Source.TipoComissaoId)));
            FieldAsync<TipoRecebimentoType>("tipoRecebimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRecebimento>(c.Source.TipoRecebimentoId)));
            FieldAsync<ListGraphType<ComissaoResseguroType>>("comissaoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdComissao)))));
            
        }
    }

    public class ComissaoPlanoInputType : InputObjectGraphType
	{
		public ComissaoPlanoInputType()
		{
			// Defining the name of the object
			Name = "comissaoPlanoInput";
			
            //Field<StringGraphType>("idComissao");
			Field<FloatGraphType>("taxaMin");
			Field<FloatGraphType>("taxaMax");
			Field<StringGraphType>("tipoComissaoId");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codComissao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("papelId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<DateTimeGraphType>("dataCancelamento");
			Field<DateTimeGraphType>("dataAnulacao");
			Field<FloatGraphType>("premioSimple");
			Field<StringGraphType>("tipoRecebimentoId");
			Field<StringGraphType>("centroCustoId");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("operacaoId");
			Field<CanalInputType>("canal");
			Field<CentroCustoInputType>("centroCusto");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			Field<OperacaoInputType>("operacao");
			Field<PapelInputType>("papel");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoComissaoInputType>("tipoComissao");
			Field<TipoRecebimentoInputType>("tipoRecebimento");
			Field<ListGraphType<ComissaoResseguroInputType>>("comissaoResseguro");
			
		}
	}
}