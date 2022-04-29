using amanaWebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace amanaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipiosController : ControllerBase
    {
        private readonly IMunicipioRepository _municipioRepository;

        public MunicipiosController(IMunicipioRepository contexto)
        {
            _municipioRepository = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_municipioRepository.ListarTodos());
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
                return Ok(_municipioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("uf/{id}")]
        public IActionResult GetByIdUf(int id)
        {
            try
            {
                return Ok(_municipioRepository.ListarPeloUf(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
