using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NivelRiscoType : ObjectGraphType<NivelRisco>
    {
        public NivelRiscoType()
        {
            // Defining the name of the object
            Name = "nivelRisco";

            Field(x => x.IdClasseRisco, nullable: true);
            Field(x => x.Classe, nullable: true);
            Field(x => x.CodClasseRisco, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CaeType>>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            FieldAsync<ListGraphType<CoberturaPlanoType>>("coberturaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaPlano>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            FieldAsync<ListGraphType<DespesaType>>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            FieldAsync<ListGraphType<LimitesAceitacaoType>>("limitesAceitacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimitesAceitacao>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            FieldAsync<ListGraphType<NivelRiscoCoberturaType>>("nivelRiscoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRiscoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            FieldAsync<ListGraphType<PremiosType>>("premios", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Premios>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            FieldAsync<ListGraphType<PremiosCoberturaAcidentesPessoaisType>>("premiosCoberturaAcidentesPessoais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PremiosCoberturaAcidentesPessoais>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            FieldAsync<ListGraphType<ProfissaoType>>("profissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Profissao>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            FieldAsync<ListGraphType<ProvinciaPlanoType>>("provinciaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProvinciaPlano>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            FieldAsync<ListGraphType<RiscoPlanoProdutoType>>("riscoPlanoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RiscoPlanoProduto>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            FieldAsync<ListGraphType<TarefaType>>("tarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarefa>(x => x.Where(e => e.HasValue(c.Source.IdClasseRisco)))));
            
        }
    }

    public class NivelRiscoInputType : InputObjectGraphType
	{
		public NivelRiscoInputType()
		{
			// Defining the name of the object
			Name = "nivelRiscoInput";
			
            //Field<StringGraphType>("idClasseRisco");
			Field<StringGraphType>("classe");
			Field<StringGraphType>("codClasseRisco");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<FloatGraphType>("taxa");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CaeInputType>>("cae");
			Field<ListGraphType<CoberturaPlanoInputType>>("coberturaPlano");
			Field<ListGraphType<DespesaInputType>>("despesa");
			Field<ListGraphType<LimitesAceitacaoInputType>>("limitesAceitacao");
			Field<ListGraphType<NivelRiscoCoberturaInputType>>("nivelRiscoCobertura");
			Field<ListGraphType<PremiosInputType>>("premios");
			Field<ListGraphType<PremiosCoberturaAcidentesPessoaisInputType>>("premiosCoberturaAcidentesPessoais");
			Field<ListGraphType<ProfissaoInputType>>("profissao");
			Field<ListGraphType<ProvinciaPlanoInputType>>("provinciaPlano");
			Field<ListGraphType<RiscoPlanoProdutoInputType>>("riscoPlanoProduto");
			Field<ListGraphType<TarefaInputType>>("tarefa");
			
		}
	}
}