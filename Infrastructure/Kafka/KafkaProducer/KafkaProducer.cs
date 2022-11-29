using Confluent.Kafka;
using Infrastructure.Kafka.KafkaProducer.ProducerBuilder;

namespace Infrastructure.Kafka.KafkaProducer
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<string, string> _producer;

        public KafkaProducer(IProducerBuilder producerBuilder)
        {
            var producerConfig = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "User",
                SaslPassword = "Password"
            };

            _producer = producerBuilder.Build(producerConfig);
        }

        public async Task ProduceAsync(Message<string, string> message, string topic)
        {
            await _producer.ProduceAsync(topic, message);
        }
    }
}