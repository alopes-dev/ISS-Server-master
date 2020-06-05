using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NaturezaMovimentoType : ObjectGraphType<NaturezaMovimento>
    {
        public NaturezaMovimentoType()
        {
            // Defining the name of the object
            Name = "naturezaMovimento";

            Field(x => x.IdNaturezaMovimento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodNaturezaMovimento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CanalType>>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<CoberturaType>>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<MoedaType>>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<PapelType>>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<PerdaType>>("perda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perda>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<PortfolioProdutoType>>("portfolioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PortfolioProduto>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<PremiosType>>("premios", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Premios>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<ProdutoType>>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<SegmentoProdutoType>>("segmentoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoProduto>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<TarifasAutomovelType>>("tarifasAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<TarifasDanosPropriosType>>("tarifasDanosProprios", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasDanosProprios>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<TarifasPremioAutoAcidentesTrabalhoType>>("tarifasPremioAutoAcidentesTrabalho", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasPremioAutoAcidentesTrabalho>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<TarifasPremioAutoAt2Type>>("tarifasPremioAutoAt2", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasPremioAutoAt2>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<TarifasResponsabilidadeCivilType>>("tarifasResponsabilidadeCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasResponsabilidadeCivil>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<TipoComissaoType>>("tipoComissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoComissao>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            FieldAsync<ListGraphType<TipoContaType>>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(x => x.Where(e => e.HasValue(c.Source.IdNaturezaMovimento)))));
            
        }
    }

    public class NaturezaMovimentoInputType : InputObjectGraphType
	{
		public NaturezaMovimentoInputType()
		{
			// Defining the name of the object
			Name = "naturezaMovimentoInput";
			
            //Field<StringGraphType>("idNaturezaMovimento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codNaturezaMovimento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CanalInputType>>("canal");
			Field<ListGraphType<CoberturaInputType>>("cobertura");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			Field<ListGraphType<MoedaInputType>>("moeda");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<PapelInputType>>("papel");
			Field<ListGraphType<PerdaInputType>>("perda");
			Field<ListGraphType<PortfolioProdutoInputType>>("portfolioProduto");
			Field<ListGraphType<PremiosInputType>>("premios");
			Field<ListGraphType<ProdutoInputType>>("produto");
			Field<ListGraphType<SegmentoProdutoInputType>>("segmentoProduto");
			Field<ListGraphType<TarifasAutomovelInputType>>("tarifasAutomovel");
			Field<ListGraphType<TarifasDanosPropriosInputType>>("tarifasDanosProprios");
			Field<ListGraphType<TarifasPremioAutoAcidentesTrabalhoInputType>>("tarifasPremioAutoAcidentesTrabalho");
			Field<ListGraphType<TarifasPremioAutoAt2InputType>>("tarifasPremioAutoAt2");
			Field<ListGraphType<TarifasResponsabilidadeCivilInputType>>("tarifasResponsabilidadeCivil");
			Field<ListGraphType<TipoComissaoInputType>>("tipoComissao");
			Field<ListGraphType<TipoContaInputType>>("tipoConta");
			
		}
	}
}