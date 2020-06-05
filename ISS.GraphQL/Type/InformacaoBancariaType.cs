using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class InformacaoBancariaType : ObjectGraphType<InformacaoBancaria>
    {
        public InformacaoBancariaType()
        {
            // Defining the name of the object
            Name = "informacaoBancaria";

            Field(x => x.IdInformacaoBancaria, nullable: true);
            Field(x => x.NumConta, nullable: true);
            Field(x => x.Iban, nullable: true);
            Field(x => x.SwiftCode, nullable: true);
            Field(x => x.NomeBancoId, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.EnderecoBancoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.Nib, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EmpresaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodInformacaoBancaria, nullable: true);
            Field(x => x.ContaFinanceiraId, nullable: true);
            Field(x => x.CartaoPagamentoId, nullable: true);
            FieldAsync<CartaoPagamentoType>("cartaoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CartaoPagamento>(c.Source.CartaoPagamentoId)));
            FieldAsync<ContaFinanceiraType>("contaFinanceiraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceiraId)));
            FieldAsync<EmpresaType>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Empresa>(c.Source.EmpresaId)));
            FieldAsync<EnderecoType>("enderecoBanco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoBancoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<BancoType>("nomeBanco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Banco>(c.Source.NomeBancoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<ListGraphType<CartaoCreditoType>>("cartaoCredito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CartaoCredito>(x => x.Where(e => e.HasValue(c.Source.IdInformacaoBancaria)))));
            FieldAsync<ListGraphType<ClassificacaoCaixaType>>("classificacaoCaixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoCaixa>(x => x.Where(e => e.HasValue(c.Source.IdInformacaoBancaria)))));
            FieldAsync<ListGraphType<ContaBancariaPosType>>("contaBancariaPos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaBancariaPos>(x => x.Where(e => e.HasValue(c.Source.IdInformacaoBancaria)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdInformacaoBancaria)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdInformacaoBancaria)))));
            FieldAsync<ListGraphType<InformacaoBancariaContratoType>>("informacaoBancariaContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancariaContrato>(x => x.Where(e => e.HasValue(c.Source.IdInformacaoBancaria)))));
            FieldAsync<ListGraphType<InformacaoBancariaPosType>>("informacaoBancariaPos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancariaPos>(x => x.Where(e => e.HasValue(c.Source.IdInformacaoBancaria)))));
            
        }
    }

    public class InformacaoBancariaInputType : InputObjectGraphType
	{
		public InformacaoBancariaInputType()
		{
			// Defining the name of the object
			Name = "informacaoBancariaInput";
			
            //Field<StringGraphType>("idInformacaoBancaria");
			Field<StringGraphType>("numConta");
			Field<StringGraphType>("iban");
			Field<StringGraphType>("swiftCode");
			Field<StringGraphType>("nomeBancoId");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("enderecoBancoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("nib");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("empresaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codInformacaoBancaria");
			Field<StringGraphType>("contaFinanceiraId");
			Field<StringGraphType>("cartaoPagamentoId");
			Field<CartaoPagamentoInputType>("cartaoPagamento");
			Field<ContaFinanceiraInputType>("contaFinanceiraNavigation");
			Field<EmpresaInputType>("empresa");
			Field<EnderecoInputType>("enderecoBanco");
			Field<EstadoInputType>("estado");
			Field<BancoInputType>("nomeBanco");
			Field<PessoaInputType>("pessoa");
			Field<ListGraphType<CartaoCreditoInputType>>("cartaoCredito");
			Field<ListGraphType<ClassificacaoCaixaInputType>>("classificacaoCaixa");
			Field<ListGraphType<ContaBancariaPosInputType>>("contaBancariaPos");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceira");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			Field<ListGraphType<InformacaoBancariaContratoInputType>>("informacaoBancariaContrato");
			Field<ListGraphType<InformacaoBancariaPosInputType>>("informacaoBancariaPos");
			
		}
	}
}