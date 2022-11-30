using Application.Interfaces;
using Application.Models;
using Confluent.Kafka;
using Domain.Entities;
using Domain.Services.Interfaces;
using Infrastructure.Kafka.KafkaProducer;
using Infrastructure.Repositories;

namespace Application.UseCases
{
    public class CalcularValorCorpaticipacaoDoAtendimentoUseCase : ICalcularValorCorpaticipacaoDoAtendimentoUseCase
    {
        private readonly IPrestadorRepository _prestadorRepository; 
        private readonly IAssociadoRepository _associadoRepository;
        public CalcularValorCorpaticipacaoDoAtendimentoUseCase(IPrestadorRepository prestadorRepository, IAssociadoRepository associadoRepository)
        {
            _prestadorRepository = prestadorRepository;
            _associadoRepository = associadoRepository;
        }

        public async Task<double> ExecuteAsync(AtendimentoInput atendimentoInput)
        {
            try
            {
                var prestador = await _prestadorRepository.GetPrestadorPorCpf(atendimentoInput.CpfPrestador);
                var associado = await _associadoRepository.GetAssociadoPorCpf(atendimentoInput.CpfAssociado);

                if (associado == null || prestador == null)
                    throw new Exception("Associado ou prestado não existem");

                var atendimento = new Atendimento(prestador, associado, DateTime.Now, atendimentoInput.ValorConsulta);

                return atendimento.ValorCopartipacao;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
