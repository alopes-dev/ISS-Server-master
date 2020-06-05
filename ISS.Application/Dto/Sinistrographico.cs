namespace ISS.Application.Dto
{
    public class Sinistrographico
    {
        public string QtdSinistro { get; private set; }
        public string Produto { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Continente { get; set; }
        public string Regiao { get; set; }


        public bool IsPago { get; set; }
        public string Municipio { get; set; }

    }
}
