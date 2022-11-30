using Application.Interfaces;
using Application.Models;
using Confluent.Kafka;
using Domain.Entities;
using Domain.Services.Interfaces;
using Infrastructure.Kafka.KafkaProducer;
using Infrastructure.Repositories;

namespace Application.UseCases
{
    public class RegistrarAtendimentoUseCase : IRegistrarAtendimentoUseCase
    {
        private readonly IPrestadorRepository _prestadorRepository; 
        private readonly IAssociadoRepository _associadoRepository;
        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly IKafkaProducer _kafkaProducer;
        public RegistrarAtendimentoUseCase(IPrestadorRepository prestadorRepository, IAssociadoRepository associadoRepository, 
            IAtendimentoRepository atendimentoRepository,IKafkaProducer kafkaProducer)
        {
            _prestadorRepository = prestadorRepository;
            _associadoRepository = associadoRepository;
            _atendimentoRepository = atendimentoRepository;
            _kafkaProducer = kafkaProducer;
        }

        public async Task<bool> ExecuteAsync(AtendimentoInput atendimentoInput)
        {
            try
            {
                var prestador = await _prestadorRepository.GetPrestadorPorCpf(atendimentoInput.CpfPrestador);
                var associado = await _associadoRepository.GetAssociadoPorCpf(atendimentoInput.CpfAssociado);

                if (associado == null || prestador == null)
                    return false;

                var atendimento = new Atendimento(prestador, associado, DateTime.Now, atendimentoInput.ValorConsulta);

                await _atendimentoRepository.RegistrarAtendimento(atendimento);
                await _kafkaProducer.ProduceAsync(new Message<string, string> { Value = "Teste" }, "antendimento-realizado");

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
