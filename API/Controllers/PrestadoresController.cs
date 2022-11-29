using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("prestador")]
    public class PrestadoresController : ControllerBase
    {
        private readonly ILogger<PrestadoresController> _logger;
        private readonly IGetPrestadoresPorEspecialidadeUseCase _getPrestadoresPorEspecialidadeUseCase;

        public PrestadoresController(IGetPrestadoresPorEspecialidadeUseCase getPrestadoresUseCase, 
            ILogger<PrestadoresController> logger)
        {
            _logger = logger;
            _getPrestadoresPorEspecialidadeUseCase = getPrestadoresUseCase;
        }

        [HttpGet("{especialidade}")]
        public async Task<IActionResult> GetPrestadorPorEspecialidade(string especialidade)
        {
            try
            {
                if (string.IsNullOrEmpty(especialidade))
                {
                    _logger.LogWarning($"[GetPrestadorPorEspecialidade]Especialidade {especialidade} inválida");
                    return BadRequest("Especialidade inválida");

                }

                var prestadores = await _getPrestadoresPorEspecialidadeUseCase.ExecuteAsync(especialidade);

                if (prestadores.Any())
                {
                    _logger.LogInformation("[GetPrestadorPorEspecialidade] Retornado com sucesso");
                    return Ok(prestadores);
                }

                _logger.LogWarning($"[GetPrestadorPorEspecialidade] Nenhum prestador para espcialidade {especialidade}");
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError($"[GetPrestadorPorEspecialidade] Erro ao buscar prestador: {ex}");
                return StatusCode(500);
            }
        }
    }
}