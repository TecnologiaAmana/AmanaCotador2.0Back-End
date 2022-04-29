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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository contexto)
        {
            _usuarioRepository = contexto;
        }

        /// <summary>
        /// Lista todos os usuários Cadastrados
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um usuário através do Id
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Um usuário em especifico</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado == null) return NotFound();

                return Ok(usuarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo usuário do tipo Cliente
        /// </summary>
        /// <param name="novoUsuarioModel">Informações do novo usuario (menos seu tipo)</param>
        /// <returns>Status de criado</returns>
        [HttpPost]
        public IActionResult Post(UsuarioViewModel novoUsuarioModel)
        {
            try
            {
                Usuario novoUsuario = new Usuario()
                {
                    IdTipoUsuario = 1,
                    Nome = novoUsuarioModel.Nome,
                    Email = novoUsuarioModel.Email,
                    Senha = novoUsuarioModel.Senha,
                };

                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um usuário do tipo administrador
        /// </summary>
        /// <param name="novoUsuarioModel">Informações do novo Administrador</param>
        /// <returns>Status de Criado</returns>
        [HttpPost("adm")]
        public IActionResult PostAdm(UsuarioViewModel novoUsuarioModel)
        {
            try
            {
                Usuario novoUsuario = new Usuario()
                {
                    IdTipoUsuario = 2,
                    Nome = novoUsuarioModel.Nome,
                    Email = novoUsuarioModel.Email,
                    Senha = novoUsuarioModel.Senha,
                };

                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Deleta um usuário Cadastrado
        /// </summary>
        /// <param name="id">Id do Usuario que será deletado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Id inválido",
                                erro = true
                            }
                        );
                }

                _usuarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
