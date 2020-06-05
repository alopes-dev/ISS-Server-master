using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PerdaType : ObjectGraphType<Perda>
    {
        public PerdaType()
        {
            // Defining the name of the object
            Name = "perda";

            Field(x => x.IdPerda, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PerdaCoberta, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PossivelValorMonetario, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataOcorrencia, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataDescoberta, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataNotificacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataInicioReparacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFimReparacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CausaPerda, nullable: true);
            Field(x => x.Consequencias, nullable: true);
            Field(x => x.VideoImagem, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.PercentagemResponsabilidade, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoPerdaId, nullable: true);
            Field(x => x.CircunstanciaPerdaId, nullable: true);
            Field(x => x.PacienteId, nullable: true);
            Field(x => x.CustoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<CircunstanciaPerdaType>("circunstanciaPerda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CircunstanciaPerda>(c.Source.CircunstanciaPerdaId)));
            FieldAsync<CustoType>("custo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Custo>(c.Source.CustoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PacienteType>("paciente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Paciente>(c.Source.PacienteId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<TipoPerdaType>("tipoPerda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPerda>(c.Source.TipoPerdaId)));
            FieldAsync<ListGraphType<ReclamacaoType>>("reclamacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Reclamacao>(x => x.Where(e => e.HasValue(c.Source.IdPerda)))));
            FieldAsync<ListGraphType<ReparacaoType>>("reparacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Reparacao>(x => x.Where(e => e.HasValue(c.Source.IdPerda)))));
            
        }
    }

    public class PerdaInputType : InputObjectGraphType
	{
		public PerdaInputType()
		{
			// Defining the name of the object
			Name = "perdaInput";
			
            //Field<StringGraphType>("idPerda");
			Field<StringGraphType>("designacao");
			Field<BooleanGraphType>("perdaCoberta");
			Field<FloatGraphType>("possivelValorMonetario");
			Field<DateTimeGraphType>("dataOcorrencia");
			Field<DateTimeGraphType>("dataDescoberta");
			Field<DateTimeGraphType>("dataNotificacao");
			Field<DateTimeGraphType>("dataInicioReparacao");
			Field<DateTimeGraphType>("dataFimReparacao");
			Field<StringGraphType>("causaPerda");
			Field<StringGraphType>("consequencias");
			Field<StringGraphType>("videoImagem");
			Field<StringGraphType>("subContaId");
			Field<FloatGraphType>("percentagemResponsabilidade");
			Field<StringGraphType>("tipoPerdaId");
			Field<StringGraphType>("circunstanciaPerdaId");
			Field<StringGraphType>("pacienteId");
			Field<StringGraphType>("custoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<CircunstanciaPerdaInputType>("circunstanciaPerda");
			Field<CustoInputType>("custo");
			Field<EstadoInputType>("estado");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PacienteInputType>("paciente");
			Field<PlanoContasInputType>("subConta");
			Field<TipoPerdaInputType>("tipoPerda");
			Field<ListGraphType<ReclamacaoInputType>>("reclamacao");
			Field<ListGraphType<ReparacaoInputType>>("reparacao");
			
		}
	}
}