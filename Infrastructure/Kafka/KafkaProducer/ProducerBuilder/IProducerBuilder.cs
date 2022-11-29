using Confluent.Kafka;
namespace Infrastructure.Kafka.KafkaProducer.ProducerBuilder
{
    public interface IProducerBuilder
    {
        public IProducer<string, string> Build(ProducerConfig config);
    }
}
