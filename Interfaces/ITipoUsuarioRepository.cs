using amanaWebAPI.Domains;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<Tipousuario> ListarTodos();

        Tipousuario BuscarPorId(int id);

        bool Cadastrar(Tipousuario TipoUsuario);

        bool Deletar(int id);

        bool Atualizar(int id, Tipousuario tipoUsuarioAtualizado);
    }
}
