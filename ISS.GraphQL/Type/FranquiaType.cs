using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FranquiaType : ObjectGraphType<Franquia>
    {
        public FranquiaType()
        {
            // Defining the name of the object
            Name = "franquia";

            Field(x => x.IdFranquia, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoFranquiaId, nullable: true);
            Field(x => x.CategoriaFranquiaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFranquia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Desconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CoberturaProdutoId, nullable: true);
            Field(x => x.CoberturasComplementaresId, nullable: true);
            Field(x => x.DiaMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DiaMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            FieldAsync<ListGraphType<CoberturaType>>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(x => x.Where(e => e.HasValue(c.Source.IdFranquia)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdFranquia)))));
            FieldAsync<ListGraphType<FranquiaSeleccionadoType>>("franquiaSeleccionado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FranquiaSeleccionado>(x => x.Where(e => e.HasValue(c.Source.IdFranquia)))));
            FieldAsync<ListGraphType<LocaisFranquiaType>>("locaisFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisFranquia>(x => x.Where(e => e.HasValue(c.Source.IdFranquia)))));
            FieldAsync<ListGraphType<SegmentoFranquiaType>>("segmentoFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoFranquia>(x => x.Where(e => e.HasValue(c.Source.IdFranquia)))));
            
        }
    }

    public class FranquiaInputType : InputObjectGraphType
	{
		public FranquiaInputType()
		{
			// Defining the name of the object
			Name = "franquiaInput";
			
            //Field<StringGraphType>("idFranquia");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<StringGraphType>("tipoFranquiaId");
			Field<StringGraphType>("categoriaFranquiaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFranquia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("desconto");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("coberturaProdutoId");
			Field<StringGraphType>("coberturasComplementaresId");
			Field<IntGraphType>("diaMin");
			Field<IntGraphType>("diaMax");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<StringGraphType>("subContaId");
			Field<ListGraphType<CoberturaInputType>>("cobertura");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<FranquiaSeleccionadoInputType>>("franquiaSeleccionado");
			Field<ListGraphType<LocaisFranquiaInputType>>("locaisFranquia");
			Field<ListGraphType<SegmentoFranquiaInputType>>("segmentoFranquia");
			
		}
	}
}