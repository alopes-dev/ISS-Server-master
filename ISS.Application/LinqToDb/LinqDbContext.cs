using ISS.Application.Models;
using LinqToDB;

namespace ISS.Application.LinqToDb
{
    public class LinqDbContext : LinqToDB.Data.DataConnection
    {
        public LinqDbContext()
        {
        }

        public ITable<Pessoa> Pessoa => GetTable<Pessoa>();
        public ITable<Titularidade> Titularidade => GetTable<Titularidade>();
        public ITable<Cliente> Cliente => GetTable<Cliente>();
        public ITable<Moeda> Moeda => GetTable<Moeda>();
        public ITable<Estado> Estado => GetTable<Estado>();
        public ITable<TipoPessoa> TipoPessoa => GetTable<TipoPessoa>();
        public ITable<LinhaProduto> LinhaProduto => GetTable<LinhaProduto>();
        public ITable<PapelPessoa> PapelPessoa => GetTable<PapelPessoa>();
        public ITable<Apolice> Apolice => GetTable<Apolice>();
        public ITable<CotacaoDependente> CotacaoDependente => GetTable<CotacaoDependente>();
        public ITable<Papel> Papel => GetTable<Papel>();
        public ITable<ContaFinanceira> ContaFinanceira => GetTable<ContaFinanceira>();
        public ITable<Cotacao> Cotacao => GetTable<Cotacao>();
        public ITable<PlanoProduto> PlanoProduto => GetTable<PlanoProduto>();
        public ITable<PeriodoPlano> PeriodoPlano => GetTable<PeriodoPlano>();
        public ITable<DuracaoTipoContrato> DuracaoTipoContrato => GetTable<DuracaoTipoContrato>();
        public ITable<CoberturaSelecionada> CoberturaSelecionada => GetTable<CoberturaSelecionada>();
        public ITable<CoberturaPlano> CoberturaPlano => GetTable<CoberturaPlano>();

        public ITable<Bairro> Bairro => GetTable<Bairro>();
        public ITable<Rua> Rua => GetTable<Rua>();
        public ITable<Distrito> Distrito => GetTable<Distrito>();
        public ITable<Municipio> Municipio => GetTable<Municipio>();
        public ITable<Provincia> Provincia => GetTable<Provincia>();
        public ITable<Continente> Continente => GetTable<Continente>();
        public ITable<Pais> Pais => GetTable<Pais>();
        public ITable<Sinistro> Sinistros => GetTable<Sinistro>();
        public ITable<LinhaProduto> LinhaProdutos => GetTable<LinhaProduto>();
        public ITable<PlanoProduto> PlanoProdutos => GetTable<PlanoProduto>();

    }
}