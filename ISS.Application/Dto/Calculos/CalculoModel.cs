using ISS.Application.Models;
using System.Collections.Generic;

namespace ISS.Application.Dto
{

    public class CalculoDetalhe
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }

    public class CalculoModel
    {
        #region Constructor
        /// <summary>
        /// Constructor Padrão
        /// </summary>
        public CalculoModel()
        {
            OfertasDetalhe = new HashSet<CalculoDetalhe>();
            ImpostosDetalhe = new HashSet<CalculoDetalhe>();
            DespesasDetalhe = new HashSet<CalculoDetalhe>();
            ComissoesDetalhe = new HashSet<CalculoDetalhe>();
            DescontosDetalhe = new HashSet<CalculoDetalhe>();
            AgravamentosDetalhe = new HashSet<CalculoDetalhe>();
            DescontosPorIdadeDetalhe = new HashSet<CalculoDetalhe>();
            AgravamentosPorIdadeDetalhe = new HashSet<CalculoDetalhe>();
            EncargosAdministrativosDetalhe = new HashSet<CalculoDetalhe>();
            EncargosDetalhe = new HashSet<CalculoDetalhe>();
            PremiosFraccionado = new HashSet<FraccionamentoModel>();
            AnaliseRisco = new HashSet<CalculoModel>();
            Transacoes = new List<Movimento>();
        }
        #endregion

        #region Public Properties
        public virtual Cotacao Cotacao { get; set; }
        public virtual Simulacao Simulacao { get; set; }
        public virtual Apolice Apolice { get; set; }
        public virtual PlanoProduto Plano { get; set; }
        public virtual ContaFinanceira ContaFinanceira { get; set; }
        public virtual ISS.Application.Models.Pessoa Pessoa { get; set; }

        public int NumDiasApolice { get; set; }
        public int NumUnidadesContratadas { get; set; }
        public double CapitalSeguro { get; set; }
        public double PremioBase { get; set; }
        public double PremioRisco { get; set; }
        public double PremioSimples { get; set; }
        public double PremioComercial { get; set; }
        public double SinistroEsperado { get; set; }

        public double PremioBruto { get; set; }
        public double PremioCobrado { get; set; }
        public double PremioTotal { get; set; }

        public double Ofertas { get; set; }
        public double Impostos { get; set; }
        public double Despesas { get; set; }
        public double Comissoes { get; set; }
        public double Descontos { get; set; }
        public double Agravamentos { get; set; }
        public double DescontosPorIdade { get; set; }
        public double AgravamentosPorIdade { get; set; }
        public double EncargosAdministrativos { get; set; }
        public double Encargos { get; set; }
        public double JurosFraccionamento { get; set; }

        public ICollection<CalculoDetalhe> OfertasDetalhe { get; set; }
        public ICollection<CalculoDetalhe> ImpostosDetalhe { get; set; }
        public ICollection<CalculoDetalhe> DespesasDetalhe { get; set; }
        public ICollection<CalculoDetalhe> ComissoesDetalhe { get; set; }
        public ICollection<CalculoDetalhe> DescontosDetalhe { get; set; }
        public ICollection<CalculoDetalhe> AgravamentosDetalhe { get; set; }
        public ICollection<CalculoDetalhe> DescontosPorIdadeDetalhe { get; set; }
        public ICollection<CalculoDetalhe> AgravamentosPorIdadeDetalhe { get; set; }
        public ICollection<CalculoDetalhe> EncargosAdministrativosDetalhe { get; set; }
        public ICollection<CalculoDetalhe> EncargosDetalhe { get; set; }
        public List<Movimento> Transacoes { get; set;  }

        public double Iva { get; set; }
        public double Arseg { get; set; }

        public string EstadoId { get; set; }
        public ICollection<FraccionamentoModel> PremiosFraccionado { get; set; }
        public ICollection<CalculoModel> AnaliseRisco { get; set; }
        public bool Status { get; set; } = true;
        public string Message { get; set; } 
        #endregion
    }
}
