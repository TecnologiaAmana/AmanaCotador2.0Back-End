using amanaWebAPI.Interfaces;
using amanaWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace amanaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VersoesSacaController : ControllerBase
    {
        private readonly IVersaoSacaRepository _VersaoSacaRepository;

        public VersoesSacaController(IVersaoSacaRepository contexto)
        {
            _VersaoSacaRepository = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_VersaoSacaRepository.ListarTodos());
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
                return Ok(_VersaoSacaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
