namespace ISS.Application.Dto
{
    public class FraccionamentoModel
    {

        public string Fraccionamento { get; set; }
        public string FraccionamentoId { get; set; }
        public double Taxa { get; set; }

        public double PremioBase { get; set; }
        public double PremioRisco { get; set; }
        public double PremioSimples { get; set; }
        public double PremioComercial { get; set; }
        public double SinistroEsperado { get; set; }
        public double EncargosAdminstrativos { get; set; }
        public double Encargos { get; set; }
        public double PremioBruto { get; set; }
        public double PremioCobrado { get; set; }
        public double Despesas { get; set; }
        public double Descontos { get; set; }
        public double DescontosPorIdade { get; set; }
        public double Ofertas { get; set; }
        public double Comissoes { get; set; }
        public double Agravamentos { get; set; }
        public double AgravamentosPorIdade { get; set; }
        public double Impostos { get; set; }
        public double JurosFraccionamento { get; set; }
        public double Iva { get; set; }
        public double Arseg { get; set; }
    }
}
