using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MovimentoHistoricoType : ObjectGraphType<MovimentoHistorico>
    {
        public MovimentoHistoricoType()
        {
            // Defining the name of the object
            Name = "movimentoHistorico";

            Field(x => x.IdMovimento, nullable: true);
            Field(x => x.DataHoraMovimento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DescricaoMovimento, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.SubClasseId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataValor, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ContaFinanceiraId, nullable: true);
            Field(x => x.FuncionarioId, nullable: true);
            Field(x => x.TipoRecebimentoId, nullable: true);
            Field(x => x.CodTransacao, nullable: true);
            Field(x => x.NumeroDocumentoInterno, nullable: true);
            Field(x => x.CaixaId, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.IsPago, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Contabliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.FavorecidoId, nullable: true);
            Field(x => x.OutraMoedaId, nullable: true);
            Field(x => x.CentroResponsabilidadeId, nullable: true);
            Field(x => x.CentroCustoId, nullable: true);
            Field(x => x.Referencia, nullable: true);
            Field(x => x.DataVencimento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataProgramada, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DocumentoParcelado, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Identificador, nullable: true);
            Field(x => x.NumeroDocumentoExterno, nullable: true);
            Field(x => x.PeriodoContabilId, nullable: true);
            Field(x => x.EmpresaId, nullable: true);
            Field(x => x.TipoPagamentoId, nullable: true);
            Field(x => x.CodOperacao, nullable: true);
            Field(x => x.ValorOutraMoeda, nullable: true, type: typeof(FloatGraphType));
            
        }
    }

    public class MovimentoHistoricoInputType : InputObjectGraphType
	{
		public MovimentoHistoricoInputType()
		{
			// Defining the name of the object
			Name = "movimentoHistoricoInput";
			
            //Field<StringGraphType>("idMovimento");
			Field<DateTimeGraphType>("dataHoraMovimento");
			Field<StringGraphType>("descricaoMovimento");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("subClasseId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DateTimeGraphType>("dataValor");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("contaFinanceiraId");
			Field<StringGraphType>("funcionarioId");
			Field<StringGraphType>("tipoRecebimentoId");
			Field<StringGraphType>("codTransacao");
			Field<StringGraphType>("numeroDocumentoInterno");
			Field<StringGraphType>("caixaId");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("tipoOperacaoId");
			Field<BooleanGraphType>("isPago");
			Field<BooleanGraphType>("contabliza");
			Field<StringGraphType>("favorecidoId");
			Field<StringGraphType>("outraMoedaId");
			Field<StringGraphType>("centroResponsabilidadeId");
			Field<StringGraphType>("centroCustoId");
			Field<StringGraphType>("referencia");
			Field<DateTimeGraphType>("dataVencimento");
			Field<DateTimeGraphType>("dataProgramada");
			Field<IntGraphType>("documentoParcelado");
			Field<StringGraphType>("identificador");
			Field<StringGraphType>("numeroDocumentoExterno");
			Field<StringGraphType>("periodoContabilId");
			Field<StringGraphType>("empresaId");
			Field<StringGraphType>("tipoPagamentoId");
			Field<StringGraphType>("codOperacao");
			Field<FloatGraphType>("valorOutraMoeda");
			
		}
	}
}