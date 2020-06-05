using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EnderecoType : ObjectGraphType<Endereco>
    {
        public EnderecoType()
        {
            // Defining the name of the object
            Name = "endereco";

            Field(x => x.IdEndereco, nullable: true);
            Field<BooleanGraphType>(name: nameof(EnderecoPessoa.Principal), resolve: c => true);
            Field(x => x.RuaId, nullable: true);
            Field(x => x.TipoEnderecoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CidadeId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodEndereco, nullable: true);
            Field(x => x.ContaFinanceiraId, nullable: true);
            Field(x => x.BairroId, nullable: true);
            FieldAsync<BairroType>("bairro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Bairro>(c.Source.BairroId)));
            FieldAsync<CidadeType>("cidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cidade>(c.Source.CidadeId)));
            FieldAsync<ContaFinanceiraType>("contaFinanceiraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceiraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<RuaType>("rua", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Rua>(c.Source.RuaId)));
            FieldAsync<TipoEnderecoType>("tipoEndereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEndereco>(c.Source.TipoEnderecoId)));
            FieldAsync<ListGraphType<BalcaoType>>("balcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Balcao>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<CaixaType>>("caixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Caixa>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<ComissaoPlanoType>>("comissaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<CondicaoOperacaoType>>("condicaoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicaoOperacao>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<ConstrucaoType>>("construcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Construcao>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<ContratoType>>("contratoEndereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<ContratoType>>("contratoMoradaAssinaturaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<ContratoType>>("contratoMoradaCobrancaContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresaLocalEmissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresaMoradaAssinaturaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresaMoradaCobrancaContratoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacaoLocalCobranca", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacaoLocalRiscoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<EmpresaType>>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Empresa>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<EnderecoPessoaType>>("enderecoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EnderecoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<EnderecoPlanoType>>("enderecoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EnderecoPlano>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<InformacaoBancariaType>>("informacaoBancaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<InfraccoesType>>("infraccoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Infraccoes>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<LocaisComissaoType>>("locaisComissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisComissao>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<LocalAplicacaoPlanoType>>("localAplicacaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalAplicacaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<LocalizacaoInstalacoesType>>("localizacaoInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalizacaoInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<MoradaType>>("morada", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Morada>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<NewsletterType>>("newsletter", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Newsletter>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<PessoaProfissaoType>>("pessoaProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<PremiosRiscosSimplesType>>("premiosRiscosSimples", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PremiosRiscosSimples>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<SinistroType>>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<TipoContratoEmpresaType>>("tipoContratoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContratoEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            FieldAsync<ListGraphType<TipoRegimeType>>("tipoRegime", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRegime>(x => x.Where(e => e.HasValue(c.Source.IdEndereco)))));
            
        }
    }

    public class EnderecoInputType : InputObjectGraphType
	{
		public EnderecoInputType()
		{
			// Defining the name of the object
			Name = "enderecoInput";
			
            //Field<StringGraphType>("idEndereco");
			Field<StringGraphType>("ruaId");
			Field<StringGraphType>("tipoEnderecoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("cidadeId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codEndereco");
			Field<StringGraphType>("contaFinanceiraId");
			Field<StringGraphType>("bairroId");
			Field<BairroInputType>("bairro");
			Field<CidadeInputType>("cidade");
			Field<ContaFinanceiraInputType>("contaFinanceiraNavigation");
			Field<EstadoInputType>("estado");
			Field<RuaInputType>("rua");
			Field<TipoEnderecoInputType>("tipoEndereco");
			Field<ListGraphType<BalcaoInputType>>("balcao");
			Field<ListGraphType<CaixaInputType>>("caixa");
			Field<ListGraphType<ComissaoPlanoInputType>>("comissaoPlano");
			Field<ListGraphType<CondicaoOperacaoInputType>>("condicaoOperacao");
			Field<ListGraphType<ConstrucaoInputType>>("construcao");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceira");
			Field<ListGraphType<ContratoInputType>>("contratoEndereco");
			Field<ListGraphType<ContratoInputType>>("contratoMoradaAssinaturaNavigation");
			Field<ListGraphType<ContratoInputType>>("contratoMoradaCobrancaContrato");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresaLocalEmissao");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresaMoradaAssinaturaNavigation");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresaMoradaCobrancaContratoNavigation");
			Field<ListGraphType<CotacaoInputType>>("cotacaoLocalCobranca");
			Field<ListGraphType<CotacaoInputType>>("cotacaoLocalRiscoEmpresa");
			Field<ListGraphType<EmpresaInputType>>("empresa");
			Field<ListGraphType<EnderecoPessoaInputType>>("enderecoPessoa");
			Field<ListGraphType<EnderecoPlanoInputType>>("enderecoPlano");
			Field<ListGraphType<InformacaoBancariaInputType>>("informacaoBancaria");
			Field<ListGraphType<InfraccoesInputType>>("infraccoes");
			Field<ListGraphType<LocaisComissaoInputType>>("locaisComissao");
			Field<ListGraphType<LocalAplicacaoPlanoInputType>>("localAplicacaoPlano");
			Field<ListGraphType<LocalizacaoInstalacoesInputType>>("localizacaoInstalacoes");
			Field<ListGraphType<MoradaInputType>>("morada");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<NewsletterInputType>>("newsletter");
			Field<ListGraphType<PessoaProfissaoInputType>>("pessoaProfissao");
			Field<ListGraphType<PremiosRiscosSimplesInputType>>("premiosRiscosSimples");
			Field<ListGraphType<SinistroInputType>>("sinistro");
			Field<ListGraphType<TipoContratoEmpresaInputType>>("tipoContratoEmpresa");
			Field<ListGraphType<TipoRegimeInputType>>("tipoRegime");
			
		}
	}
}