using amanaWebAPI.Domains;
using amanaWebAPI.ExtendedDomain;
using amanaWebAPI.Interfaces;
using amanaWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace amanaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CotacoesController : ControllerBase
    {
        private readonly ICotacaoRepository _cotacaoRepository;

        public CotacoesController(ICotacaoRepository contexto)
        {
            _cotacaoRepository = contexto;
        }

        /// <summary>
        /// Busca todas as cotações cadastradas
        /// </summary>
        /// <param name="area">Area para calculo das cotações</param>
        /// <returns>Uma lista de cotações</returns>
        [HttpPost]
        public IActionResult Get(AreaViewModel area)
        {
            try
            {
                List<Cotacao> cotacoes = _cotacaoRepository.ListarTodas();

                List<CotacaoExtended> cotacoesExtended = _cotacaoRepository.Calcular(cotacoes, area.Area);
                return Ok(cotacoesExtended);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca todas as cotações dependendo do seu plantio
        /// </summary>
        /// <param name="area">Area para calculo das cotações</param>
        /// <param name="id">Id to replantio</param>
        /// <returns>Uma lista de cotações</returns>
        [HttpPost("{id}")]
        public IActionResult Get(AreaViewModel area, int id)
        {
            try
            {
                List<Cotacao> cotacoes = _cotacaoRepository.BuscarPorPlantio(id);

                List<CotacaoExtended> cotacoesExtended = _cotacaoRepository.Calcular(cotacoes, area.Area);
                return Ok(cotacoesExtended);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra uma nova cotação
        /// </summary>
        /// <param name="cotacao">Dados da cotação a ser cadastrada</param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(CotacaoViewModel cotacao)
        {
            try
                {
                cotacao.IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Cotacao cotacaoPrep = _cotacaoRepository.PrepCadastrar(cotacao);

                _cotacaoRepository.Cadastrar(cotacaoPrep);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);            }
        }

        /// <summary>
        /// Deleta uma cotação atraves do seu id
        /// </summary>
        /// <param name="id">Id da cotação a ser deletada</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _cotacaoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
