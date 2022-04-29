using amanaWebAPI.Domains;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios cadastrados
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Busca um usuário através do seu id
        /// </summary>
        /// <param name="id">id do usuário</param>
        /// <returns>Um usuário específico</returns>
        Usuario BuscarPorId(int id);
        
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Dados do usuario a ser cadastrado</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Deleta um usuário 
        /// </summary>
        /// <param name="id">id do usuário a ser deletado</param>
        /// <returns></returns>
        bool Deletar(int id);

        /// <summary>
        /// Atualiza os dados de um usuário
        /// </summary>
        /// <param name="id">id do usuário</param>
        /// <param name="novoUsuario">Dados atualizados do usuário</param>
        /// <returns></returns>
        bool Atualizar(int id, Usuario novoUsuario);

        /// <summary>
        /// Autentica um usuário cadastrado
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns></returns>
        Usuario Login(string email, string senha);
    }
}
