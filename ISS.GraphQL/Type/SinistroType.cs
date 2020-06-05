using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SinistroType : ObjectGraphType<Sinistro>
    {
        public SinistroType()
        {
            // Defining the name of the object
            Name = "sinistro";

            Field(x => x.IdSinistro, nullable: true);
            Field(x => x.NumOrdemSinistro, nullable: true, type: typeof(IntGraphType));
            Field(x => x.TipoSinistroId, nullable: true);
            Field(x => x.DataOcorrencia, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataParticipacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NumOcupantes, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Indeminizacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ParticipanteSinistroId, nullable: true);
            Field(x => x.ClassificacaoParticipanteId, nullable: true);
            Field(x => x.IncidenteInspectorId, nullable: true);
            Field(x => x.Obs, nullable: true);
            Field(x => x.DescricaoSinistro, nullable: true);
            Field(x => x.Aprovado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EnderecoOcorrenciaId, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Grave, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.CodSinistro, nullable: true);
            Field(x => x.ContaFinanceiraId, nullable: true);
            Field(x => x.OutroSeguroAbrangeEsteAcidente, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EmQueSegurador, nullable: true);
            Field(x => x.TipoSeguroId, nullable: true);
            Field(x => x.IncidenteRelacionanteAsuaProfissao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.SinistradoEraTransportadoEmVeiculo, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ClassificacaoAutomovelId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.MarcaAutomovelId, nullable: true);
            Field(x => x.MatriculaVeiculo, nullable: true);
            Field(x => x.InteresseCondutor, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.InteresseSegurado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Quilometragem, nullable: true);
            Field(x => x.IsPago, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<ClassificacaoAutomovelType>("classificacaoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAutomovel>(c.Source.ClassificacaoAutomovelId)));
            FieldAsync<ClassificacaoParticipanteSinistroType>("classificacaoParticipante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoParticipanteSinistro>(c.Source.ClassificacaoParticipanteId)));
            FieldAsync<ContaFinanceiraType>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceiraId)));
            FieldAsync<EnderecoType>("enderecoOcorrencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoOcorrenciaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("incidenteInspector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.IncidenteInspectorId)));
            FieldAsync<MarcaAutomovelType>("marcaAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MarcaAutomovel>(c.Source.MarcaAutomovelId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PessoaType>("participanteSinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ParticipanteSinistroId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoSeguroType>("tipoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSeguro>(c.Source.TipoSeguroId)));
            FieldAsync<TipoSinistroType>("tipoSinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSinistro>(c.Source.TipoSinistroId)));
            FieldAsync<ListGraphType<AutoridadesContactadasType>>("autoridadesContactadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AutoridadesContactadas>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<BemAfectadoType>>("bemAfectado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BemAfectado>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<BemSalvadoType>>("bemSalvado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BemSalvado>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<CausadorSinistroType>>("causadorSinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CausadorSinistro>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<ConsequenciaSinistroType>>("consequenciaSinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ConsequenciaSinistro>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<DeclaracaoTestemunhaType>>("declaracaoTestemunha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DeclaracaoTestemunha>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<ExcedenteType>>("excedente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Excedente>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<FacultativoResseguroType>>("facultativoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FacultativoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<FornecedorType>>("fornecedor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fornecedor>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<IndeminizacaoType>>("indeminizacaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Indeminizacao>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<LesadoType>>("lesado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Lesado>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<MedicoType>>("medico", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Medico>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<MotoristaType>>("motorista", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Motorista>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<ObjectoEnvolvidoType>>("objectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoEnvolvido>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<OutrasInformacoesSinistroType>>("outrasInformacoesSinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OutrasInformacoesSinistro>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<PacienteType>>("paciente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Paciente>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<PrejuizoSofridoVeiculoTerceiroType>>("prejuizoSofridoVeiculoTerceiro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrejuizoSofridoVeiculoTerceiro>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<ReembolsoTratamentoDentarioType>>("reembolsoTratamentoDentario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReembolsoTratamentoDentario>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<RelatorioPoliciaType>>("relatorioPolicia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RelatorioPolicia>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<ResponsabilizadoType>>("responsabilizado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Responsabilizado>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<ResseguroType>>("resseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Resseguro>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<SinistradoType>>("sinistrado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistrado>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<SubFormaResseguroInformacaoType>>("subFormaResseguroInformacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubFormaResseguroInformacao>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<TerceiroType>>("terceiro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Terceiro>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            FieldAsync<ListGraphType<TestemunhaType>>("testemunha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Testemunha>(x => x.Where(e => e.HasValue(c.Source.IdSinistro)))));
            
        }
    }

    public class SinistroInputType : InputObjectGraphType
	{
		public SinistroInputType()
		{
			// Defining the name of the object
			Name = "sinistroInput";
			
            //Field<StringGraphType>("idSinistro");
			Field<IntGraphType>("numOrdemSinistro");
			Field<StringGraphType>("tipoSinistroId");
			Field<DateTimeGraphType>("dataOcorrencia");
			Field<DateTimeGraphType>("dataParticipacao");
			Field<IntGraphType>("numOcupantes");
			Field<FloatGraphType>("indeminizacao");
			Field<StringGraphType>("participanteSinistroId");
			Field<StringGraphType>("classificacaoParticipanteId");
			Field<StringGraphType>("incidenteInspectorId");
			Field<StringGraphType>("obs");
			Field<StringGraphType>("descricaoSinistro");
			Field<BooleanGraphType>("aprovado");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("enderecoOcorrenciaId");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("grave");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("codSinistro");
			Field<StringGraphType>("contaFinanceiraId");
			Field<BooleanGraphType>("outroSeguroAbrangeEsteAcidente");
			Field<StringGraphType>("emQueSegurador");
			Field<StringGraphType>("tipoSeguroId");
			Field<BooleanGraphType>("incidenteRelacionanteAsuaProfissao");
			Field<BooleanGraphType>("sinistradoEraTransportadoEmVeiculo");
			Field<StringGraphType>("classificacaoAutomovelId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("marcaAutomovelId");
			Field<StringGraphType>("matriculaVeiculo");
			Field<BooleanGraphType>("interesseCondutor");
			Field<BooleanGraphType>("interesseSegurado");
			Field<StringGraphType>("quilometragem");
			Field<BooleanGraphType>("isPago");
			Field<ApoliceInputType>("apolice");
			Field<ClassificacaoAutomovelInputType>("classificacaoAutomovel");
			Field<ClassificacaoParticipanteSinistroInputType>("classificacaoParticipante");
			Field<ContaFinanceiraInputType>("contaFinanceira");
			Field<EnderecoInputType>("enderecoOcorrencia");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("incidenteInspector");
			Field<MarcaAutomovelInputType>("marcaAutomovel");
			Field<MoedaInputType>("moeda");
			Field<PessoaInputType>("participanteSinistro");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoSeguroInputType>("tipoSeguro");
			Field<TipoSinistroInputType>("tipoSinistro");
			Field<ListGraphType<AutoridadesContactadasInputType>>("autoridadesContactadas");
			Field<ListGraphType<BemAfectadoInputType>>("bemAfectado");
			Field<ListGraphType<BemSalvadoInputType>>("bemSalvado");
			Field<ListGraphType<CausadorSinistroInputType>>("causadorSinistro");
			Field<ListGraphType<ConsequenciaSinistroInputType>>("consequenciaSinistro");
			Field<ListGraphType<DeclaracaoTestemunhaInputType>>("declaracaoTestemunha");
			Field<ListGraphType<ExcedenteInputType>>("excedente");
			Field<ListGraphType<FacultativoResseguroInputType>>("facultativoResseguro");
			Field<ListGraphType<FornecedorInputType>>("fornecedor");
			Field<ListGraphType<IndeminizacaoInputType>>("indeminizacaoNavigation");
			Field<ListGraphType<LesadoInputType>>("lesado");
			Field<ListGraphType<MedicoInputType>>("medico");
			Field<ListGraphType<MotoristaInputType>>("motorista");
			Field<ListGraphType<ObjectoEnvolvidoInputType>>("objectoEnvolvido");
			Field<ListGraphType<OutrasInformacoesSinistroInputType>>("outrasInformacoesSinistro");
			Field<ListGraphType<PacienteInputType>>("paciente");
			Field<ListGraphType<PrejuizoSofridoVeiculoTerceiroInputType>>("prejuizoSofridoVeiculoTerceiro");
			Field<ListGraphType<ReembolsoTratamentoDentarioInputType>>("reembolsoTratamentoDentario");
			Field<ListGraphType<RelatorioPoliciaInputType>>("relatorioPolicia");
			Field<ListGraphType<ResponsabilizadoInputType>>("responsabilizado");
			Field<ListGraphType<ResseguroInputType>>("resseguro");
			Field<ListGraphType<SinistradoInputType>>("sinistrado");
			Field<ListGraphType<SubFormaResseguroInformacaoInputType>>("subFormaResseguroInformacao");
			Field<ListGraphType<TerceiroInputType>>("terceiro");
			Field<ListGraphType<TestemunhaInputType>>("testemunha");
			
		}
	}
}