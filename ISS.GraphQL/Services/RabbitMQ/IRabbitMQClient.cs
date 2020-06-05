
namespace ISS.GraphQL.ISRabbitMQ
{
    public interface IRabbitMQClient
    {
        void CreateConnection();

        void Close();

        TModel Send<TModel>(string nomeExchange, string nomeQueue, string acao, TModel model)
           where TModel : class;

        void Receive(System.Type type);

        bool CheckConn();
    }
}