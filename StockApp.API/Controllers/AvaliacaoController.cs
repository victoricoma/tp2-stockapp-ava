using Microsoft.AspNetCore.Mvc;
using StockApp.API.Models;
using StockApp.Application.Services;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Avaliacao>> GetAll()
        {
            var avaliacoes = _avaliacaoService.GetAll();
            return Ok(avaliacoes);
        }

        [HttpGet("{id}")]
        public ActionResult<Avaliacao> GetById(int id)
        {
            var avaliacao = _avaliacaoService.GetById(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            return Ok(avaliacao);
        }

        [HttpPost]
        public ActionResult<Avaliacao> Create([FromBody] Avaliacao avaliacao)
        {
            if (avaliacao == null)
            {
                return BadRequest();
            }

            var createdAvaliacao = _avaliacaoService.Create(avaliacao);
            return CreatedAtAction(nameof(GetById), new { id = createdAvaliacao.Id }, createdAvaliacao);
        }
    }
}
