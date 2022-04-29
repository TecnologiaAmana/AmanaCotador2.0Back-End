using amanaWebAPI.Domains;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface IPlantioRepository
    {
        /// <summary>
        /// Lista todos os plantios
        /// </summary>
        /// <returns>Lista de Plantios</returns>
        List<Plantio> ListarTodos();

        /// <summary>
        /// Busca um plantio através de suas informações
        /// </summary>
        /// <param name="idMunicipio">Id do Municipio do plantio</param>
        /// <param name="idSeguradora">Id da Seguradora do plantio</param>
        /// <param name="idCultura">Id da Cultura do plantio</param>
        /// <param name="idNivelCobertura">Id do Nivel de Cobertura do plantio</param>
        /// <returns></returns>
        Plantio BuscarPorInfo(int idMunicipio, int idSeguradora, int idCultura, int idNivelCobertura);

        /// <summary>
        /// Busca um plantio atraves do id
        /// </summary>
        /// <param name="id">id do plantio a ser buscado</param>
        /// <returns>Um plantio especifico</returns>
        Plantio BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Plantio
        /// </summary>
        /// <param name="novoPlantio">Plantio a ser cadastrado</param>
        /// <returns>True or false</returns>
        bool Cadastrar(Plantio novoPlantio);

        /// <summary>
        /// Deleta um plantio
        /// </summary>
        /// <param name="id">id do plantio</param>
        /// <returns></returns>
        bool Deletar(int id);

        /// <summary>
        /// Atualiza um plantio pelo seu id
        /// </summary>
        /// <param name="id">id do plantio</param>
        /// <param name="plantioAtualizado">Dados do plantio a ser atualizado</param>
        /// <returns></returns>
        bool Atualizar(int id, Plantio plantioAtualizado);

    }
}
