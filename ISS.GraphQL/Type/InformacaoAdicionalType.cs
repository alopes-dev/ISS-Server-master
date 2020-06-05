using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class InformacaoAdicionalType : ObjectGraphType<InformacaoAdicional>
    {
        public InformacaoAdicionalType()
        {
            // Defining the name of the object
            Name = "informacaoAdicional";

            Field(x => x.IdInformacaoAdicional, nullable: true);
            Field(x => x.CodInformacaoAdicional, nullable: true);
            Field(x => x.DescricaoInformacaoAdicional, nullable: true);
            Field(x => x.PercentagemNivelFincanceiro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MontanteNivelFinanceiro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CoberturaDanosAcidentaisNecessaria, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IdentificadorContrato, nullable: true);
            Field(x => x.ValorClassificacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PagadorInteresseAdicional, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodigoFrequenciaFactura, nullable: true);
            Field(x => x.CodigoFrequenciaCopiaCertificado, nullable: true);
            Field(x => x.DescricaoFrequenciaCopiaCertificado, nullable: true);
            Field(x => x.DataHoraProximaRequisicaoCertificado, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataHoraUltimaEmissaoCertificado, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataHoraProximaRequisicaoApolice, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataHoraUltimaEmissaoApolice, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodigoFrequenciaCopiaApolice, nullable: true);
            Field(x => x.DescricaoFrequenciaCopiaApolice, nullable: true);
            Field(x => x.DataHoraTermino, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.FacturaApenasInformativa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdInformacaoAdicional)))));
            
        }
    }

    public class InformacaoAdicionalInputType : InputObjectGraphType
	{
		public InformacaoAdicionalInputType()
		{
			// Defining the name of the object
			Name = "informacaoAdicionalInput";
			
            //Field<StringGraphType>("idInformacaoAdicional");
			Field<StringGraphType>("codInformacaoAdicional");
			Field<StringGraphType>("descricaoInformacaoAdicional");
			Field<FloatGraphType>("percentagemNivelFincanceiro");
			Field<FloatGraphType>("montanteNivelFinanceiro");
			Field<BooleanGraphType>("coberturaDanosAcidentaisNecessaria");
			Field<StringGraphType>("identificadorContrato");
			Field<FloatGraphType>("valorClassificacao");
			Field<BooleanGraphType>("pagadorInteresseAdicional");
			Field<StringGraphType>("codigoFrequenciaFactura");
			Field<StringGraphType>("codigoFrequenciaCopiaCertificado");
			Field<StringGraphType>("descricaoFrequenciaCopiaCertificado");
			Field<DateTimeGraphType>("dataHoraProximaRequisicaoCertificado");
			Field<DateTimeGraphType>("dataHoraUltimaEmissaoCertificado");
			Field<DateTimeGraphType>("dataHoraProximaRequisicaoApolice");
			Field<DateTimeGraphType>("dataHoraUltimaEmissaoApolice");
			Field<StringGraphType>("codigoFrequenciaCopiaApolice");
			Field<StringGraphType>("descricaoFrequenciaCopiaApolice");
			Field<DateTimeGraphType>("dataHoraTermino");
			Field<BooleanGraphType>("facturaApenasInformativa");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			
		}
	}
}