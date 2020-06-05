using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MovimentoType : ObjectGraphType<Movimento>
    {
        public MovimentoType()
        {
            // Defining the name of the object
            Name = "movimento";

            Field(x => x.IdMovimento, nullable: true);
            Field(x => x.DataHoraMovimento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DescricaoMovimento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataValor, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodEstado, nullable: true);
            Field(x => x.CodContaFinanceira, nullable: true);
            Field(x => x.NumeroDocumentoInterno, nullable: true);
            Field(x => x.CodCaixa, nullable: true);
            Field(x => x.CodEndereco, nullable: true);
            Field(x => x.IsPago, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Contabliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodFavorecido, nullable: true);
            Field(x => x.CodOutraMoeda, nullable: true);
            Field(x => x.CodCentroResponsabilidade, nullable: true);
            Field(x => x.CodCentroCusto, nullable: true);
            Field(x => x.Referencia, nullable: true);
            Field(x => x.DataVencimento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataProgramada, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DocumentoParcelado, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Identificador, nullable: true);
            Field(x => x.NumeroDocumentoExterno, nullable: true);
            Field(x => x.CodEmpresa, nullable: true);
            Field(x => x.CodTipoPagamento, nullable: true);
            Field(x => x.ValorOutraMoeda, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodFraccionamento, nullable: true);
            Field(x => x.CodOperacoesPagamento, nullable: true);
            Field(x => x.CodMoeda, nullable: true);
            Field(x => x.CodNaturezaMovimento, nullable: true);
            Field(x => x.CodConta, nullable: true);
            Field(x => x.CodOperacao, nullable: true);
            Field(x => x.CodFuncionario, nullable: true);
            Field(x => x.CodExercicio, nullable: true);
            Field(x => x.CodTipoDocumentos, nullable: true);
            Field(x => x.NumeroLote, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodFormaPagamento, nullable: true);
            Field(x => x.CodCae, nullable: true);
            //Field(x => x.NumOrdem, nullable: true, type: typeof(IntGraphType));
            FieldAsync<CaeType>("codCaeNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.IdMovimento)));
            FieldAsync<CaixaType>("codCaixaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Caixa>(c.Source.IdMovimento)));
            FieldAsync<CentroCustoType>("codCentroCustoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(c.Source.IdMovimento)));
            FieldAsync<CentroResponsabilidadeType>("codCentroResponsabilidadeNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroResponsabilidade>(c.Source.IdMovimento)));
            FieldAsync<ContaFinanceiraType>("codContaFinanceiraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.IdMovimento)));
            FieldAsync<PlanoContasType>("codContaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.IdMovimento)));
            FieldAsync<EmpresaType>("codEmpresaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Empresa>(c.Source.IdMovimento)));
            FieldAsync<EnderecoType>("codEnderecoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.IdMovimento)));
            FieldAsync<ExercicioType>("codExercicioNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exercicio>(c.Source.IdMovimento)));
            FieldAsync<PessoaType>("codFavorecidoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.IdMovimento)));
            FieldAsync<FormaPagamentoType>("codFormaPagamentoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.IdMovimento)));
            FieldAsync<FraccionamentoType>("codFraccionamentoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fraccionamento>(c.Source.IdMovimento)));
            FieldAsync<FuncionarioType>("codFuncionarioNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.IdMovimento)));
            FieldAsync<MoedaType>("codMoedaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.IdMovimento)));
            FieldAsync<NaturezaMovimentoType>("codNaturezaMovimentoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.IdMovimento)));
            FieldAsync<OperacaoType>("codOperacaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Operacao>(c.Source.IdMovimento)));
            FieldAsync<MoedaType>("codOutraMoedaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.IdMovimento)));
            FieldAsync<TipoDocumentosType>("codTipoDocumentosNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDocumentos>(c.Source.IdMovimento)));
            FieldAsync<ListGraphType<MovimentoPlanoType>>("movimentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MovimentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdMovimento)))));
            FieldAsync<ListGraphType<TipoRecebimentoMovimentoType>>("tipoRecebimentoMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRecebimentoMovimento>(x => x.Where(e => e.HasValue(c.Source.IdMovimento)))));
            
        }
    }

    public class MovimentoInputType : InputObjectGraphType
	{
		public MovimentoInputType()
		{
			// Defining the name of the object
			Name = "movimentoInput";
			
            //Field<StringGraphType>("idMovimento");
			Field<DateTimeGraphType>("dataHoraMovimento");
			Field<StringGraphType>("descricaoMovimento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DateTimeGraphType>("dataValor");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("codEstado");
			Field<StringGraphType>("codContaFinanceira");
			Field<StringGraphType>("numeroDocumentoInterno");
			Field<StringGraphType>("codCaixa");
			Field<StringGraphType>("codEndereco");
			Field<BooleanGraphType>("isPago");
			Field<BooleanGraphType>("contabliza");
			Field<StringGraphType>("codFavorecido");
			Field<StringGraphType>("codOutraMoeda");
			Field<StringGraphType>("codCentroResponsabilidade");
			Field<StringGraphType>("codCentroCusto");
			Field<StringGraphType>("referencia");
			Field<DateTimeGraphType>("dataVencimento");
			Field<DateTimeGraphType>("dataProgramada");
			Field<IntGraphType>("documentoParcelado");
			Field<StringGraphType>("identificador");
			Field<StringGraphType>("numeroDocumentoExterno");
			Field<StringGraphType>("codEmpresa");
			Field<StringGraphType>("codTipoPagamento");
			Field<FloatGraphType>("valorOutraMoeda");
			Field<StringGraphType>("codFraccionamento");
			Field<StringGraphType>("codOperacoesPagamento");
			Field<StringGraphType>("codMoeda");
			Field<StringGraphType>("codNaturezaMovimento");
			Field<StringGraphType>("codConta");
			Field<StringGraphType>("codOperacao");
			Field<StringGraphType>("codFuncionario");
			Field<StringGraphType>("codExercicio");
			Field<StringGraphType>("codTipoDocumentos");
			Field<IntGraphType>("numeroLote");
			Field<StringGraphType>("codFormaPagamento");
			Field<StringGraphType>("codCae");
			//Field<IntGraphType>("numOrdem");
			Field<CaeInputType>("codCaeNavigation");
			Field<CaixaInputType>("codCaixaNavigation");
			Field<CentroCustoInputType>("codCentroCustoNavigation");
			Field<CentroResponsabilidadeInputType>("codCentroResponsabilidadeNavigation");
			Field<ContaFinanceiraInputType>("codContaFinanceiraNavigation");
			Field<PlanoContasInputType>("codContaNavigation");
			Field<EmpresaInputType>("codEmpresaNavigation");
			Field<EnderecoInputType>("codEnderecoNavigation");
			Field<ExercicioInputType>("codExercicioNavigation");
			Field<PessoaInputType>("codFavorecidoNavigation");
			Field<FormaPagamentoInputType>("codFormaPagamentoNavigation");
			Field<FraccionamentoInputType>("codFraccionamentoNavigation");
			Field<FuncionarioInputType>("codFuncionarioNavigation");
			Field<MoedaInputType>("codMoedaNavigation");
			Field<NaturezaMovimentoInputType>("codNaturezaMovimentoNavigation");
			Field<OperacaoInputType>("codOperacaoNavigation");
			Field<MoedaInputType>("codOutraMoedaNavigation");
			Field<TipoDocumentosInputType>("codTipoDocumentosNavigation");
			Field<ListGraphType<MovimentoPlanoInputType>>("movimentoPlano");
			Field<ListGraphType<TipoRecebimentoMovimentoInputType>>("tipoRecebimentoMovimento");
			
		}
	}
}