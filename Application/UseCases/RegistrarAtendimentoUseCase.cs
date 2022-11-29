using Application.Interfaces;
using Confluent.Kafka;
using Domain.Services.Interfaces;
using Infrastructure.Kafka.KafkaProducer;
namespace Application.UseCases
{
    public class RegistrarAtendimentoUseCase : IRegistrarAtendimentoUseCase
    {
        private readonly IPrestadorRepository _prestadorRepository; //Trocar para atendimento
        private readonly IKafkaProducer _kafkaProducer;
        public RegistrarAtendimentoUseCase(IPrestadorRepository prestadorRepository, IKafkaProducer kafkaProducer)
        {
            _prestadorRepository = prestadorRepository;
            _kafkaProducer = kafkaProducer;
        }

        public async Task ExecuteAsync(string atendimentoInput)
        {
            try
            {
                await _kafkaProducer.ProduceAsync(new Message<string, string> { Value = "Teste" }, "antendimento-realizado");
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
