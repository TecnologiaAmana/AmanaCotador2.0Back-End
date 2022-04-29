using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace amanaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SeguradorasController : ControllerBase
    {
        private readonly ISeguradoraRepository _seguradoraRepository;

        public SeguradorasController(ISeguradoraRepository contexto)
        {
            _seguradoraRepository = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_seguradoraRepository.ListarTodas());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Seguradora seguradoraBuscada = _seguradoraRepository.BuscarPorId(id);
                if (seguradoraBuscada == null) return NotFound();

                return Ok(seguradoraBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
