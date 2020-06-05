using GraphQL.Types;

namespace ISS.GraphQL.Type
{
    public class GraphicViewModel
    {
        /// <summary>
        /// Rotulo para o gráfico que terá apresentado aos seus valores.
        /// </summary>
        public string Rotulo { get; set; }
        /// <summary>
        /// Valor de X para qualquer tipo.
        /// </summary>
        public string X { get; set; }
        /// <summary>
        /// Valor de Y para qualquer tipo.
        /// </summary>
        public string Y { get; set; }
    }

    public class GraphicType : ObjectGraphType<GraphicViewModel>
    {
        public GraphicType()
        {
            Field(x => x.Rotulo,nullable:true);
            Field(x => x.X, nullable: true);
            Field(x => x.Y, nullable: true);
        }
    }
}
