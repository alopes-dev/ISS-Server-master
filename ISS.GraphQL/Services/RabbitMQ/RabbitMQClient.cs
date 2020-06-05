using ISS.GraphQL.Repository;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;

namespace ISS.GraphQL.ISRabbitMQ
{
    public class RabbitMQClient : IRabbitMQClient
    {
        protected ILogger<RabbitMQClient> Logger { get; }
        private ConnectionFactory _factory;
        private IConnection _connection;
        protected IRepository Repo { get; }
        private IModel _model;

        public RabbitMQClient(IRepository repository)
        {
            Repo = repository;
            // CreateConnection();
        }

        public void CreateConnection()
        {
            _factory = new ConnectionFactory
            {
                HostName = "172.16.16.85",
                UserName = "snir",
                Password = "snir"

            };
            try
            {
                _connection = _factory.CreateConnection();
                _model = _connection.CreateModel();
            }
            catch (ArgumentException)
            {
                return;
            }
            catch (ConnectFailureException)
            {
                return;
            }
            catch (BrokerUnreachableException)
            {
                return;
            }

        }

        public void Close()
        {
            _connection.Close();
        }

        public TModel Send<TModel>(string nomeExchange, string nomeQueue, string acao, TModel model)
           where TModel : class
        {
            var route = $"{nomeQueue}.{acao}";
            _model.ExchangeDeclare(nomeExchange, "topic");
            _model.QueueDeclare(nomeQueue, true, false, false, null);
            _model.QueueBind(nomeQueue, nomeExchange, route);
            _model.BasicPublish(nomeExchange, route, null, model.Serialize());
            Receive(model.GetType());
            return default;
        }

        public void Receive(System.Type type)
        {
            // _model.QueueDeclare(type.Name, true, false, false, null);
            var consumer = new EventingBasicConsumer(_model);
            consumer.Received +=  (ch, ea) =>
            {
                var body = ea.Body;
                var obj = body.DeSerialize(type);
                var key = ea.RoutingKey;

                // if ($"{type.Name}.A" == key)
                // {
                //     await Repo.AddAsync(obj);
                // }
                // else if ($"{type.Name}.U" == key)
                // {
                //     var id = obj.GetPropertyValue(obj.GetPrimaryKey());
                //     obj.SetPropValue(obj.GetPrimaryKey(),null);

                //     Repo.GetType().
                //         GetMethod(nameof(Repository.IRepository.UpdateAsync))
                //         .MakeGenericMethod(type)
                //         .Invoke(Repo, new object[] { id, obj });
                // }
                // else if ($"{type.Name}.D" == key)
                // {
                //     var id = obj.GetPropertyValue(obj.GetPrimaryKey());

                //     Repo.GetType().
                //         GetMethod(nameof(Repository.IRepository.RemoveAsync))
                //         .MakeGenericMethod(type)
                //         .Invoke(Repo, new object[] { id });
                // }

                _model.BasicAck(ea.DeliveryTag, false);
            };
            _model.BasicConsume(type.Name, false, consumer);
        }

        public bool CheckConn() => _connection != null ? true : false;
    }
}
