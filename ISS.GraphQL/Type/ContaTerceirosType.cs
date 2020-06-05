using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContaTerceirosType : ObjectGraphType<ContaTerceiros>
    {
        public ContaTerceirosType()
        {
            // Defining the name of the object
            Name = "contaTerceiros";

            Field(x => x.IdContaTerceiros, nullable: true);
            Field(x => x.DataHoraMovimento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DescricaoMovimento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataValor, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodEstado, nullable: true);
            Field(x => x.CodContaFinanceira, nullable: true);
            Field(x => x.CodTransacao, nullable: true);
            Field(x => x.NumeroDocumentoInterno, nullable: true);
            Field(x => x.CodCaixa, nullable: true);
            Field(x => x.CodEndereco, nullable: true);
            Field(x => x.CodTipoOperacao, nullable: true);
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
            Field(x => x.ContaFinanceiraId, nullable: true);
            Field(x => x.CodFuncionario, nullable: true);
            Field(x => x.CodExercicio, nullable: true);
            Field(x => x.CodTipoDocumentos, nullable: true);
            
        }
    }

    public class ContaTerceirosInputType : InputObjectGraphType
	{
		public ContaTerceirosInputType()
		{
			// Defining the name of the object
			Name = "contaTerceirosInput";
			
            //Field<StringGraphType>("idContaTerceiros");
			Field<DateTimeGraphType>("dataHoraMovimento");
			Field<StringGraphType>("descricaoMovimento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DateTimeGraphType>("dataValor");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("codEstado");
			Field<StringGraphType>("codContaFinanceira");
			Field<StringGraphType>("codTransacao");
			Field<StringGraphType>("numeroDocumentoInterno");
			Field<StringGraphType>("codCaixa");
			Field<StringGraphType>("codEndereco");
			Field<StringGraphType>("codTipoOperacao");
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
			Field<StringGraphType>("contaFinanceiraId");
			Field<StringGraphType>("codFuncionario");
			Field<StringGraphType>("codExercicio");
			Field<StringGraphType>("codTipoDocumentos");
			
		}
	}
}