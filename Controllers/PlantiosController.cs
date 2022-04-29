using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using amanaWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace amanaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlantiosController : ControllerBase
    {
        private readonly IPlantioRepository _plantioRepository;

        public PlantiosController(IPlantioRepository contexto)
        {
            _plantioRepository = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_plantioRepository.ListarTodos());
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
                Plantio plantioBuscado = _plantioRepository.BuscarPorId(id);
                if (plantioBuscado == null) return NotFound();

                return Ok(plantioBuscado);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        /// <summary>
        /// Cadastra um novo plantio
        /// </summary>
        /// <param name="novoPlantio">Dados do plantio a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(PlantioViewModel novoPlantioModel)
        {
            try
            {
                Plantio novoPlantio = new Plantio();
                novoPlantio.IdSeguradora = Convert.ToInt16(novoPlantioModel.IdSeguradora);
                novoPlantio.IdNivelCobertura = Convert.ToByte(novoPlantioModel.IdNivelCobertura);
                novoPlantio.IdCultura = Convert.ToInt16((novoPlantioModel.IdCultura));
                novoPlantio.IdMunicipio = novoPlantioModel.IdMunicipio;

                _plantioRepository.Cadastrar(novoPlantio);

                Plantio plantioRecemCadastrado = _plantioRepository.BuscarPorInfo(novoPlantioModel.IdMunicipio, novoPlantioModel.IdSeguradora, novoPlantioModel.IdCultura, novoPlantioModel.IdNivelCobertura);
                return Ok(plantioRecemCadastrado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _plantioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um plantio Através das suas informações
        /// </summary>
        /// <param name="p">Informações do plantio</param>
        /// <returns></returns>
        [HttpPost("info")]
        public IActionResult GetByInfo(PlantioViewModel p)
        {
            try
            {
                return Ok(_plantioRepository.BuscarPorInfo(p.IdMunicipio, p.IdSeguradora, p.IdCultura, p.IdNivelCobertura));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
