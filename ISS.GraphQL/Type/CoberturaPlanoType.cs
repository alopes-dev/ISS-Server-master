using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoberturaPlanoType : ObjectGraphType<CoberturaPlano>
    {
        public CoberturaPlanoType()
        {
            // Defining the name of the object
            Name = "coberturaPlano";

            Field(x => x.IdCoberturaPlano, nullable: true);
            Field(x => x.PorAnuidade, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PorCadaSinistro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PorCadaPessoaSinistrada, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PorDanosCoisasAnimais, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Personalizado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ValorPersonalizado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CoPagamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.CoberturaId, nullable: true);
            Field(x => x.IsComplementar, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Preco, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.Nota, nullable: true);
            Field(x => x.TaxaCobertura, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Descricao, nullable: true);
            Field(x => x.NivelRiscoId, nullable: true);
            Field(x => x.PorCada, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.IsPadrao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsPrincipal, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<CoberturaType>("cobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<CoberturaSelecionadaType>>("coberturaSelecionada", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaSelecionada>(x => x.Where(e => e.HasValue(c.Source.IdCoberturaPlano)))));
            FieldAsync<ListGraphType<PremiosCoberturaAcidentesPessoaisType>>("premiosCoberturaAcidentesPessoais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PremiosCoberturaAcidentesPessoais>(x => x.Where(e => e.HasValue(c.Source.IdCoberturaPlano)))));
            
        }
    }

    public class CoberturaPlanoInputType : InputObjectGraphType
	{
		public CoberturaPlanoInputType()
		{
			// Defining the name of the object
			Name = "coberturaPlanoInput";
			
            //Field<StringGraphType>("idCoberturaPlano");
			Field<FloatGraphType>("porAnuidade");
			Field<FloatGraphType>("porCadaSinistro");
			Field<FloatGraphType>("porCadaPessoaSinistrada");
			Field<FloatGraphType>("porDanosCoisasAnimais");
			Field<BooleanGraphType>("personalizado");
			Field<FloatGraphType>("valorPersonalizado");
			Field<FloatGraphType>("coPagamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("coberturaId");
			Field<BooleanGraphType>("isComplementar");
			Field<FloatGraphType>("preco");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("nota");
			Field<FloatGraphType>("taxaCobertura");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("nivelRiscoId");
			Field<FloatGraphType>("porCada");
			Field<BooleanGraphType>("isPadrao");
			Field<BooleanGraphType>("isPrincipal");
			Field<CoberturaInputType>("cobertura");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<NivelRiscoInputType>("nivelRisco");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<CoberturaSelecionadaInputType>>("coberturaSelecionada");
			Field<ListGraphType<PremiosCoberturaAcidentesPessoaisInputType>>("premiosCoberturaAcidentesPessoais");
			
		}
	}
}