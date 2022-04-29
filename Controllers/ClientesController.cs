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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository contexto)
        {
            _clienteRepository = contexto;
        }

        /// <summary>
        /// Lista todos os cliente cadastrados
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clienteRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um cliente através do seu id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Cliente clienteBuscado = _clienteRepository.BuscarPorId(id);
                if (clienteBuscado == null) return NotFound();

                return Ok(clienteBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="clienteViewModel">Informações para cadastra um cliente</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ClienteViewModel clienteViewModel)
        {
            try
            {
                Cliente cliente = new Cliente()
                {
                    IdUsuario = clienteViewModel.IdUsuario,
                    Telefone = clienteViewModel.Telefone
                };

                _clienteRepository.Cadastrar(cliente);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um cliente através do seu usuário
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _clienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
