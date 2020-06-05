using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContaFinanceiraType : ObjectGraphType<ContaFinanceira>
    {
        public ContaFinanceiraType()
        {
            // Defining the name of the object
            Name = "contaFinanceira";

            Field(x => x.IdContaFinanceira, nullable: true);
            Field(x => x.RefContaFinanceira, nullable: true);
            Field(x => x.BalcaoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataEncerramento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoContaId, nullable: true);
            Field(x => x.NumeroConta, nullable: true);
            Field(x => x.NomeConta, nullable: true);
            Field(x => x.CodContaFinanceira, nullable: true);
            Field(x => x.Apelido, nullable: true);
            Field(x => x.FormaMovimentoId, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.TipoClienteId, nullable: true);
            Field(x => x.SufixoConta, nullable: true);
            Field(x => x.NumCliente, nullable: true, type: typeof(IntGraphType));
            Field(x => x.GestorContaId, nullable: true);
            Field(x => x.LimiteConta, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.InformacaoBancariaId, nullable: true);
            Field(x => x.ValorCativoId, nullable: true);
            Field(x => x.TituloId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.SubContaContabilisticaId, nullable: true);
            Field(x => x.FormaMovimentoContaFinanceira, nullable: true);
            FieldAsync<ApoliceType>("apoliceNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<BalcaoType>("balcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Balcao>(c.Source.BalcaoId)));
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaMovimentoContaFinanceiraType>("formaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaMovimentoContaFinanceira>(c.Source.FormaMovimentoId)));
            FieldAsync<FormaMovimentoContaFinanceiraType>("formaMovimentoContaFinanceiraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaMovimentoContaFinanceira>(c.Source.FormaMovimentoContaFinanceira)));
            FieldAsync<PessoaType>("gestorConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.GestorContaId)));
            FieldAsync<InformacaoBancariaType>("informacaoBancaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(c.Source.InformacaoBancariaId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PlanoContasType>("subContaContabilistica", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaContabilisticaId)));
            FieldAsync<TipoClienteType>("tipoCliente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCliente>(c.Source.TipoClienteId)));
            FieldAsync<TipoContaType>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(c.Source.TipoContaId)));
            FieldAsync<TituloType>("titulo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Titulo>(c.Source.TituloId)));
            FieldAsync<ValorCativoType>("valorCativo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValorCativo>(c.Source.ValorCativoId)));
            FieldAsync<ListGraphType<ApoliceType>>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<CartaoPagamentoType>>("cartaoPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CartaoPagamento>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<ContactoType>>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<ContratoType>>("contratoContaFinanceira1", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<ContratoType>>("contratoContaFinanceira2", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<EnderecoType>>("enderecoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<InformacaoBancariaType>>("informacaoBancariaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<SaldoType>>("saldo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Saldo>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<SinistroType>>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<TitularidadeType>>("titularidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Titularidade>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<TituloType>>("tituloNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Titulo>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            FieldAsync<ListGraphType<ValorCativoType>>("valorCativoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValorCativo>(x => x.Where(e => e.HasValue(c.Source.IdContaFinanceira)))));
            
        }
    }

    public class ContaFinanceiraInputType : InputObjectGraphType
	{
		public ContaFinanceiraInputType()
		{
			// Defining the name of the object
			Name = "contaFinanceiraInput";
			
            //Field<StringGraphType>("idContaFinanceira");
			Field<StringGraphType>("refContaFinanceira");
			Field<StringGraphType>("balcaoId");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("moedaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DateTimeGraphType>("dataEncerramento");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoContaId");
			Field<StringGraphType>("numeroConta");
			Field<StringGraphType>("nomeConta");
			Field<StringGraphType>("codContaFinanceira");
			Field<StringGraphType>("apelido");
			Field<StringGraphType>("formaMovimentoId");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("tipoClienteId");
			Field<StringGraphType>("sufixoConta");
			Field<IntGraphType>("numCliente");
			Field<StringGraphType>("gestorContaId");
			Field<IntGraphType>("limiteConta");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("informacaoBancariaId");
			Field<StringGraphType>("valorCativoId");
			Field<StringGraphType>("tituloId");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("subContaContabilisticaId");
			Field<StringGraphType>("formaMovimentoContaFinanceira");
			Field<ApoliceInputType>("apoliceNavigation");
			Field<BalcaoInputType>("balcao");
			Field<CanalInputType>("canal");
			Field<ContratoInputType>("contrato");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			Field<FormaMovimentoContaFinanceiraInputType>("formaMovimento");
			Field<FormaMovimentoContaFinanceiraInputType>("formaMovimentoContaFinanceiraNavigation");
			Field<PessoaInputType>("gestorConta");
			Field<InformacaoBancariaInputType>("informacaoBancaria");
			Field<MoedaInputType>("moeda");
			Field<PlanoContasInputType>("subContaContabilistica");
			Field<TipoClienteInputType>("tipoCliente");
			Field<TipoContaInputType>("tipoConta");
			Field<TituloInputType>("titulo");
			Field<ValorCativoInputType>("valorCativo");
			Field<ListGraphType<ApoliceInputType>>("apolice");
			Field<ListGraphType<CartaoPagamentoInputType>>("cartaoPagamento");
			Field<ListGraphType<ContactoInputType>>("contacto");
			Field<ListGraphType<ContratoInputType>>("contratoContaFinanceira1");
			Field<ListGraphType<ContratoInputType>>("contratoContaFinanceira2");
			Field<ListGraphType<EnderecoInputType>>("enderecoNavigation");
			Field<ListGraphType<InformacaoBancariaInputType>>("informacaoBancariaNavigation");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<SaldoInputType>>("saldo");
			Field<ListGraphType<SinistroInputType>>("sinistro");
			Field<ListGraphType<TitularidadeInputType>>("titularidade");
			Field<ListGraphType<TituloInputType>>("tituloNavigation");
			Field<ListGraphType<ValorCativoInputType>>("valorCativoNavigation");
			
		}
	}
}