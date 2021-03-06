using amanaWebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace amanaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CulturasController : ControllerBase
    {
        private readonly ICulturaRepository _culturaRepository;

        public CulturasController(ICulturaRepository contexto)
        {
            _culturaRepository = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_culturaRepository.ListarTodos());
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
                return Ok(_culturaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
