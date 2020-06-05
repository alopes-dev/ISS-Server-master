using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratoPrestadorEmpresaType : ObjectGraphType<ContratoPrestadorEmpresa>
    {
        public ContratoPrestadorEmpresaType()
        {
            // Defining the name of the object
            Name = "contratoPrestadorEmpresa";

            Field(x => x.IdContratoPrestadorEmpresa, nullable: true);
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Renovavel, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Exclusivo, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FormaPagamentoId, nullable: true);
            Field(x => x.PessoaResponsavelFuncionarioId, nullable: true);
            Field(x => x.PessoaResponsavelPrestador, nullable: true);
            Field(x => x.InformacaoBancaria, nullable: true);
            Field(x => x.Ambito, nullable: true);
            Field(x => x.Objectivo, nullable: true);
            Field(x => x.PrazoContrato, nullable: true, type: typeof(IntGraphType));
            Field(x => x.PeriodicidadePaga, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Clausulas, nullable: true);
            Field(x => x.TaxaJuros, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NaturezaMovimento, nullable: true);
            Field(x => x.CodTransacao, nullable: true);
            Field(x => x.NumeroContrato, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Referencia, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ContratanteId, nullable: true);
            Field(x => x.ContratadoId, nullable: true);
            Field(x => x.DataAssinatura, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataVencimento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.MoradaCobrancaContrato, nullable: true);
            Field(x => x.MoradaAssinatura, nullable: true);
            Field(x => x.NumeroPrestacoesPagas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumeroPrestacoesApagar, nullable: true, type: typeof(IntGraphType));
            Field(x => x.TotalValorPago, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TotalValorApagar, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ContaContabilistica, nullable: true);
            Field(x => x.ReclamacaoId, nullable: true);
            Field(x => x.NotaId, nullable: true);
            Field(x => x.ActividadeId, nullable: true);
            Field(x => x.Objecto, nullable: true);
            Field(x => x.PessoaResponsavelFuncionario, nullable: true);
            Field(x => x.LocalEmissaoId, nullable: true);
            Field(x => x.TipoPagamentoId, nullable: true);
            FieldAsync<ActividadeType>("actividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Actividade>(c.Source.ActividadeId)));
            FieldAsync<ClausulaType>("clausulasNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Clausula>(c.Source.Clausulas)));
            FieldAsync<PlanoContasType>("contaContabilisticaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.ContaContabilistica)));
            FieldAsync<PessoaType>("contratado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ContratadoId)));
            FieldAsync<PessoaType>("contratante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ContratanteId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            FieldAsync<InformacaoBancariaType>("informacaoBancariaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(c.Source.InformacaoBancaria)));
            FieldAsync<EnderecoType>("localEmissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.LocalEmissaoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<EnderecoType>("moradaAssinaturaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.MoradaAssinatura)));
            FieldAsync<EnderecoType>("moradaCobrancaContratoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.MoradaCobrancaContrato)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimentoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimento)));
            FieldAsync<NotasType>("nota", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Notas>(c.Source.NotaId)));
            FieldAsync<PessoaType>("pessoaResponsavelFuncionario1", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaResponsavelFuncionarioId)));
            FieldAsync<FuncionarioType>("pessoaResponsavelFuncionarioNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.PessoaResponsavelFuncionario)));
            FieldAsync<PessoaType>("pessoaResponsavelPrestadorNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaResponsavelPrestador)));
            FieldAsync<ReclamacaoType>("reclamacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Reclamacao>(c.Source.ReclamacaoId)));
            FieldAsync<TipoPagamentoType>("tipoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPagamento>(c.Source.TipoPagamentoId)));
            
        }
    }

    public class ContratoPrestadorEmpresaInputType : InputObjectGraphType
	{
		public ContratoPrestadorEmpresaInputType()
		{
			// Defining the name of the object
			Name = "contratoPrestadorEmpresaInput";
			
            //Field<StringGraphType>("idContratoPrestadorEmpresa");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFim");
			Field<BooleanGraphType>("renovavel");
			Field<BooleanGraphType>("exclusivo");
			Field<StringGraphType>("moedaId");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("formaPagamentoId");
			Field<StringGraphType>("pessoaResponsavelFuncionarioId");
			Field<StringGraphType>("pessoaResponsavelPrestador");
			Field<StringGraphType>("informacaoBancaria");
			Field<StringGraphType>("ambito");
			Field<StringGraphType>("objectivo");
			Field<IntGraphType>("prazoContrato");
			Field<IntGraphType>("periodicidadePaga");
			Field<StringGraphType>("clausulas");
			Field<FloatGraphType>("taxaJuros");
			Field<StringGraphType>("naturezaMovimento");
			Field<StringGraphType>("codTransacao");
			Field<IntGraphType>("numeroContrato");
			Field<IntGraphType>("referencia");
			Field<StringGraphType>("contratanteId");
			Field<StringGraphType>("contratadoId");
			Field<DateTimeGraphType>("dataAssinatura");
			Field<DateTimeGraphType>("dataVencimento");
			Field<StringGraphType>("moradaCobrancaContrato");
			Field<StringGraphType>("moradaAssinatura");
			Field<IntGraphType>("numeroPrestacoesPagas");
			Field<IntGraphType>("numeroPrestacoesApagar");
			Field<FloatGraphType>("totalValorPago");
			Field<FloatGraphType>("totalValorApagar");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("contaContabilistica");
			Field<StringGraphType>("reclamacaoId");
			Field<StringGraphType>("notaId");
			Field<StringGraphType>("actividadeId");
			Field<StringGraphType>("objecto");
			Field<StringGraphType>("pessoaResponsavelFuncionario");
			Field<StringGraphType>("localEmissaoId");
			Field<StringGraphType>("tipoPagamentoId");
			Field<ActividadeInputType>("actividade");
			Field<ClausulaInputType>("clausulasNavigation");
			Field<PlanoContasInputType>("contaContabilisticaNavigation");
			Field<PessoaInputType>("contratado");
			Field<PessoaInputType>("contratante");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoInputType>("formaPagamento");
			Field<InformacaoBancariaInputType>("informacaoBancariaNavigation");
			Field<EnderecoInputType>("localEmissao");
			Field<MoedaInputType>("moeda");
			Field<EnderecoInputType>("moradaAssinaturaNavigation");
			Field<EnderecoInputType>("moradaCobrancaContratoNavigation");
			Field<NaturezaMovimentoInputType>("naturezaMovimentoNavigation");
			Field<NotasInputType>("nota");
			Field<PessoaInputType>("pessoaResponsavelFuncionario1");
			Field<FuncionarioInputType>("pessoaResponsavelFuncionarioNavigation");
			Field<PessoaInputType>("pessoaResponsavelPrestadorNavigation");
			Field<ReclamacaoInputType>("reclamacao");
			Field<TipoPagamentoInputType>("tipoPagamento");
			
		}
	}
}