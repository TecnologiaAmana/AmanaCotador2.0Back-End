using amanaWebAPI.Domains;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface IUfRepository
    {
        List<Uf> ListarTodos();

        Uf BuscarPorId(int id);

        bool Cadastrar(Uf Uf);

        bool Deletar(int id);

        bool Atualizar(int id, Uf UfAtualizado);
    }
}
