using ISS.Application.Models;

namespace ISS.GraphQL.Query
{
    // Classe auxiliar para poder construir o objecto de Plano de Objectivo Comercial
    public class Parametro
    {
        // O Objecto de plano que foi inserido ou que está acima da hierarquia.
        public PlanoObjectivoComercial Model { get; set; }
        // O id do objecto que será inserido
        public string Id { get; set; }
        // O codigo do plano a ser inserido
        public string Codigo { get; set; }
        // A quantidade de elementos
        public int QuantidadeElementos { get; set; }
    }
}