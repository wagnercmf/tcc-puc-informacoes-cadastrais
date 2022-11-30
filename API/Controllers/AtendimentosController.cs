using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("atendimento")]
    public class AtendimentosController : ControllerBase
    {
        private readonly ILogger<AtendimentosController> _logger;
        private readonly IRegistrarAtendimentoUseCase _registrarAtendimentoUseCase;

        public AtendimentosController(IRegistrarAtendimentoUseCase registrarAtendimentoUseCase,
            ILogger<AtendimentosController> logger)
        {
            _logger = logger;
            _registrarAtendimentoUseCase = registrarAtendimentoUseCase;
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
    }
}
