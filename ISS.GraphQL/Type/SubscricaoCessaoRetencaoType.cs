using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubscricaoCessaoRetencaoType : ObjectGraphType<SubscricaoCessaoRetencao>
    {
        public SubscricaoCessaoRetencaoType()
        {
            // Defining the name of the object
            Name = "subscricaoCessaoRetencao";

            Field(x => x.IdSubscricaoCessaoRetencao, nullable: true);
            Field(x => x.CedenteId, nullable: true);
            Field(x => x.RetenteId, nullable: true);
            Field(x => x.TaxaCessao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaRetencao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ResseguroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodSubscricaoCessaoRetencao, nullable: true);
            Field(x => x.ComissioanemntoId, nullable: true);
            Field(x => x.NumeroReferencia, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.NotaId, nullable: true);
            Field(x => x.TarefaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ComissionamentoType>("comissioanemnto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(c.Source.ComissioanemntoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<NotaType>("nota", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Nota>(c.Source.NotaId)));
            FieldAsync<ResseguroType>("resseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Resseguro>(c.Source.ResseguroId)));
            FieldAsync<TarefaType>("tarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarefa>(c.Source.TarefaId)));
            FieldAsync<ListGraphType<PapelPessoaResseguroType>>("papelPessoaResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPessoaResseguro>(x => x.Where(e => e.HasValue(c.Source.IdSubscricaoCessaoRetencao)))));
            
        }
    }

    public class SubscricaoCessaoRetencaoInputType : InputObjectGraphType
	{
		public SubscricaoCessaoRetencaoInputType()
		{
			// Defining the name of the object
			Name = "subscricaoCessaoRetencaoInput";
			
            //Field<StringGraphType>("idSubscricaoCessaoRetencao");
			Field<StringGraphType>("cedenteId");
			Field<StringGraphType>("retenteId");
			Field<FloatGraphType>("taxaCessao");
			Field<FloatGraphType>("taxaRetencao");
			Field<StringGraphType>("resseguroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codSubscricaoCessaoRetencao");
			Field<StringGraphType>("comissioanemntoId");
			Field<StringGraphType>("numeroReferencia");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("notaId");
			Field<StringGraphType>("tarefaId");
			Field<StringGraphType>("estadoId");
			Field<ComissionamentoInputType>("comissioanemnto");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<NotaInputType>("nota");
			Field<ResseguroInputType>("resseguro");
			Field<TarefaInputType>("tarefa");
			Field<ListGraphType<PapelPessoaResseguroInputType>>("papelPessoaResseguro");
			
		}
	}
}