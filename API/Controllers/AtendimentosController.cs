using Application.Interfaces;
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
        public async Task<IActionResult> PostAtendimento(string especialidade)
        {
            try
            {
                await _registrarAtendimentoUseCase.ExecuteAsync("Tchubla");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[GetPrestadorPorEspecialidade] Erro ao buscar prestador: {ex}");
                return StatusCode(500);
            }
        }
    }
}
