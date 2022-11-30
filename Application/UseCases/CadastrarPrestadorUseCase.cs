using Application.Interfaces;
using Application.Models;
using Confluent.Kafka;
using Domain.Entities;
using Domain.Enums;
using Domain.Services.Interfaces;
using Infrastructure.Kafka.KafkaProducer;
using Infrastructure.Repositories;
using System.Text.Json;

namespace Application.UseCases
{
    public class CadastrarPrestadorUseCase : ICadastrarPrestadorUseCase
    {
        private readonly IPrestadorRepository _prestadorRepository; 
        private readonly IKafkaProducer _kafkaProducer;
        private const string topicoPrestadorCadastrado = "prestador-cadastrado";
        public CadastrarPrestadorUseCase(IPrestadorRepository prestadorRepository,IKafkaProducer kafkaProducer)
        {
            _prestadorRepository = prestadorRepository;
            _kafkaProducer = kafkaProducer;
        }

        public async Task<bool> ExecuteAsync(PrestadorInput prestadorInput)
        {
            try
            {
                var prestador = new Prestador(prestadorInput.Nome, prestadorInput.Documento, 
                    prestadorInput.Endereco, prestadorInput.Especialidade);

                prestador.SetFormacao(prestadorInput.Instituicao, prestadorInput.Profissao, (TipoFormacao)prestadorInput.TipoFormacao);

                await _prestadorRepository.SalvarPrestador(prestador);
                await _kafkaProducer.ProduceAsync(new Message<string, string> { Value = JsonSerializer.Serialize(prestador) }, topicoPrestadorCadastrado);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
