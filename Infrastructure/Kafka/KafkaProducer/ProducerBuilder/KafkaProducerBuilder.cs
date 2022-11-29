using Confluent.Kafka;

namespace Infrastructure.Kafka.KafkaProducer.ProducerBuilder
{
    public class KafkaProducerBuilder : IProducerBuilder
    {
        public IProducer<string, string> Build(ProducerConfig config)
        {
            return new ProducerBuilder<string, string>(config).Build();
        }
    }

}
