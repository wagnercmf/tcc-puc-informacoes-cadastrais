using Application.Interfaces;
using Application.Models;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("atendimento")]
    public class AtendimentosController : ControllerBase
    {
        private readonly ILogger<AtendimentosController> _logger;
        private readonly IRegistrarAtendimentoUseCase _registrarAtendimentoUseCase;
        private readonly ICalcularValorCorpaticipacaoDoAtendimentoUseCase _calcularValorCorpaticipacaoDoAtendimentoUseCase;

        public AtendimentosController(IRegistrarAtendimentoUseCase registrarAtendimentoUseCase,
            ICalcularValorCorpaticipacaoDoAtendimentoUseCase calcularValorCorpaticipacaoDoAtendimentoUseCase,
            ILogger<AtendimentosController> logger)
        {
            _logger = logger;
            _registrarAtendimentoUseCase = registrarAtendimentoUseCase;
            _calcularValorCorpaticipacaoDoAtendimentoUseCase = calcularValorCorpaticipacaoDoAtendimentoUseCase;
        }

        [HttpPost()]
        public async Task<IActionResult> PostAtendimento(AtendimentoInput input)
        {
            try
            {
                if (!input.IsValid())
                {
                    _logger.LogWarning($"[PostAtendimento]Atendimento com dados inválidos.");
                    return BadRequest("Atendimento com dados inválidos");
                }

                var atendimentoCriado = await _registrarAtendimentoUseCase.ExecuteAsync(input);
                return Ok(atendimentoCriado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[PostAtendimento] Erro ao criar atendimento: {ex}");
                return StatusCode(500);
            }
        }

        [HttpGet("valorCorpaticipacao/{cpfPrestador}/{cpfAssociado}/{valorConsulta}")]
        public async Task<IActionResult> CalcularValorCorpaticipacaoDoAtendimento(string cpfPrestador, string cpfAssociado, double valorConsulta)
        {
            try
            {
                var atendimentoInput = new AtendimentoInput() { CpfPrestador = cpfPrestador, CpfAssociado = cpfAssociado, ValorConsulta = valorConsulta };
                if (!atendimentoInput.IsValid())
                {
                    _logger.LogWarning($"[PostAtendimento]Atendimento com dados inválidos.");
                    return BadRequest("Atendimento com dados inválidos");
                }

                var valorCoparticipacao = await _calcularValorCorpaticipacaoDoAtendimentoUseCase.ExecuteAsync(atendimentoInput);
                return Ok(valorCoparticipacao);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[PostAtendimento] Erro ao criar atendimento: {ex}");
                return StatusCode(500);
            }
        }
    }
}