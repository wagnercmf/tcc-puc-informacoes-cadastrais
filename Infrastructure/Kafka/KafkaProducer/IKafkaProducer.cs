using Confluent.Kafka;

namespace Infrastructure.Kafka.KafkaProducer
{
    public interface IKafkaProducer
    {
        public Task ProduceAsync(Message<string, string> message, string topic);
    }
}