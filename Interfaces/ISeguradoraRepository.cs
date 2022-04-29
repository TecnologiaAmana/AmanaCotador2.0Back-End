using amanaWebAPI.Domains;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface ISeguradoraRepository
    {
        /// <summary>
        /// Lista todas as seguradoras cadastradas
        /// </summary>
        /// <returns>Uma lista de seguradoras</returns>
        List<Seguradora> ListarTodas();

        /// <summary>
        /// Busca uma seguradora atraves do seu id
        /// </summary>
        /// <param name="id">Id da seguradora</param>
        /// <returns>Lista de seguradoras</returns>
        Seguradora BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova Seguradora
        /// </summary>
        /// <param name="novaSeguradora">Dados da nova seguradora</param>
        /// <returns></returns>
        bool Cadastrar(Seguradora novaSeguradora);

        /// <summary>
        /// Deleta uma seguradora atraves do id
        /// </summary>
        /// <param name="id">Id da seguradora</param>
        /// <returns></returns>
        bool Deletar(int id);


        /// <summary>
        /// Atualiza uma seguradora atraves do id
        /// </summary>
        /// <param name="id">Id da seguradora</param>
        /// <param name="seguradoraAtualizada">Novos dados da seguradora</param>
        /// <returns></returns>
        bool Atualizar(int id, Seguradora seguradoraAtualizada);
    }
}
