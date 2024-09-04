using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace MultiShop.RabbitMQMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("Kuyruk2", false, false, false, arguments: null);
            var messageContent = "Merhaba Bugün hava çok sıcak";
            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);
            channel.BasicPublish(exchange: "", routingKey: "Kuyruk2", basicProperties: null, body: byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır");
        }

        private static string message;

        [HttpGet]
        public IActionResult ReadMessage()
        {
            //var factory = new ConnectionFactory();
            //factory.HostName = "localhost";
            //var connection2 = factory.CreateConnection();
            //var channel2 = connection2.CreateModel();
            ////channel2.QueueDeclare("Kuyruk1", false, false, false, null);
            //var consume = new EventingBasicConsumer(channel2);
            ////var messages=channel2.BasicConsume("Kuyruk1", false, consume);
            //consume.Received += (model, x) =>
            //{
            //    var byteMessage = x.Body.ToArray();
            //    message = Encoding.UTF8.GetString(byteMessage);
            //};
            //channel2.BasicConsume(queue: "Kuyruk1", autoAck: false, consumer: consume);

            //if (string.IsNullOrEmpty(message))
            //{
            //    return NoContent();
            //}
            //else
            //{
            //    return Ok(message);
            //}

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var conn = factory.CreateConnection();
            using (var channel = conn.CreateModel())
            {
                var queueName = "Kuyruk2";
                //var msgs = channel.BasicGet(queueName, true);
                var response = channel.QueueDeclarePassive(queueName);
                var msgCount = response.MessageCount;
                var consCount = response.ConsumerCount;

                var result = channel.BasicGet(queueName, false);

                //{"count":5,"ackmode":"ack_requeue_true","encoding":"auto","truncate":50000}
                if (result == null)
                {
                    //No msgs available 
                }
                else
                {
                    IBasicProperties properties = result.BasicProperties;
                    byte[] body = result.Body.ToArray();

                    message = Encoding.UTF8.GetString(body) + " " + properties.Headers;
                    //channel.BasicAck(result.DeliveryTag, true);
                }
            }
            return Ok(message);
        }
    }
}
