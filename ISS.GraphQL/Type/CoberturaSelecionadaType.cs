using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoberturaSelecionadaType : ObjectGraphType<CoberturaSelecionada>
    {
        public CoberturaSelecionadaType()
        {
            // Defining the name of the object
            Name = "coberturaSelecionada";

            Field(x => x.IdCoberturaSelecionada, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
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
            Field(x => x.CoberturaPlanoId, nullable: true);
            Field(x => x.NaturezaRisco, nullable: true);
            Field(x => x.ObjectoSeguradoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            FieldAsync<CoberturaPlanoType>("coberturaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaPlano>(c.Source.CoberturaPlanoId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<ObjectoSeguradoType>("objectoSegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoSegurado>(c.Source.ObjectoSeguradoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<ListGraphType<ConsumoPlafondType>>("consumoPlafond", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ConsumoPlafond>(x => x.Where(e => e.HasValue(c.Source.IdCoberturaSelecionada)))));
            
        }
    }

    public class CoberturaSelecionadaInputType : InputObjectGraphType
	{
		public CoberturaSelecionadaInputType()
		{
			// Defining the name of the object
			Name = "coberturaSelecionadaInput";
			
            //Field<StringGraphType>("idCoberturaSelecionada");
			Field<StringGraphType>("cotacaoId");
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
			Field<StringGraphType>("coberturaPlanoId");
			Field<StringGraphType>("naturezaRisco");
			Field<StringGraphType>("objectoSeguradoId");
			Field<StringGraphType>("pessoaId");
			Field<CoberturaPlanoInputType>("coberturaPlano");
			Field<CotacaoInputType>("cotacao");
			Field<ObjectoSeguradoInputType>("objectoSegurado");
			Field<PessoaInputType>("pessoa");
			Field<ListGraphType<ConsumoPlafondInputType>>("consumoPlafond");
			
		}
	}
}